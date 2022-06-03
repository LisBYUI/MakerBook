﻿using MakerBook.Models;

namespace MakerBook.Repository.Interface
{
    public interface IContactRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ContactModel Get(int id);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        List<ContactModel> GetAll();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="contactModel"></param>
        /// <returns></returns>
        ContactModel Create(ContactModel contactModel);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="contactModel"></param>
        /// <returns></returns>
        ContactModel Update(ContactModel contactModel);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}