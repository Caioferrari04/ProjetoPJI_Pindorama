namespace Pindorama.Models
{
    public class Like
    {
#nullable disable
        public int UsuarioId { get; set; }

#nullable disable
        public Usuario Usuario { get; set; }

#nullable enable
        public int PostagemId { get; set; }

#nullable enable
        public Postagem? Postagem { get; set; }

#nullable enable
        public int ComentarioId { get; set; }

#nullable enable
        public Comentario? Comentario { get; set; }
    }
}
