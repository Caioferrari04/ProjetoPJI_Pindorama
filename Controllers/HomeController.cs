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
        public IActionResult Index(User user)
        {
            var validUser = authService.GetUser(user);

            if (validUser != null)
            {
                authService.GenerateToken(validUser);
                return RedirectToAction("Index" , "Loja", new { area = "" });
            }
            return View();
        }
        
        [HttpGet]
        public IActionResult Cadastro()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Cadastro(User user)
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

        public IActionResult Logout()
        {
            authService.Logout();
            return RedirectToAction(nameof(Index));
        }

        //[HttpGet]
        //public IActionResult Configuracoes()
        //{
        //    if (!authService.ValidateToken()) return RedirectToAction("Index", "Home", new { area = "" });
        //    Token token = authService.GetCurrentToken();
        //    ViewBag.currentUser = token;
        //    return View(token.UserToken);
        //}

        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public IActionResult Configuracoes(User user)
        //{
        //    if (!authService.ValidateToken()) return RedirectToAction("Index", "Home", new { area = "" });
        //    Token token = authService.GetCurrentToken();
        //    ViewBag.currentUser = token;
        //    if (!ModelState.IsValid) return View(user);
        //    if(user.Nome == token.UserToken.Senha)
        //    {
        //        token.UserToken.Senha = user.Senha;
        //    }
        //    token.UserToken.Nome = user.Nome != null ? user.Nome : token.UserToken.Nome;
        //    token.UserToken.DataNascimento = user.DataNascimento != null ? user.DataNascimento : token.UserToken.DataNascimento;
        //    token.UserToken.Email = user.Email != null ? user.Email : token.UserToken.Email;
        //    token.UserToken.LinkImagem = user.LinkImagem != null ? user.LinkImagem : token.UserToken.LinkImagem;
        //    return authService.UpdateUser(token.UserToken) ? RedirectToAction("Index", "Loja", new { area = "" }) : View(user);
        //}
    }
}
