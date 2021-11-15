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
            ViewBag.categorias = catService.getAll();
            return View(service.GetAll());
        }

        public IActionResult ReadSingle(int? id)
        {
            Game game = service.Get(id);
            return game == null ? RedirectToAction(nameof(Index)) : View(game); 
        }

        public async Task<IActionResult> Buy(int? id)
        {
            return await service.BuyGame(service.Get(id)) ? RedirectToAction(nameof(CompraConfirmada)) : RedirectToAction(nameof(ReadSingle));
        }

        public IActionResult ReadCategory(int? id)
        {
            var categoria = catService.getSingle(id);
            ViewBag.categoria = categoria;
            return View(service.GetAll(categoria));
        }

        public IActionResult CompraConfirmada()
        {
            return View();
        }
    }
}
