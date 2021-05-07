using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.Controllers
{
    public class AuthorController : Controller
    {
        IAuthorRepository repo;

        public AuthorController(IAuthorRepository r)
        {
            repo = r;
        }

        public IActionResult ListOfAuther()
        {
            return View(repo.GetBooks());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(AuthorStaroseletsEV book)
        {
            repo.Create(book);
            return RedirectToAction("ListOfAuther");
        }

        public ActionResult Edit(int id)
        {
            AuthorStaroseletsEV book = repo.Get(id);
            if (book != null)
                return View(book);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(AuthorStaroseletsEV book)
        {
            repo.Update(book);
            return RedirectToAction("ListOfAuther");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            AuthorStaroseletsEV book = repo.Get(id);
            if (book != null)
                return View(book);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("ListOfAuther");
        }

    }
}
