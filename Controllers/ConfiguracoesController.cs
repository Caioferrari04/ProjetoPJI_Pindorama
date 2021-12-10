using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pindorama.Areas.Identity.Pages.Account;
using Pindorama.Auth;
using Pindorama.Models;
using Pindorama.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Controllers
{
    [Authorize]
    public class ConfiguracoesController : Controller
    {
        AuthService authService;
        GamesService _gameService;
        public ConfiguracoesController(AuthService authService, GamesService gameService)
        {
            this.authService = authService;
            _gameService = gameService;
        }

        public async Task<IActionResult> Index() {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            return View(authService.ConverterParaDTO(await authService.GetCurrentUserAsync())); 
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(UsuarioDTO user)
        {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            if (!ModelState.IsValid) return View(user);

            return authService.UpdateUser(user).Result.Succeeded ? View(authService.ConverterParaDTO(await authService.GetCurrentUserAsync())) : View(user);
        }

        public async Task<IActionResult> AlterarSenha()
        {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            return View();
        }

        public async Task<IActionResult> DeletarConta()
        {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            return View();
        }

        public async Task<IActionResult> VerJogos()
        {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            return View(_gameService.GetDevelopedGamesAsync(authService.GetCurrentUserAsync().Result));
        }

        public async Task<IActionResult> AdicionarJogo()
        {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AdicionarJogo(Game game, string[] imagens, string[] categorias)
        {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            Game gameNovo = await _gameService.AddGameAsync(game, imagens, categorias);
            return gameNovo is null ? View(game) : RedirectToAction("ReadSingle", "Loja", game.Id);
        }

        public async Task<IActionResult> EditarJogo(int id)
        {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            return View(_gameService.GetGameById(id));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditarJogo(Game game, string[] imagens, string[] categorias)
        {
            if (!ModelState.IsValid) return View(game);

            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            Game gameAtualizado = await _gameService.UpdateGameAsync(game, imagens, categorias);
            return gameAtualizado is null ? View(game) : RedirectToAction("ReadSingle", "Loja", new { id = gameAtualizado.Id, area = "" }); ;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarConta(UsuarioDTO user) {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            return await authService.DeleteUser(user) ? Redirect("/Identity/Account/Login") : View(); 
        }

    }
}
