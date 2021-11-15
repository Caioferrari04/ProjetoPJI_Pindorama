using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Pindorama.Auth;
using Pindorama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Controllers
{
    [Authorize]
    public class ConfiguracoesController : Controller
    {
        AuthService authService;
        public ConfiguracoesController(AuthService authService)
        {
            this.authService = authService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(UserAntigo user)
        {
            return View(user);
        }

        public IActionResult AlterarSenha()
        {
            return View();
        }

        public IActionResult DeletarConta()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarConta(UserAntigo user)
        {
            return View(user);
        }
    }
}
