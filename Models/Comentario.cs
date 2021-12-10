using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pindorama.Models
{
    public class Comentario
    {
        [Key]
        public int Id { get; set; }

        [DataType(DataType.MultilineText)]
        public string Texto { get; set; }

        [DataType(DataType.ImageUrl)]
        public string LinkImagem { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DataPostagem { get; set; }

        public int QtyLikes { get => Likes.Count; }

        public int PostagemPaiId { get; set; }

        public Postagem PostagemPai { get; set; }

        public string AutorId { get; set; }

        public Usuario Autor { get; set; }

        public List<LikeComment> Likes { get; set; }
    }
}
