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

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public string LinkLogo { get; set; }

        public string LinkBanner { get; set; }

        public double Preco { get; set; }

        public bool IsFree { get; set; }

        public string LinkFiles { get; set; }

        public string LinkVideo { get; set; }

        public string Desenvolvedor { get; set; }

        public string Publisher { get; set; }

        public int compras { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataLancamento { get; set; }

        public List<Usuario> Users { get; set; }

        public List<Categoria> Categorias { get; set; }

        public List<Imagem> Imagens { get; set; }

        public List<Postagem> Postagens { get; set; }
    }
}
