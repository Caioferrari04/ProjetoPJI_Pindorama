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
        AuthService authService;
        public SuporteController(AuthService authService)
        {
            this.authService = authService;
            
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            return View();
        }
    }
}
