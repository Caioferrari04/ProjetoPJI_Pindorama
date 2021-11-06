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
    public class SuporteController : Controller
    {
        AuthService auth;
        GamesService service;
        public SuporteController(AuthService auth, GamesService service)
        {
            this.auth = auth;
            this.service = service;
        }

        public IActionResult Index()
        {
            if (auth.ValidateToken())
            {
                Token token = auth.GetCurrentToken();
                ViewBag.currentUser = auth.GetCurrentToken();
                return View(service.GetAllOwnedGames(token));
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
