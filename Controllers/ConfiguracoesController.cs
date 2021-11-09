using Microsoft.AspNetCore.Mvc;
using Pindorama.Auth;
using Pindorama.Models;
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(User user)
        {
            if (!authService.ValidateToken()) return RedirectToAction("Index", "Loja", new { area = "" });
            ViewBag.currentUser = authService.GetCurrentToken();
            ViewBag.status = authService.UpdateUser(user, ViewBag.currentUser.UserToken);
            return View(user);
        }

        public IActionResult AlterarSenha()
        {
            if (!authService.ValidateToken()) return RedirectToAction("Index", "Loja", new { area = "" });
            ViewBag.currentUser = authService.GetCurrentToken();
            return View();
        }

        public IActionResult DeletarConta()
        {
            if (!authService.ValidateToken()) return RedirectToAction("Index", "Loja", new { area = "" });
            ViewBag.currentUser = authService.GetCurrentToken();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarConta(User user)
        {
            if (!authService.ValidateToken()) return RedirectToAction("Index", "Loja", new { area = "" });
            ViewBag.currentUser = authService.GetCurrentToken();
            return authService.DeleteUser(user, ViewBag.currentUser.UserToken) ? RedirectToAction("Index", "Home", new { area = "" }) : View(user);
        }
    }
}
