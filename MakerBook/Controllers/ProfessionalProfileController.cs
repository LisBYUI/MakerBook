using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;
using MakerBook.Helper.Interface;
using System.Drawing;
using MakerBook.Filters;
using MakerBook.ViewModels;
using MakerBook.Enum;

namespace MakerBook.Controllers
{
    [PageForUserLogged]
    public class ProfessionalProfileController : Controller
    {
        private readonly IProfessionalRepository _professionalRepository;
        private readonly IProfessionalProfileRepository _professionalProfileRepository;
        private readonly IProfessionalSocialMediaRepository _professionalSocialMediaRepository;
        private readonly ISessionHelper _session;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProfessionalProfileController(IProfessionalRepository professionalRepository, IProfessionalProfileRepository professionalProfileRepository, IProfessionalSocialMediaRepository professionalSocialMediaRepository, ISessionHelper session, IWebHostEnvironment webHostEnvironment)
        {
            _professionalRepository = professionalRepository;
            _professionalProfileRepository = professionalProfileRepository;
            _professionalSocialMediaRepository = professionalSocialMediaRepository;
            _session = session;
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            var userSession = _session.GetUserSession();


            //if (userSession.Profile == Enum.ProfileEnum.Professional)
            //{
            var professional = _professionalRepository.GetByEmail(userSession.Email);


            //}
            var professionalProfileModel = _professionalProfileRepository.GetByProfessional(professional.ProfessionalId);

            ProfessionalProfileViewModel professionalProfileView = MapRegisterProfessionalProfileView(professionalProfileModel);


            return View(professionalProfileView);
        }


        // GET: ProfessionalProfileViewModel/Details/5
        public IActionResult Details(int? id)
        {
            var ProfessionalProfileViewModel = _professionalProfileRepository.Get(id ?? 0);


            if (ProfessionalProfileViewModel == null)
            {
                return NotFound();
            }

            return View(ProfessionalProfileViewModel);
        }

        // GET: ProfessionalProfileViewModel/Create
        public IActionResult ProfessionalProfile()
        {
            var userSession = _session.GetUserSession();
            ProfessionalProfileViewModel professionalProfileView = new ProfessionalProfileViewModel();

            if (userSession.Profile == Enum.ProfileEnum.Professional)
            {
                var professional = _professionalRepository.GetByEmail(userSession.Email);

                professionalProfileView.ProfessionalId = professional.ProfessionalId;
            }

            return View(professionalProfileView);
        }

        // POST: ProfessionalProfileViewModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ProfessionalProfile(ProfessionalProfileViewModel professionalProfileViewModel)
        {
            try
            {

                if (ModelState.IsValid)
                {
                    MemoryStream ms = new MemoryStream();
                    professionalProfileViewModel.ImageProfileForm.OpenReadStream().CopyTo(ms);

                    var userSession = _session.GetUserSession();

                    var professionalProfileModel = MapRegisterProfessional(professionalProfileViewModel, userSession.Login, ms.ToArray());

                    var professionalProfile = _professionalProfileRepository.Create(professionalProfileModel);

                    SelectSocialMedia(professionalProfileViewModel, professionalProfile.ProfessionalProfileId, userSession.Login);

                    TempData["SuccessMessage"] = "Success!!!";
                    return RedirectToAction(nameof(Index));
                }
                return View(professionalProfileViewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: ProfessionalProfileViewModel/Edit/5
        public IActionResult Edit(int? id)
        {
            var ProfessionalProfileViewModel = _professionalProfileRepository.Get(id ?? 0);
            if (ProfessionalProfileViewModel == null)
            {
                return NotFound();
            }
            return View(ProfessionalProfileViewModel);
        }

        // POST: ProfessionalProfileViewModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProfessionalProfileViewModel ProfessionalProfileViewModel)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                var userSession = _session.GetUserSession();
                MemoryStream ms = new MemoryStream();
                //ProfessionalProfileViewModel.ImageCategory.OpenReadStream().CopyTo(ms);

                //ProfessionalProfileViewModel.UpdatedAt = DateTime.Now;
                //if (userSession != null)
                //    ProfessionalProfileViewModel.UserAt = userSession.Login;

                //ProfessionalProfileViewModel.Image = ms.ToArray();

                //ProfessionalProfileViewModel category = _categoryRepository.Update(ProfessionalProfileViewModel);
                TempData["SuccessMessage"] = "Success!!!";
                return RedirectToAction(nameof(Index));
                //}

                return View("Edit", ProfessionalProfileViewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction("Index");
            }
        }

        // GET: ProfessionalProfileViewModel/Delete/5
        public IActionResult Delete(int? id)
        {
            var ProfessionalProfileViewModel = _professionalProfileRepository.Get(id ?? 0);
            if (ProfessionalProfileViewModel == null)
            {
                return NotFound();
            }

            return View(ProfessionalProfileViewModel);
        }

        // POST: ProfessionalProfileViewModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var deleteConfirmed = _professionalProfileRepository.Delete(id);
                if (deleteConfirmed)
                    TempData["SuccessMessage"] = "Success!!!";
                else
                    TempData["ErrorMessage"] = $"Fail!!!";

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction("Index");
            }
        }

