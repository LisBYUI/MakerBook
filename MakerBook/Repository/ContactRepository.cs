﻿using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;

namespace MakerBook.Repository
{
    public class ContactRepository: IContactRepository
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Constructor - ContactRepository
        /// </summary>
        /// <param name="context"></param>
        public ContactRepository(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ContactModel Get(int id)
        {
            return _context.Contact.FirstOrDefault(i => i.Id == id);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public List<ContactModel> GetAll()
        {
            return _context.Contact.ToList();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="contactModel"></param>
        /// <returns></returns>
        public ContactModel Create(ContactModel contactModel)
        {
            _context.Contact.Add(contactModel);
            _context.SaveChanges();

            return contactModel;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="contactModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public ContactModel Update(ContactModel contactModel)
        {
            ContactModel contactDb = Get(contactModel.Id);
            if (contactDb == null)
                throw new Exception("Record not Found");
            contactDb.Name = contactModel.Name;
            contactDb.Email = contactModel.Email;

            _context.Contact.Update(contactDb);
            _context.SaveChanges();

            return contactDb;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            ContactModel contactDb = Get(id);
            if (contactDb == null)
                throw new Exception("Record not Found");

            _context.Contact.Remove(contactDb);
            _context.SaveChanges();

            return true;
        } 
    }
}
