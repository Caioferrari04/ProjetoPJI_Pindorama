using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Models
{
    public class Usuario : IdentityUser
    {
        [Display(Name = "Link da imagem de perfil")]
        public string LinkImagem { get; set; }

        [Required(ErrorMessage = "Informe a data nascimento!")]
        [DataType(DataType.Date)]
        [Display(Name = "Data de nascimento")]
        public DateTime? DataNascimento { get; set; }

        public double Dinheiro { get; set; }

        public string cnpj { get; set; }

        public string cpf { get; set; }

        public string cep { get; set; }

        public List<Game> Games { get; set; }

        public string Role { get; set; }

        public List<Amizade> Origem { get; set; }

        public List<Amizade> Alvo { get; set; }
    }
}
