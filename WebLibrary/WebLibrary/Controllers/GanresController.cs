using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLibrary.Controllers
{
    public class GanresController : Controller
    {
        public IActionResult ListOfGanres()
        {
            return View();
        }
    }
}
