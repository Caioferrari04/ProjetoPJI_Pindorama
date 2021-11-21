using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pindorama.Auth;
using Pindorama.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Controllers
{
    public class HomeController : Controller
    {
        AuthService authService;
        public HomeController(AuthService authService)
        {
            this.authService = authService;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Amigos(string nome)
        {
            ViewBag.Amigos = await authService.getAmigosAsync();
            ViewBag.semiAmigos = await authService.GetPendentesAsync();
            return View(authService.SearchUsers(nome));
        }

        public async Task<IActionResult> ListaAmigos() 
        {
            ViewBag.Amigos = await authService.getAmigosAsync();
            return View(ViewBag.Amigos);
        }

        public async Task<IActionResult> Chat()
        {
            ViewBag.Amigos = await authService.getAmigosAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryTokenAttribute]
        public async Task<IActionResult> RemoverAmigo(string idAlvo)
        {
            await authService.RemoverAmigoAsync(idAlvo);
            return RedirectToAction("Index","Loja", new { area = "" });
        }
    }
}
