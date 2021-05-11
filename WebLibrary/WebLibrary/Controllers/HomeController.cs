using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.Controllers
{
    public class HomeController : Controller
    {
        IBooksRepository repo1;
        IAuthorRepository repo2;
        IGanresRepository repo3;
        public HomeController(IBooksRepository r1, IAuthorRepository r2, IGanresRepository r3)
        {
            repo1 = r1;
            repo2 = r2;
            repo3 = r3;
        }



        public IActionResult Index()
        {
            int countBook = 0;
            foreach (var item in repo1.GetBooks())
            {
                countBook++;
            }

            ViewBag.countBook = countBook;

            int countAuthor = 0;
            foreach (var item in repo2.GetBooks())
            {
                countAuthor++;
            }

            ViewBag.countAuthor = countAuthor;

            int countGanre = 0;
            foreach (var item in repo3.GetBooks())
            {
                countGanre++;
            }

            ViewBag.countGanre = countGanre;

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

    }
}
