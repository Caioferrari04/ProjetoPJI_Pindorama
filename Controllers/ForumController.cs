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
    public class ForumController : Controller
    {
        AuthService authService;
        GamesService _gamesService;
        public ForumController(AuthService authService, GamesService gamesService)
        {
            this.authService = authService;
            _gamesService = gamesService;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            return View(await _gamesService.GetAllOwnedGames());
        }

        public async Task<IActionResult> GameForum(int id)
        {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            return View(_gamesService.GetGamePostagens(id));
        }
    }
}
