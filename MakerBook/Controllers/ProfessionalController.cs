using Microsoft.AspNetCore.Mvc;
using MakerBook.Models;
using MakerBook.Filters;
using MakerBook.Helper.Interface;
using MakerBook.Repository.Interface;

namespace MakerBook.Controllers
{
    [RestrictedPageAdminOnly]
    public class ProfessionalController : Controller
    {
        private readonly IProfessionalRepository _professionalRepository;
        private readonly ISessionHelper _session;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProfessionalController(IProfessionalRepository professionalRepository, ISessionHelper session)
        {
            _professionalRepository = professionalRepository;
            _session = session;
           
        }

        // GET: Professional
        public async Task<IActionResult> Index()
        {
            List<ProfessionalModel> ProfessionalList = _professionalRepository.GetAll();

            return View(ProfessionalList);
        }

        // GET: Professional/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var ProfessionalModel = _professionalRepository.Get(id ?? 0);

            if (ProfessionalModel == null)
            {
                return NotFound();
            }

            return View(ProfessionalModel);
        }

        // GET: Professional/Create
        public IActionResult Create()
        {
            //ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId");
            return View();
        }

        // POST: Professional/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ProfessionalModel ProfessionalModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["SuccessMessage"] = "Success!!!";
                    _professionalRepository.Create(ProfessionalModel);
                    return RedirectToAction(nameof(Index));
                }
                return View(ProfessionalModel);
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
            var ProfessionalModel = _professionalRepository.Get(id ?? 0);
            if (ProfessionalModel == null)
            {
                return NotFound();
            }
            return View(ProfessionalModel);
        }

        // POST: Professional/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ProfessionalModel ProfessionalModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProfessionalModel Professional = _professionalRepository.Update(ProfessionalModel);
                    TempData["SuccessMessage"] = "Success!!!";
                    return RedirectToAction(nameof(Index));
                }

                return View("Editar", ProfessionalModel);
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
            var ProfessionalModel = _professionalRepository.Get(id ?? 0);
            if (ProfessionalModel == null)
            {
                return NotFound();
            }

            return View(ProfessionalModel);
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

       
    }
}
