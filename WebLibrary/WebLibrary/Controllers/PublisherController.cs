using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebLibrary.Controllers
{
    public class PublisherController : Controller
    {
        public IActionResult ListOfPublisher()
        {
            return View();
        }
    }
}
