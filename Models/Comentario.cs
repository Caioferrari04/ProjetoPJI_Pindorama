using System;
using System.ComponentModel.DataAnnotations;

namespace Pindorama.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        public string Texto { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? MyProperty { get; set; }

        public int PostagemPaiId { get; set; }

        public Postagem PostagemPai { get; set; }

        public string AutorId { get; set; }

        public Usuario Autor { get; set; }
    }
}
