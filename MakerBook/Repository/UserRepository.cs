﻿using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;

namespace MakerBook.Repository
{
    public class UserRepository : IUserRepository
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Constructor - UserRepository
        /// </summary>
        /// <param name="context"></param>
        public UserRepository(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UserModel Get(int id)
        {
            return _context.User.FirstOrDefault(i => i.UserId == id);
        }

        public UserModel GetByLogin(string login)
        {
            return _context.User.FirstOrDefault(x => x.Email.ToLower() == login.ToLower());
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public List<UserModel> GetAll()
        {
            return _context.User.ToList();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        public UserModel Create(UserModel userModel)
        {
            userModel.SetPasswordHash();

            _context.User.Add(userModel);
            _context.SaveChanges();

            return userModel;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public UserModel Update(UserModel userModel)
        {
            UserModel userDb = Get(userModel.UserId);
            if (userDb == null)
                throw new Exception("Record not Found");
            userDb.FirstName = userModel.FirstName;
            userDb.LastName = userModel.LastName;
            userDb.Login = userModel.Login;
            userDb.Email = userModel.Email;
            userDb.Profile = userModel.Profile;
            userDb.UpdatedAt = userModel.UpdatedAt;
            userDb.UserAt = userModel.UserAt;

            _context.User.Update(userDb);
            _context.SaveChanges();

            return userDb;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            UserModel userDb = Get(id);
            if (userDb == null)
                throw new Exception("Record not Found");

            _context.User.Remove(userDb);
            _context.SaveChanges();

            return true;
        }

        public UserModel GetByEmailLogin(string email, string login)
        {
            return _context.User.FirstOrDefault(x => x.Email.ToLower() == email.ToLower() && x.Login.ToLower() == login.ToLower());
        }
        public UserModel GetByEmail(string email)
        {
            return _context.User.FirstOrDefault(x => x.Email.ToLower() == email.ToLower());
        }
    }
}
