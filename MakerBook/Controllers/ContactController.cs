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

        // GET: Contact
        public async Task<IActionResult> Index()
        {
          List<ContactModel> contactList = _contactRepository.GetAll();
            return View(contactList);
        }

        // GET: Contact/Details/5
        public IActionResult Details(int? id)
        {

            var contactModel = _contactRepository.Get(id ?? 0);

            if (contactModel == null)
            {
                return NotFound();
            }

            return View(contactModel);
        }

        // GET: Contact/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Contact/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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
            }catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Contact/Edit/5
        public IActionResult Edit(int? id)
        {

            var contactModel = _contactRepository.Get(id??0);
            if (contactModel == null)
            {
                return NotFound();
            }
            return View(contactModel);
        }

        // POST: Contact/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,Name,Email,PhoneNumber")] ContactModel contactModel)
        {

            if (ModelState.IsValid)
            {
                ContactModel contact = _contactRepository.Update(contactModel);
                return RedirectToAction(nameof(Index));
            }

            return View("Editar", contactModel);
        }

        // GET: Contact/Delete/5
        public IActionResult Delete(int? id)
        {
            var contactModel = _contactRepository.Get(id ?? 0);
            if (contactModel == null)
            {
                return NotFound();
            }

            return View(contactModel);
        }

        // POST: Contact/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            _contactRepository.Delete(id);

            return RedirectToAction(nameof(Index));
        }

    }
}
