using System;
using System.ComponentModel.DataAnnotations;

namespace Pindorama.Models
{
    public class UsuarioDTO
    {
        [Display(Name = "Link da imagem de perfil")]
        [DataType(DataType.ImageUrl)]
        public string LinkImagem { get; set; }

        [Display(Name = "Link do banner de perfil")]
        [DataType(DataType.ImageUrl)]
        public string LinkBanner { get; set; }

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
