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
    public class LojaController : Controller
    {
        AuthService auth;
        GamesService service;
        CategoriasService catService;
        public LojaController(AuthService auth,GamesService service, CategoriasService catService)
        {
            this.auth = auth;
            this.service = service;
            this.catService = catService;
        }

        public IActionResult Index() {
            if (auth.ValidateToken()) { 
                ViewBag.categorias = catService.getAll();
                ViewBag.currentUser = auth.GetCurrentToken();
                return View(service.GetAll());
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult ReadSingle(int? id)
        {
            if (auth.ValidateToken()) 
            {
                ViewBag.currentUser = auth.GetCurrentToken();
                Game game = service.Get(id);
                return game == null ? RedirectToAction(nameof(Index)) : View(game); 
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult Buy(int? id)
        {
            if (auth.ValidateToken()) { 
                ViewBag.currentUser = auth.GetCurrentToken();
                return service.BuyGame(ViewBag.currentUser, service.Get(id)) ? RedirectToAction("Index", "Library", new { area = "" }) : RedirectToAction(nameof(ReadSingle));
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }

        public IActionResult ReadCategory(int? id)
        {
            if (auth.ValidateToken())
            {
                ViewBag.currentUser = auth.GetCurrentToken();
                var categoria = catService.getSingle(id);
                ViewBag.categoria = categoria;
                return View(service.GetAll(categoria));
            }
            return RedirectToAction("Index", "Home", new { area = "" });
        }
    }
}
