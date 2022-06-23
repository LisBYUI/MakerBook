﻿using MakerBook.Models;

namespace MakerBook.Repository.Interface
{
    public interface IServiceRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        ServiceModel Get(int id);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        List<ServiceModel> GetAll();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="ServiceModel"></param>
        /// <returns></returns>
        ServiceModel Create(ServiceModel serviceModel);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="ServiceModel"></param>
        /// <returns></returns>
        ServiceModel Update(ServiceModel serviceModel);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
