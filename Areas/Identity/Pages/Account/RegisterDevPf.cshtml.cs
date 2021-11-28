﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Pindorama.Auth;
using Pindorama.Models;
using Pindorama.Services;

namespace Pindorama.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterDevPfModel : PageModel
    {
        private readonly SignInManager<Usuario> _signInManager;
        private readonly UserManager<Usuario> _userManager;
        private readonly ILogger<RegisterDevPfModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterDevPfModel(
            UserManager<Usuario> userManager,
            SignInManager<Usuario> signInManager,
            ILogger<RegisterDevPfModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "Informe o email!")]
            [EmailAddress]
            [Display(Name = "Email")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Informe o nome de usuário!")]
            [StringLength(100, ErrorMessage = "O nome do usuário deve ter no minimo 5 caracteres e no máximo 100!", MinimumLength = 5)]
            [Display(Name = "Nome de usuário")]
            public string UserName { get; set; }

            [Required(ErrorMessage = "Insira seu CPF!")]
            [Range(11, 11, ErrorMessage = "CPF inválido! Insira seu CPF completo!")]
            public string CPF { get; set; }

            [Required(ErrorMessage = "Insira seu CEP!")]
            [Range(8, 8, ErrorMessage = "CEP inválido! Insira seu CEP completo!")]
            public string CEP { get; set; }

            [Required(ErrorMessage = "Informe a data nascimento!")]
            [DataType(DataType.Date)]
            [MinimumAge(18, ErrorMessage = "Precisa ser maior de 18!")]
            public DateTime? DataNascimento { get; set; }

            [Required(ErrorMessage = "Informe a senha!")]
            [StringLength(100, ErrorMessage = "A senha deve conter de 6 a 100 caracteres.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; }

            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "A senha e a senha de confirmação não são iguais.")]
            public string ConfirmPassword { get; set; }
        }

        public async Task OnGetAsync(string returnUrl = null)
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                var user = new Usuario { 
                    UserName = Input.UserName, 
                    DataNascimento = Input.DataNascimento, 
                    Email = Input.Email, 
                    cpf = Input.CPF, 
                    cep = Input.CEP
                };
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    await _userManager.AddToRoleAsync(user, "Desenvolvedor");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}