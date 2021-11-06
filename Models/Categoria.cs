using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Models
{
    public class Categoria
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Descricao { get; set; }

        public int QuantidadeJogos { get => Jogos.Count; }

        public List<Game> Jogos { get; set; }
    }
}
