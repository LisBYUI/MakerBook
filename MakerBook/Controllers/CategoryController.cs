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

namespace MakerBook.Controllers
{
    [RestrictedPageAdminOnly]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISessionHelper _session;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public CategoryController(ICategoryRepository categoryRepository, ISessionHelper session, IWebHostEnvironment webHostEnvironment)
        {
            _categoryRepository = categoryRepository;
            _session = session;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: CategoryModel
        public IActionResult Index()
        {
            List<CategoryModel> categoryList = _categoryRepository.GetAll();
     
            return View(categoryList);
        }

        // GET: CategoryModel/Details/5
        public IActionResult Details(int? id)
        {
            var categoryModel = _categoryRepository.Get(id ?? 0);

            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        // GET: CategoryModel/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CategoryModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryModel categoryModel)
        {
            try
            {
                //string nomeArquivoImagem = ProcessaUploadedFile(categoryModel);
                //if (ModelState.IsValid)
                //{
                    MemoryStream ms  = new MemoryStream();
                    categoryModel.ImageCategory.OpenReadStream().CopyTo(ms);

                    var userSession = _session.GetUserSession();
                    categoryModel.CreatedAt = DateTime.Now;
                categoryModel.UpdatedAt = DateTime.Now;
                    if (userSession != null)
                        categoryModel.UserAt = userSession.Login;

                    categoryModel.Image = ms.ToArray();
                    _categoryRepository.Create(categoryModel);

                    TempData["SuccessMessage"] = "Success!!!";
                    return RedirectToAction(nameof(Index));
                //}
                return View(categoryModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: CategoryModel/Edit/5
        public IActionResult Edit(int? id)
        {
            var categoryModel = _categoryRepository.Get(id ?? 0);
            if (categoryModel == null)
            {
                return NotFound();
            }
            return View(categoryModel);
        }

        // POST: CategoryModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CategoryModel categoryModel)
        {
            try
            {
                //if (ModelState.IsValid)
                //{
                    var userSession = _session.GetUserSession();
                    MemoryStream ms = new MemoryStream();
                    categoryModel.ImageCategory.OpenReadStream().CopyTo(ms);

                    categoryModel.UpdatedAt = DateTime.Now;
                    if (userSession != null)
                        categoryModel.UserAt = userSession.Login;

                    categoryModel.Image = ms.ToArray();

                    CategoryModel category = _categoryRepository.Update(categoryModel);
                    TempData["SuccessMessage"] = "Success!!!";
                    return RedirectToAction(nameof(Index));
                //}

                return View("Edit", categoryModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction("Index");
            }
        }

        // GET: CategoryModel/Delete/5
        public IActionResult Delete(int? id)
        {
            var categoryModel = _categoryRepository.Get(id ?? 0);
            if (categoryModel == null)
            {
                return NotFound();
            }

            return View(categoryModel);
        }

        // POST: CategoryModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var deleteConfirmed = _categoryRepository.Delete(id);
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

        private string ProcessaUploadedFile(CategoryModel model)
        {
            string nomeArquivoImagem = null;

            if (model.ImageCategory != null)
            {
                string uploadsFolder = Path.Combine(_webHostEnvironment.WebRootPath, "Uploads");
                nomeArquivoImagem = Guid.NewGuid().ToString() + "_" + model.ImageCategory.FileName;
                string filePath = Path.Combine(uploadsFolder, nomeArquivoImagem);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    model.ImageCategory.CopyTo(fileStream);
                }
            }
            return nomeArquivoImagem;
        }
    }
}
