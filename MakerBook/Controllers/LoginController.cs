
using MakerBook.Enum;
using MakerBook.Helper.Interface;
using MakerBook.Models;
using MakerBook.Repository.Interface;
using MakerBook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MakerBook.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUserRepository _userRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IProfessionalRepository _professionalRepository;
        private readonly ISessionHelper _session;
        private readonly IEmail _email;

        public LoginController(IUserRepository userRepository,
            ICustomerRepository customerRepository,
            IProfessionalRepository professionalRepository,
                               ISessionHelper session,
                               IEmail email)
        {
            _userRepository = userRepository;
            _customerRepository = customerRepository;
            _professionalRepository = professionalRepository;
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
        public IActionResult Login(LoginViewModel loginModel)
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
        public IActionResult SendLinkToResetPassword(RecoverPasswordViewModel recoverPasswordModel)
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

                        bool emailSent = _email.Send(user.Email, "Do It Local - New Password", message);

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

        public IActionResult RegisterCustomer()
        {
            return View();
        }

        public IActionResult RegisterProfessional()
        {
            return View();
        }

        [HttpPost]
        public IActionResult RegisterCustomer(UserCustomerViewModel userCustomerViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userModel = _userRepository.GetByEmail(userCustomerViewModel.Email);
                    if (userModel == null)
                    {
                        userModel = MapRegisterUserCustomer(userCustomerViewModel);
                        _userRepository.Create(userModel);

                        var customerModel = MapRegisterCustomer(userCustomerViewModel);


                        _customerRepository.Create(customerModel);

                        TempData["SuccessMessage"] = "Success!!!";

                        return RedirectToAction("Login", "Login");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "There is already a registered user with this email.";
                        return RedirectToAction("Index", "Login");
                    }
                }
                return View(userCustomerViewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }


        [HttpPost]
        public IActionResult RegisterProfessional(UserProfessionalViewModel userProfessionalViewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var userModel = _userRepository.GetByEmail(userProfessionalViewModel.Email);
                    if (userModel == null)
                    {
                        userModel = MapRegisterUserProfessional(userProfessionalViewModel);
                        _userRepository.Create(userModel);

                        var professionalModel = MapRegisterProfessional(userProfessionalViewModel);


                        _professionalRepository.Create(professionalModel);

                        TempData["SuccessMessage"] = "Success!!!";

                        return RedirectToAction("Login", "Login");
                    }
                    else
                    {
                        TempData["ErrorMessage"] = "There is already a registered user with this email.";
                        return RedirectToAction("Index", "Login");
                    }
                }
                return View(userProfessionalViewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction(nameof(Index));
            }

            return View();
        }
        private static UserModel MapRegisterUserCustomer(UserCustomerViewModel sourceModel)
        {
            UserModel targetModel = new UserModel
            {
                UserId = 0
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
                Profile = ProfileEnum.Customer
            ,
                CreatedAt = DateTime.Now
            ,
                UpdatedAt = DateTime.Now
            ,
                UserAt = sourceModel.Login
            };


            return targetModel;
        }

        private static UserModel MapRegisterUserProfessional(UserProfessionalViewModel sourceModel)
        {
            UserModel targetModel = new UserModel
            {
                UserId = 0
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
                Profile = ProfileEnum.Professional
            ,
                CreatedAt = DateTime.Now
            ,
                UpdatedAt = DateTime.Now
            ,
                UserAt = sourceModel.Login
            };


            return targetModel;
        }

        private static CustomerModel MapRegisterCustomer(UserCustomerViewModel sourceModel)
        {
            CustomerModel targetModel = new CustomerModel
            {
                CustomerId = 0
            ,
                Name = $"{sourceModel.FirstName} {sourceModel.LastName}"
            ,
                Email = sourceModel.Email
            ,
                PhoneNumber = sourceModel.PhoneNumber
            ,
                CreatedAt = DateTime.Now
            ,
                UpdatedAt = DateTime.Now
            ,
                UserAt = sourceModel.Login

            };


            return targetModel;
        }


        private static ProfessionalModel MapRegisterProfessional(UserProfessionalViewModel sourceModel)
        {
            ProfessionalModel targetModel = new ProfessionalModel
            {
                ProfessionalId = 0
            ,
                Name = $"{sourceModel.FirstName} {sourceModel.LastName}"
            ,
                Email = sourceModel.Email
            ,
                PhoneNumber = sourceModel.PhoneNumber
            ,
                WebPage = sourceModel.WebPage
            ,
                CreatedAt = DateTime.Now
            ,
                UpdatedAt = DateTime.Now
            ,
                UserAt = sourceModel.Login

            };


            return targetModel;
        }
    }
}
