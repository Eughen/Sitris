using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebLibrary.Models;

namespace WebLibrary.Controllers
{
    public class GanresController : Controller
    {
        IGanresRepository repo;

        public GanresController(IGanresRepository r)
        {
            repo = r;
        }

        public IActionResult ListOfGanres()
        {
            return View(repo.GetBooks());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(GanresStaroseletsEV book)
        {
            repo.Create(book);
            return RedirectToAction("ListOfGanres");
        }

        public ActionResult Edit(int id)
        {
            GanresStaroseletsEV book = repo.Get(id);
            if (book != null)
                return View(book);
            return NotFound();
        }

        [HttpPost]
        public ActionResult Edit(GanresStaroseletsEV book)
        {
            repo.Update(book);
            return RedirectToAction("ListOfGanres");
        }

        [HttpGet]
        [ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            GanresStaroseletsEV book = repo.Get(id);
            if (book != null)
                return View(book);
            return NotFound();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            repo.Delete(id);
            return RedirectToAction("ListOfGanres");
        }
    }
}
