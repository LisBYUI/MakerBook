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

        // GET: ProfessionalProfileViewModel
        public IActionResult Index()
        {
            var professionalProfile = _professionalProfileRepository.GetAll();
     
            return View(professionalProfile);
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
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProfessionalProfileViewModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProfessionalProfileViewModel ProfessionalProfileViewModel)
        {
            try
            {
                //string nomeArquivoImagem = ProcessaUploadedFile(ProfessionalProfileViewModel);
                //if (ModelState.IsValid)
                //{
                    MemoryStream ms  = new MemoryStream();
                //    ProfessionalProfileViewModel.ImageProfile.OpenReadStream().CopyTo(ms);

                //    var userSession = _session.GetUserSession();
                //    ProfessionalProfileViewModel.CreatedAt = DateTime.Now;
                //ProfessionalProfileViewModel.UpdatedAt = DateTime.Now;
                //    if (userSession != null)
                //        ProfessionalProfileViewModel.UserAt = userSession.Login;

                //    ProfessionalProfileViewModel.Image = ms.ToArray();
                //    _categoryRepository.Create(ProfessionalProfileViewModel);

                    TempData["SuccessMessage"] = "Success!!!";
                    return RedirectToAction(nameof(Index));
                //}
                return View(ProfessionalProfileViewModel);
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

       
    }
}