        private ProfessionalProfileModel MapRegisterProfessional(ProfessionalProfileViewModel sourceModel, string login, byte[] file)
        {
            ProfessionalProfileModel targetModel = new ProfessionalProfileModel
            {
                ProfessionalProfileId = sourceModel.ProfessionalProfileId
            ,
                ProfessionalId = sourceModel.ProfessionalId
            ,
                ImageProfile = file
            ,
                CreatedAt = DateTime.Now
            ,
                UpdatedAt = DateTime.Now
            ,
                UserAt = login
            };

            return targetModel;
        }

        private ProfessionalProfileViewModel MapRegisterProfessionalProfileView(ProfessionalProfileModel sourceModel)
        {
            ProfessionalProfileViewModel targetModel = new ProfessionalProfileViewModel
            {
                ProfessionalProfileId = sourceModel.ProfessionalProfileId
            ,
                ProfessionalId = sourceModel.ProfessionalId
            ,
                ImageProfile = sourceModel.ImageProfile
                ,
                Description = sourceModel.Description
                ,
                Professional = sourceModel.Professional
                ,
                professionalSocialMediaList = MapRegisterProfessionalSocialMedia(sourceModel.ProfessionalProfileId)
            };

            return targetModel;
        }

        /// <summary>
        /// SelectSocialMedia
        /// </summary>
        /// <param name="professionalProfileViewModel"></param>
        /// <param name="login"></param>
        private void SelectSocialMedia(ProfessionalProfileViewModel professionalProfileViewModel, int professionalProfileId, string login)
        {
            if (!string.IsNullOrEmpty(professionalProfileViewModel.Facebook))
            {
                int professionalSocialMediaId = 0;

                ProfessionalProfileTypeEnum professionalProfileType = ProfessionalProfileTypeEnum.Facebook;
                string socialMedia = professionalProfileViewModel.Facebook;

                ProfessionalSocialMediaModel professionalSocialMediaModel = MapRegisterProfessionalSocialMedia(professionalSocialMediaId, professionalProfileId, login, professionalProfileType, socialMedia);
                _professionalSocialMediaRepository.Create(professionalSocialMediaModel);
            }

            if (!string.IsNullOrEmpty(professionalProfileViewModel.Twitter))
            {
                int professionalSocialMediaId = 0;
                ProfessionalProfileTypeEnum professionalProfileType = ProfessionalProfileTypeEnum.Twitter;
                string socialMedia = professionalProfileViewModel.Twitter;
                ProfessionalSocialMediaModel professionalSocialMediaModel = MapRegisterProfessionalSocialMedia(professionalSocialMediaId, professionalProfileId, login, professionalProfileType, socialMedia);
                _professionalSocialMediaRepository.Create(professionalSocialMediaModel);
            }
            if (!string.IsNullOrEmpty(professionalProfileViewModel.Google))
            {
                int professionalSocialMediaId = 0;
                ProfessionalProfileTypeEnum professionalProfileType = ProfessionalProfileTypeEnum.Google;
                string socialMedia = professionalProfileViewModel.Google;
                ProfessionalSocialMediaModel professionalSocialMediaModel = MapRegisterProfessionalSocialMedia(professionalSocialMediaId, professionalProfileId, login, professionalProfileType, socialMedia);
                _professionalSocialMediaRepository.Create(professionalSocialMediaModel);
            }
            if (!string.IsNullOrEmpty(professionalProfileViewModel.Instagram))
            {
                int professionalSocialMediaId = 0;
                ProfessionalProfileTypeEnum professionalProfileType = ProfessionalProfileTypeEnum.Instagram;
                string socialMedia = professionalProfileViewModel.Instagram;
                ProfessionalSocialMediaModel professionalSocialMediaModel = MapRegisterProfessionalSocialMedia(professionalSocialMediaId, professionalProfileId, login, professionalProfileType, socialMedia);
                _professionalSocialMediaRepository.Create(professionalSocialMediaModel);
            }
            if (!string.IsNullOrEmpty(professionalProfileViewModel.Linkedin))
            {
                int professionalSocialMediaId = 0;
                ProfessionalProfileTypeEnum professionalProfileType = ProfessionalProfileTypeEnum.Linkedin;
                string socialMedia = professionalProfileViewModel.Linkedin;
                ProfessionalSocialMediaModel professionalSocialMediaModel = MapRegisterProfessionalSocialMedia(professionalSocialMediaId, professionalProfileId, login, professionalProfileType, socialMedia);
                _professionalSocialMediaRepository.Create(professionalSocialMediaModel);
            }
            if (!string.IsNullOrEmpty(professionalProfileViewModel.Pinterest))
            {
                int professionalSocialMediaId = 0;
                ProfessionalProfileTypeEnum professionalProfileType = ProfessionalProfileTypeEnum.Pinterest;
                string socialMedia = professionalProfileViewModel.Pinterest;
                ProfessionalSocialMediaModel professionalSocialMediaModel = MapRegisterProfessionalSocialMedia(professionalSocialMediaId, professionalProfileId, login, professionalProfileType, socialMedia);
                _professionalSocialMediaRepository.Create(professionalSocialMediaModel);
            }
            if (!string.IsNullOrEmpty(professionalProfileViewModel.Youtube))
            {
                int professionalSocialMediaId = 0;
                ProfessionalProfileTypeEnum professionalProfileType = ProfessionalProfileTypeEnum.Youtube;
                string socialMedia = professionalProfileViewModel.Youtube;
                ProfessionalSocialMediaModel professionalSocialMediaModel = MapRegisterProfessionalSocialMedia(professionalSocialMediaId, professionalProfileId, login, professionalProfileType, socialMedia);
                _professionalSocialMediaRepository.Create(professionalSocialMediaModel);
            }
            if (!string.IsNullOrEmpty(professionalProfileViewModel.Slack))
            {
                int professionalSocialMediaId = 0;
                ProfessionalProfileTypeEnum professionalProfileType = ProfessionalProfileTypeEnum.Slack;
                string socialMedia = professionalProfileViewModel.Slack;
                ProfessionalSocialMediaModel professionalSocialMediaModel = MapRegisterProfessionalSocialMedia(professionalSocialMediaId, professionalProfileId, login, professionalProfileType, socialMedia);
                _professionalSocialMediaRepository.Create(professionalSocialMediaModel);
            }
            if (!string.IsNullOrEmpty(professionalProfileViewModel.Github))
            {
                int professionalSocialMediaId = 0;
                ProfessionalProfileTypeEnum professionalProfileType = ProfessionalProfileTypeEnum.Github;
                string socialMedia = professionalProfileViewModel.Github;
                ProfessionalSocialMediaModel professionalSocialMediaModel = MapRegisterProfessionalSocialMedia(professionalSocialMediaId, professionalProfileId, login, professionalProfileType, socialMedia);
                _professionalSocialMediaRepository.Create(professionalSocialMediaModel);
            }
            if (!string.IsNullOrEmpty(professionalProfileViewModel.Reddit))
            {
                int professionalSocialMediaId = 0;
                ProfessionalProfileTypeEnum professionalProfileType = ProfessionalProfileTypeEnum.Reddit;
                string socialMedia = professionalProfileViewModel.Reddit;
                ProfessionalSocialMediaModel professionalSocialMediaModel = MapRegisterProfessionalSocialMedia(professionalSocialMediaId, professionalProfileId, login, professionalProfileType, socialMedia);
                _professionalSocialMediaRepository.Create(professionalSocialMediaModel);
            }
            if (!string.IsNullOrEmpty(professionalProfileViewModel.Whatsapp))
            {
                int professionalSocialMediaId = 0;
                ProfessionalProfileTypeEnum professionalProfileType = ProfessionalProfileTypeEnum.Whatsapp;
                string socialMedia = professionalProfileViewModel.Whatsapp;
                ProfessionalSocialMediaModel professionalSocialMediaModel = MapRegisterProfessionalSocialMedia(professionalSocialMediaId, professionalProfileId, login, professionalProfileType, socialMedia);
                _professionalSocialMediaRepository.Create(professionalSocialMediaModel);
            }
            if (!string.IsNullOrEmpty(professionalProfileViewModel.Skype))
            {
                int professionalSocialMediaId = 0;
                ProfessionalProfileTypeEnum professionalProfileType = ProfessionalProfileTypeEnum.Skype;
                string socialMedia = professionalProfileViewModel.Skype;
                ProfessionalSocialMediaModel professionalSocialMediaModel = MapRegisterProfessionalSocialMedia(professionalSocialMediaId, professionalProfileId, login, professionalProfileType, socialMedia);
                _professionalSocialMediaRepository.Create(professionalSocialMediaModel);
            }

        }

        private ProfessionalSocialMediaModel MapRegisterProfessionalSocialMedia(int professionalSocialMediaId, int professionalProfileId, string login, ProfessionalProfileTypeEnum professionalProfileType, string socialMedia)
        {
            ProfessionalSocialMediaModel targetModel = new ProfessionalSocialMediaModel
            {
                ProfessionalSocialMediaId = professionalSocialMediaId
            ,
                ProfessionalProfileId = professionalProfileId
            ,
                ProfessionalProfileType = professionalProfileType
            ,
                SocialMedia = socialMedia
            ,
                CreatedAt = DateTime.Now
            ,
                UpdatedAt = DateTime.Now
            ,
                UserAt = login
            };

            return targetModel;
        }

        private List<ProfessionalSocialMediaModel> MapRegisterProfessionalSocialMedia(int professionalProfile)
        {
            List<ProfessionalSocialMediaModel> professionalSocialMediaList = _professionalSocialMediaRepository.GetAllByProfessionalProfile(professionalProfile);

            return professionalSocialMediaList;
        }
    }
}
