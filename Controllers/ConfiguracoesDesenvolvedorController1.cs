﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pindorama.Areas.Identity.Pages.Account;
using Pindorama.Auth;
using Pindorama.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Controllers
{
    [Authorize]
    public class ConfiguracoesDesenvolvedorController : Controller
    {
        AuthService authService;
        public ConfiguracoesDesenvolvedorController(AuthService authService)
        {
            this.authService = authService;
        }

        public async Task<IActionResult> Index()
        {
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarConta(UsuarioDTO user)
        {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            return await authService.DeleteUser(user) ? Redirect("/Identity/Account/Login") : View();
        }

    }

    public class UsuarioDTO2
    {
        [Display(Name = "Link da imagem de perfil")]
        public string LinkImagem { get; set; }

        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Nome de usuário")]
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de nascimento")]
        public DateTime? DataNascimento { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        public string NewPassword { get; set; }
    }
}
