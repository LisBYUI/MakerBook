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

namespace MakerBook.Controllers
{
    public class ContactController : Controller
    {
        private readonly IContactRepository _contactRepository;

        public ContactController(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        /// <summary>
        /// GET: Contact
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<ContactModel> contactList = _contactRepository.GetAll();
            return View(contactList);
        }

        /// <summary>
        /// GET: Contact/Details/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int? id)
        {

            var contactModel = _contactRepository.Get(id ?? 0);

            if (contactModel == null)
            {
                return NotFound();
            }

            return View(contactModel);
        }

        /// <summary>
        /// GET: Contact/Create
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: Contact/Create
        /// </summary>
        /// <param name="contactModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name,Email,PhoneNumber")] ContactModel contactModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    TempData["SuccessMessage"] = "Success!!!";
                    _contactRepository.Create(contactModel);
                    return RedirectToAction(nameof(Index));
                }
                return View(contactModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction(nameof(Index));
            }
        }

        /// <summary>
        /// GET: Contact/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {
            var contactModel = _contactRepository.Get(id ?? 0);
            if (contactModel == null)
            {
                return NotFound();
            }
            return View(contactModel);
        }

        /// <summary>
        /// POST: Contact/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="contactModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Email,PhoneNumber")] ContactModel contactModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ContactModel contact = _contactRepository.Update(contactModel);
                    TempData["SuccessMessage"] = "Success!!!";
                    return RedirectToAction(nameof(Index));
                }

                return View("Editar", contactModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// GET: Contact/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            var contactModel = _contactRepository.Get(id ?? 0);
            if (contactModel == null)
            {
                return NotFound();
            }

            return View(contactModel);
        }


        /// <summary>
        /// POST: Contact/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var deleteConfirmed = _contactRepository.Delete(id);
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
