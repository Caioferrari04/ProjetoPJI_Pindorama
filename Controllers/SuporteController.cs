using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pindorama.Auth;
using Pindorama.Models;
using Pindorama.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Controllers
{
    [Authorize]
    public class SuporteController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
