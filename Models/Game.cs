using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Models
{
    public class Game
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Informe o nome!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Informe a descrição!")]
        [DataType(DataType.MultilineText)]
        public string Descricao { get; set; }

        [Required(ErrorMessage = "Informe o link para o logo!")]
        [DataType(DataType.ImageUrl)]
        public string LinkLogo { get; set; }

        [Required(ErrorMessage = "Informe o link para o banner!")]
        [DataType(DataType.ImageUrl)]
        public string LinkBanner { get; set; }

        [Required(ErrorMessage = "Informe o preço do jogo!")]
        [DataType(DataType.Currency)]
        public double Preco { get; set; }

        public bool IsFree { get; set; }

        [Required(ErrorMessage = "Informe o link para o trailer!")]
        [DataType(DataType.ImageUrl)]
        public string LinkVideo { get; set; }

        [Required(ErrorMessage = "Informe os desenvolvedores do jogo!")]
        [DataType(DataType.ImageUrl)]
        public string Desenvolvedor { get; set; }

        public string Publisher { get; set; }

        public int compras { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        public string DistribuidoraId { get; set; }

        public List<Usuario> Users { get; set; }

        public List<Categoria> Categorias { get; set; }

        public List<Imagem> Imagens { get; set; }

        public List<Postagem> Postagens { get; set; }
    }
}
