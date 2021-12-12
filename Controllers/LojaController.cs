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

        public async Task<IActionResult> Index()
        {
            ViewBag.Amigos = await auth.getAmigosAsync();
            ViewBag.Pendentes = await auth.GetPendentesAsync();
            ViewBag.categorias = catService.getAll();
            return View(service.GetAll());
        }

        public async Task<IActionResult> ReadSingle(int? id)
        {
            ViewBag.Amigos = await auth.getAmigosAsync();
            ViewBag.Pendentes = await auth.GetPendentesAsync();
            Game game = service.GetGameById(id);
            return game is null ? RedirectToAction(nameof(Index)) : View(game); 
        }

        public async Task<IActionResult> Buy(int? id)
        {
            ViewBag.Amigos = await auth.getAmigosAsync();
            ViewBag.Pendentes = await auth.GetPendentesAsync();
            return await service.BuyGame(service.GetGameById(id)) ? RedirectToAction(nameof(CompraConfirmada)) : RedirectToAction(nameof(ReadSingle));
        }

        public async Task<IActionResult> ReadCategory(int? id, int? pagina = null)
        {
            ViewBag.Amigos = await auth.getAmigosAsync();
            ViewBag.Pendentes = await auth.GetPendentesAsync();
            var categoria = catService.getSingle(id);
            ViewBag.categoria = categoria;
            pagina = pagina is null ? 1 : pagina;
            ViewBag.Pagina = pagina;
            ViewBag.Paginas = await service.GetQuantidadePaginasAsync(categoria);
            return View(service.GetAll(categoria, pagina));
        }

        public async Task<IActionResult> CategorySearch(string nome, int categoria)
        {
            if (string.IsNullOrWhiteSpace(nome)) return RedirectToAction(nameof(ReadCategory), categoria);
            ViewBag.Amigos = await auth.getAmigosAsync();
            ViewBag.Pendentes = await auth.GetPendentesAsync();
            Categoria catValido = catService.getSingle(categoria);
            ViewBag.categoria = catValido;
            return View(await service.SearchGamesInCategoryAsync(nome, catValido));
        }

        public async Task<IActionResult> CompraConfirmada()
        {
            ViewBag.Amigos = await auth.getAmigosAsync();
            ViewBag.Pendentes = await auth.GetPendentesAsync();
            return View();
        }
    }
}
