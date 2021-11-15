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

        [HttpGet]
        public IActionResult Index()
        {
            if(authService.ValidateToken()) return RedirectToAction("Index", "Loja", new { area = "" });
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(UserAntigo user)
        {
            var validUser = authService.GetUser(user);

            if (validUser is not null)
            {
                authService.GenerateToken(validUser);
                return RedirectToAction("Index" , "Loja", new { area = "" });
            }
            ViewBag.Erro = "Nome de usuário e senha inválidos! Tem certeza que digitou corretamente?";
            return View();
        }
        
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(UserAntigo user)
        {
            if (!ModelState.IsValid) return View(user);

            string result = authService.Create(user);

            if (result == "Contra criada com sucesso!")
            {
                authService.GenerateToken(user);
                return RedirectToAction("Index", "Loja", new { area = "" });
            }
            ViewBag.Erro = result;
            return View(user);
        }

        [HttpGet]
        public IActionResult Logout()
        {
            authService.Logout();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Amigos(string nome)
        {
            if (!authService.ValidateToken()) return RedirectToAction("Index", "Home", new { area = "" });
            ViewBag.currentUser = authService.GetCurrentToken();
            return View(authService.SearchUsers(nome));
        }
    }
}
