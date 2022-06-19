﻿
using MakerBook.Helper.Interface;
using MakerBook.Models;
using MakerBook.Repository.Interface;
using Microsoft.AspNetCore.Mvc;
using System;

namespace ControleDeContatos.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ISessionHelper _session;
        private readonly IEmail _email;

        public LoginController(IUserRepository userRepository,
                               ISessionHelper session,
                               IEmail email)
        {
            _userRepository = userRepository;
            _session = session;
            _email = email;
        }

        public IActionResult Index()
        {
            
            if (_session.GetUserSession() != null) return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Logout()
        {
            _session.DeleteUserSession();

            return RedirectToAction("Index", "Login");
        }

        [HttpPost]
        public IActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.GetByLogin(loginModel.Login);

                    if (user != null)
                    {
                        if (true)//(user.ValidPassword(loginModel.Password))
                        {
                            _session.CreateUserSession(user);
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["ErrorMessage"] = $"User password is invalid, please try again.";
                    }

                    TempData["ErrorMessage"] = $"Invalid username and/or password(s). Please try again.";
                }

                return View("Index");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Login failed, try again, error detail: {ex.Message}";
                return RedirectToAction("Index");
            }
        }


    }
}
