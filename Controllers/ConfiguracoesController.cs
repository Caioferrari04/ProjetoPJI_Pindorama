using Microsoft.AspNetCore.Authorization;
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
    public class ConfiguracoesController : Controller
    {
        AuthService authService;
        public ConfiguracoesController(AuthService authService)
        {
            this.authService = authService;
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

        public async Task<IActionResult> Jogos()
        {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            return View();
        }

        public async Task<IActionResult> AdicionarJogo()
        {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            return View();
        }

        public async Task<IActionResult> EditarJogo()
        {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeletarConta(UsuarioDTO user) {
            ViewBag.Pendentes = await authService.GetPendentesAsync();
            ViewBag.Amigos = await authService.getAmigosAsync();
            return await authService.DeleteUser(user) ? Redirect("/Identity/Account/Login") : View(); 
        }

}

    public class UsuarioDTO
    {
        [Display(Name = "Link da imagem de perfil")]
        public string LinkImagem { get; set; }

        [EmailAddress(ErrorMessage = "Email não é valido!")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Display(Name = "Nome de usuário")]
        [RegularExpression(@"^(?=[a-zA-Z])[-\w.]{0,23}([a-zA-Z\d]|(?<![-.])_)$", ErrorMessage = "Nome de usuário inválido!")]
        public string UserName { get; set; }

        [DataType(DataType.Date)]
        [Display(Name = "Data de nascimento")]
        public DateTime? DataNascimento { get; set; }

        [Display(Name = "CPF")]
        public string cpf { get; set; }

        [Display(Name = "CNPJ")]
        public string cnpj { get; set; }

        [Display(Name = "CEP")]
        public string cep { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Senha atual")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Nova senha")]
        [Compare("Password", ErrorMessage = "A senha de confirmação não é igual.")]
        public string NewPassword { get; set; }
    }
}
