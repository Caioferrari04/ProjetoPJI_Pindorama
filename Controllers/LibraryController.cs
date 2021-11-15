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
    public class LibraryController : Controller
    {
        AuthService auth;
        GamesService service;
        public LibraryController(AuthService auth, GamesService service)
        {
            this.auth = auth;
            this.service = service;
        }

        public async Task<IActionResult> Index()
        {
            return View(await service.GetAllOwnedGames());
        }
    }
}
