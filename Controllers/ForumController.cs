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
            var game = _gamesService.GetGameById(id);
            ViewBag.Game = game;
            return View(game.Postagens);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> GameForum(string conteudoPost, int idJogo)
        {
            await _gamesService.Postar(conteudoPost, idJogo);
            return RedirectToAction(nameof(GameForum), idJogo);
        }

        public async Task<IActionResult> Postagem(int id)
        {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            ViewBag.Postagem = await _gamesService.GetPostagemAsync(id);
            return View(await _gamesService.GetComentariosInPostAsync(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Postagem(string conteudoComment, int idPost)
        {
            await _gamesService.PostarComentario(conteudoComment, idPost);
            return RedirectToAction(nameof(Postagem), idPost);
        }
    }
}
