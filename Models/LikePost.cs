using System.ComponentModel.DataAnnotations;

namespace Pindorama.Models
{
    public class LikePost
    {
        [Key]
        public string UsuarioId { get; set; }

        public Usuario Usuario { get; set; }

        [Key]
        public int PostId { get; set; }

        public Postagem Post { get; set; }
    }
}
