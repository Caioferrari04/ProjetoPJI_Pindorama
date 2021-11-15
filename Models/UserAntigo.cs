using ElectronNET.API.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Models
{
    public class UserAntigo
    {
        public int Id { get; set; }

        [Display(Name = "Link da imagem de perfil")]
        public string LinkImagem { get; set; }

        [Required(ErrorMessage = "Informe o nome de usuário!")]
        [StringLength(100,ErrorMessage = "O nome do usuário deve ter no minimo 5 caracteres e no máximo 100!", MinimumLength = 5)]
        [Display(Name = "Nome de usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe seu email!")]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe a senha!")]
        [StringLength(50, ErrorMessage = "A senha deve ter no mínimo 6 caracteres e no máximo 50 caracteres.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        public string ConnectionString { get; set; }

        [Required(ErrorMessage ="Informe a data nascimento!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de nascimento")]
        public DateTime? DataNascimento { get; set; }

        public double Dinheiro { get; set; }

        public List<Game> Games { get; set; }

        public string Role { get; set; }
        
    }
}
