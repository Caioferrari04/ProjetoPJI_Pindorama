using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Models
{
    public class Mensagem
    {
        [Key]
        public int id { get; set; }

        [DataType(DataType.MultilineText)]
        public string corpoMensagem { get; set; }

        [DataType(DataType.Date)]
        public DateTime? dataEnvio { get; set; }
        
        public string autorId { get; set; }

        public Usuario autor { get; set; }
        
        public string alvoId { get; set; }

        public Usuario alvo { get; set; }
    }
}
