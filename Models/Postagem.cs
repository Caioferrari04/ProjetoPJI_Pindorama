using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Pindorama.Models
{
    public class Postagem
    {
        [Key]
        public int Id { get; set; } 

        [DataType(DataType.MultilineText)]
        public string Conteudo { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? DataPostagem { get; set; }

        public int QtyComentarios { get => Comentarios.Count; }

        public int QtyLikes { get => Likes.Count; }

        public int ComunidadeId { get; set; }

        public Game Comunidade { get; set; }

        public string UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public List<Comentario> Comentarios { get; set; }

        public List<LikePost> Likes { get; set; }
    }
}
