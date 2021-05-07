using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.Controllers
{
    public class ListController : Controller
    {
        IBooksRepository repo;

        public ListController(IBooksRepository r)
        {
            repo = r;
        }

        public IActionResult ListOfBooks()
        {
            return View(repo.GetBooks());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(BooksStaroseletsEV book)
        {
            repo.Create(book);
            return RedirectToAction("ListOfBooks");
        }

        public ActionResult Edit(int id)
        {
            BooksStaroseletsEV book = repo.Get(id);
            if (book != null)
                return View(book);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(BooksStaroseletsEV book)
        {
            repo.Update(book);
            return RedirectToAction("ListOfBooks");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            BooksStaroseletsEV book = repo.Get(id);
            if (book != null)
                return View(book);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("ListOfBooks");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
