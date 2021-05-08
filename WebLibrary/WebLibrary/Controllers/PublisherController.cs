using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.Controllers
{
    public class PublisherController : Controller
    {
        IPublisherRepository repo;

        public PublisherController(IPublisherRepository r)
        {
            repo = r;
        }

        public IActionResult ListOfPublisher()
        {
            return View(repo.GetBooks());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(PublisherStaroseletsEV book)
        {
            repo.Create(book);
            return RedirectToAction("ListOfPublisher");
        }

        public ActionResult Edit(int id)
        {
            PublisherStaroseletsEV book = repo.Get(id);
            if (book != null)
                return View(book);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(PublisherStaroseletsEV book)
        {
            repo.Update(book);
            return RedirectToAction("ListOfPublisher");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            PublisherStaroseletsEV book = repo.Get(id);
            if (book != null)
                return View(book);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("ListOfPublisher");
        }

    }
}
