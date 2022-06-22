
using MakerBook.Helper.Interface;
using MakerBook.Models;
using MakerBook.Repository.Interface;
using MakerBook.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

namespace MakerBook.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Customer()
        {
            return View();
        }

        public IActionResult Professional()
        {
            return View();
        }
    }
}
