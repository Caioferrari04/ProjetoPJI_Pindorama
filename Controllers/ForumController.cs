using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Controllers
{
    public class ForumController : Controller
    {   
        public IActionResult Index()
        {
            return View();
        }
    }
}
