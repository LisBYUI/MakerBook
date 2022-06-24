using Microsoft.AspNetCore.Mvc;
using MakerBook.Models;
using MakerBook.Filters;
using MakerBook.Helper.Interface;
using MakerBook.Repository.Interface;
using MakerBook.ViewModels;

namespace MakerBook.Controllers
{
    [RestrictedPageAdminOnly]
    public class ProfessionalController : Controller
    {
        private readonly IProfessionalRepository _professionalRepository;
        private readonly ISessionHelper _session;

        public ProfessionalController(IProfessionalRepository professionalRepository, ISessionHelper session)
        {
            _professionalRepository = professionalRepository;
            _session = session;

        }

        // GET: Professional
        public IActionResult Index()
        {
            List<ProfessionalModel> professionalList = _professionalRepository.GetAll();

            List<ProfessionalViewModel> professionalViewList = new List<ProfessionalViewModel>();

            foreach (var professional in professionalList)
            {
                professionalViewList.Add(MapRegisterProfessionalView(professional));
            }
            return View(professionalViewList);
        }

        // GET: Professional/Details/5
        public IActionResult Details(int? id)
        {
            var professionalModel = _professionalRepository.Get(id ?? 0);

            if (professionalModel == null)
            {
                return NotFound();
            }

            var professionalViewModel = MapRegisterProfessionalView(professionalModel);

            return View(professionalViewModel);
        }

        // GET: Professional/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Professional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProfessionalViewModel professionalViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userSession = _session.GetUserSession();

                    ProfessionalModel professionalModel = MapRegisterProfessional(professionalViewModel, userSession.Login);

                    _professionalRepository.Create(professionalModel);

                    TempData["SuccessMessage"] = "Success!!!";
                    return RedirectToAction(nameof(Index));
                }
                return View(professionalViewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Professional/Edit/5
        public IActionResult Edit(int? id)
        {
            var professionalModel = _professionalRepository.Get(id ?? 0);
            if (professionalModel == null)
            {
                return NotFound();
            }

            ProfessionalViewModel professionalViewModel = MapRegisterProfessionalView(professionalModel);

            return View(professionalViewModel);
        }

        // POST: Professional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProfessionalViewModel professionalViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userSession = _session.GetUserSession();

                    ProfessionalModel professionalModel = MapRegisterProfessional(professionalViewModel, userSession.Login);

                    _professionalRepository.Update(professionalModel);

                    TempData["SuccessMessage"] = "Success!!!";
                    return RedirectToAction(nameof(Index));
                }

                return View("Editar", professionalViewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction("Index");
            }
        }

        // GET: Professional/Delete/5
        public IActionResult Delete(int? id)
        {
            var professionalModel = _professionalRepository.Get(id ?? 0);
            if (professionalModel == null)
            {
                return NotFound();
            }

            ProfessionalViewModel professionalViewModel = MapRegisterProfessionalView(professionalModel);

            return View(professionalViewModel);
        }

        // POST: Professional/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var deleteConfirmed = _professionalRepository.Delete(id);
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

        /// <summary>
        /// MapRegisterCustomerView
        /// </summary>
        /// <param name="sourceModel"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        private static ProfessionalViewModel MapRegisterProfessionalView(ProfessionalModel sourceModel)
        {
            ProfessionalViewModel targetModel = new ProfessionalViewModel
            {
                ProfessionalId = sourceModel.ProfessionalId
            ,
                Name = sourceModel.Name
            ,
                PhoneNumber = sourceModel.PhoneNumber
            ,
                Email = sourceModel.Email
            ,
                WebPage = sourceModel.WebPage
            };


            return targetModel;
        }

        /// <summary>
        /// MapRegisterUser
        /// </summary>
        /// <param name="sourceModel"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        private static ProfessionalModel MapRegisterProfessional(ProfessionalViewModel sourceModel, string login)
        {
            ProfessionalModel targetModel = new ProfessionalModel
            {
                ProfessionalId = sourceModel.ProfessionalId
            ,
                Name = sourceModel.Name
            ,
                PhoneNumber = sourceModel.PhoneNumber
            ,
                Email = sourceModel.Email
            ,
                WebPage = sourceModel.WebPage
            ,
                CreatedAt = DateTime.Now
            ,
                UpdatedAt = DateTime.Now
            ,
                UserAt = login
            };

            return targetModel;
        }
    }
}
