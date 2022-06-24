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
using MakerBook.Filters;
using MakerBook.ViewModels;
using MakerBook.Helper.Interface;

namespace MakerBook.Controllers
{
    [RestrictedPageAdminOnly]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionHelper _session;

        /// <summary>
        /// UserController
        /// </summary>
        /// <param name="userRepository"></param>
        /// <param name="session"></param>
        public UserController(IUserRepository userRepository, ISessionHelper session)
        {
            _userRepository = userRepository;
            _session = session;
        }


        /// <summary>
        /// GET: User
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            List<UserModel> userList = _userRepository.GetAll();
            List<UserViewModel> userViewList = new List<UserViewModel>();

            foreach(var user in userList)
            {
                userViewList.Add(MapRegisterUserView(user));
            }

            return View(userViewList);
        }


        /// <summary>
        /// GET: User/Details/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Details(int? id)
        {
            var userModel = _userRepository.Get(id ?? 0);

            if (userModel == null)
            {
                return NotFound();
            }

           var userViewModel  = MapRegisterUserView(userModel);
            return View(userViewModel);
        }


        /// <summary>
        /// GET: User/Create
        /// </summary>
        /// <returns></returns>
        public IActionResult Create()
        {
            return View();
        }

        /// <summary>
        /// POST: User/Create
        /// </summary>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(UserViewModel userViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userSession = _session.GetUserSession();

                    UserModel userModel = MapRegisterUser(userViewModel,userSession.Login);

                    _userRepository.Create(userModel);
                    return RedirectToAction(nameof(Index));

                    TempData["SuccessMessage"] = "Success!!!";
                }
                return View(userViewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction(nameof(Index));
            }
        }


        /// <summary>
        /// GET: User/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Edit(int? id)
        {
            var userModel = _userRepository.Get(id ?? 0);
            if (userModel == null)
            {
                return NotFound();
            }
            UserViewModel userViewModel = MapRegisterUserView(userModel);

            return View(userViewModel);
        }

        /// <summary>
        /// POST: User/Edit/5
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userModel"></param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, UserViewModel userViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userSession = _session.GetUserSession();

                    UserModel userModel = MapRegisterUser(userViewModel, userSession.Login);

                    UserModel contact = _userRepository.Update(userModel);
                    TempData["SuccessMessage"] = "Success!!!";
                    return RedirectToAction(nameof(Index));
                }

                return View("Edit", userViewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction("Index");
            }
        }

        /// <summary>
        /// GET: User/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public IActionResult Delete(int? id)
        {
            var userModel = _userRepository.Get(id ?? 0);
            if (userModel == null)
            {
                return NotFound();
            }

            UserViewModel userViewModel = MapRegisterUserView(userModel);
            return View(userViewModel);
        }


        /// <summary>
        /// POST: User/Delete/5
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var deleteConfirmed = _userRepository.Delete(id);
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
        /// MapRegisterUserView
        /// </summary>
        /// <param name="sourceModel"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        private static UserViewModel MapRegisterUserView(UserModel sourceModel)
        {
            UserViewModel targetModel = new UserViewModel
            {
                UserId = sourceModel.UserId
            ,
                FirstName = sourceModel.FirstName
            ,
                LastName = sourceModel.LastName
            ,
                Login = sourceModel.Login
            ,
                Email = sourceModel.Email
            ,
                Password = sourceModel.Password
            ,
                Profile = sourceModel.Profile
            };


            return targetModel;
        }

        /// <summary>
        /// MapRegisterUser
        /// </summary>
        /// <param name="sourceModel"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        private static UserModel MapRegisterUser(UserViewModel sourceModel, string login)
        {
            UserModel targetModel = new UserModel
            {
                UserId = sourceModel.UserId
            ,
                FirstName = sourceModel.FirstName
            ,
                LastName = sourceModel.LastName
            ,
                Login = sourceModel.Login
            ,
                Email = sourceModel.Email
            ,
                Password = sourceModel.Password
            ,
                Profile = sourceModel.Profile
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
