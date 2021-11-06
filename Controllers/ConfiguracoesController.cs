using Microsoft.AspNetCore.Mvc;
using Pindorama.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Controllers
{
    public class ConfiguracoesController : Controller
    {
        AuthService authService;
        public ConfiguracoesController(AuthService authService)
        {
            this.authService = authService;
        }

        public IActionResult Index()
        {
            if (!authService.ValidateToken()) return RedirectToAction("Index", "Loja", new { area = "" });
            ViewBag.currentUser = authService.GetCurrentToken();
            return View(ViewBag.currentUser.UserToken);
        }

        public IActionResult AlterarSenha()
        {
            if (!authService.ValidateToken()) return RedirectToAction("Index", "Loja", new { area = "" });
            ViewBag.currentUser = authService.GetCurrentToken();
            return View(ViewBag.currentUser.UserToken);
        }

        public IActionResult DeletarConta()
        {
            if (!authService.ValidateToken()) return RedirectToAction("Index", "Loja", new { area = "" });
            ViewBag.currentUser = authService.GetCurrentToken();
            return View(ViewBag.currentUser.UserToken);
        }
    }
}
