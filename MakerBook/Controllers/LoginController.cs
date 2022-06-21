
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
            
            if (_session.GetUserSession() != null) 
                return RedirectToAction("Index", "Home");

            return View();
        }

        public IActionResult Logout()
        {
            _session.DeleteUserSession();

            return RedirectToAction("Index", "Login");
        }

        public IActionResult Login()
        {

            if (_session.GetUserSession() != null)
                return RedirectToAction("Index", "Home");

            return View();
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

        public IActionResult RecoverPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendLinkToResetPassword(RecoverPasswordModel recoverPasswordModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UserModel user = _userRepository.GetByEmailLogin(recoverPasswordModel.Email, recoverPasswordModel.Login);

                    if (user != null)
                    {
                        string newPassword = user.GenerateNewPassword();

                        string message = $"New passoword is: {newPassword}";

                        bool emailSent = _email.Send(user.Email, "MakerBook - New Password", message);

                        if (emailSent)
                        {
                            _userRepository.Update(user);
                            TempData["SuccessMessage"] = $"A new password has been sent to the registered email.";

                        }
                        else
                        {
                            TempData["ErrorMessage"] = $"Your password could not be reset. Please check the information provided..";

                        }
                        return RedirectToAction("Index", "Login");
                    }
                       
                        TempData["ErrorMessage"] = $"Your password could not be reset. Please check the information provided..";
                }

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["ErrorMessage"] = $"Could not reset your password, please try again, error detail: {erro.Message}";
                return RedirectToAction("Index");
            }
        }

        public IActionResult Register()
        {
            return View();
        }
    }
}
