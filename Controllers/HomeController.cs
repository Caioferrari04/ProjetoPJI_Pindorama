using Microsoft.AspNetCore.Authorization;
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
    [Authorize]
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
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            return View(authService.SearchUsers(nome));
        }

        public async Task<IActionResult> ListaAmigos() 
        {
            ViewBag.Amigos = await authService.getAmigosAsync();
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            return View(ViewBag.Amigos);
        }

        public async Task<IActionResult> Perfil(string id)
        {
            ViewBag.Amigos = await authService.getAmigosAsync();
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            return View(await authService.GetUsuarioById(id));
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
