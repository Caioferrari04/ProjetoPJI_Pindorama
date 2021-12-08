namespace Pindorama.Models
{
    public class LikeComment
    {
        public string UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        public int CommentId { get; set; }

        public Comentario Comment { get; set; }
    }
}
