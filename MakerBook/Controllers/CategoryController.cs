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
    [RestrictedPageAdminOnly]
    public class CategoryController : Controller
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ISessionHelper _session;


        public CategoryController(ICategoryRepository categoryRepository, ISessionHelper session)
        {
            _categoryRepository = categoryRepository;
            _session = session;
        }

        // GET: CategoryModel
        public IActionResult Index()
        {
            List<CategoryModel> categoryList = _categoryRepository.GetAll();
            List<CategoryViewModel> categoryViewList = new List<CategoryViewModel>();

            foreach (var item in categoryList)
            {
                categoryViewList.Add(MapRegisterCategoryView(item));
            }

            return View(categoryViewList);
        }

        // GET: CategoryModel/Details/5
        public IActionResult Details(int? id)
        {
            var categoryModel = _categoryRepository.Get(id ?? 0);

            if (categoryModel == null)
            {
                return NotFound();
            }

            var categoryViewModel = MapRegisterCategoryView(categoryModel);

            return View(categoryViewModel);
        }

        // GET: CategoryModel/Create
        public IActionResult Create()
        {
            var categoryViewModel = new CategoryViewModel();
            return View(categoryViewModel);
        }

        // POST: CategoryModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CategoryViewModel categoryViewModel)
        {
            try
            {
                var userSession = _session.GetUserSession();

                MemoryStream ms = new MemoryStream();
                categoryViewModel.ImageCategory.OpenReadStream().CopyTo(ms);

                var categoryModel = MapRegisterCategory(categoryViewModel, userSession.Login, ms.ToArray(), categoryViewModel.ImageCategory.FileName, categoryViewModel.ImageCategory.ContentType);

                _categoryRepository.Create(categoryModel);

                TempData["SuccessMessage"] = "Success!!!";
                return RedirectToAction(nameof(Index));

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

            var categoryViewModel = MapRegisterCategoryView(categoryModel);

            return View(categoryViewModel);
        }

        // POST: CategoryModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CategoryViewModel categoryViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userSession = _session.GetUserSession();

                    byte[] file;
                    var filename = string.Empty;
                    var extension = string.Empty;

                    if (categoryViewModel.ImageCategory != null)
                    {
                        MemoryStream ms = new MemoryStream();
                        categoryViewModel.ImageCategory.OpenReadStream().CopyTo(ms);
                        file = ms.ToArray();
                        filename = categoryViewModel.ImageCategory.FileName;
                        extension = categoryViewModel.ImageCategory.ContentType;
                    }
                    else
                    {
                        var categoryAux = _categoryRepository.Get(id);
                        file = categoryAux.Image;
                        filename = categoryAux.ImageName;
                        extension = categoryAux.ImageExtension;
                    }
                    var categoryModel = MapRegisterCategory(categoryViewModel, userSession.Login, file, filename, extension);

                    CategoryModel category = _categoryRepository.Update(categoryModel);
                    TempData["SuccessMessage"] = "Success!!!";

                    return RedirectToAction(nameof(Index));
                }

                return View("Edit", categoryViewModel);
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

            var categoryViewModel = MapRegisterCategoryView(categoryModel);

            return View(categoryViewModel);
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

        /// <summary>
        /// MapRegisterServiceView
        /// </summary>
        /// <param name="sourceModel"></param>
        /// <returns></returns>
        private CategoryViewModel MapRegisterCategoryView(CategoryModel sourceModel)
        {
            var stream = new MemoryStream(sourceModel.Image);
            IFormFile file = new FormFile(stream, 0, stream.Length, sourceModel.ImageName, sourceModel.ImageExtension);

            CategoryViewModel targetModel = new CategoryViewModel
            {
                CategoryId = sourceModel.CategoryId
            ,
                Name = sourceModel.Name
            ,
                Description = sourceModel.Description
            ,
                Image = sourceModel.Image
                ,
                ImageName = sourceModel.ImageName
                ,
                ImageExtension = sourceModel.ImageExtension

        ,
                ImageCategory = file
            };

            return targetModel;
        }

        /// <summary>
        /// MapRegisterCategory
        /// </summary>
        /// <param name="sourceModel"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        private CategoryModel MapRegisterCategory(CategoryViewModel sourceModel, string login, byte[] Image, string filename, string extension)
        {
            CategoryModel targetModel = new CategoryModel
            {
                CategoryId = sourceModel.CategoryId
            ,
                Name = sourceModel.Name
            ,
                Description = sourceModel.Description
            ,
                Image = Image
                 ,
                ImageName = filename
                 ,
                ImageExtension = extension
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
