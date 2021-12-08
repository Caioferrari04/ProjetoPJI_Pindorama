using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Pindorama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Data
{
    public class PindoramaContext : IdentityDbContext
    {
        public PindoramaContext(DbContextOptions<PindoramaContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Mensagem>()
                .HasOne(a => a.autor)
                .WithMany(d => d.Mensagens)
                .HasForeignKey(d => d.autorId);

            builder.Entity<Postagem>()
                .HasOne(u => u.Usuario)
                .WithMany(u => u.Postagens)
                .HasForeignKey(u => u.UsuarioId);

            builder.Entity<Comentario>()
                .HasOne(u => u.Autor)
                .WithMany(u => u.Comentarios)
                .HasForeignKey(u => u.AutorId);

            builder.Entity<Amizade>()
                .HasKey(tt => new { tt.OrigemId, tt.AlvoId });

            builder.Entity<Usuario>()
                .HasMany(u => u.Origem)
                .WithOne(uu => uu.Alvo)
                .HasForeignKey(uu => uu.OrigemId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.Entity<Usuario>()
                .HasMany(u => u.Alvo)
                .WithOne(uu => uu.Origem)
                .HasForeignKey(uu => uu.AlvoId);

            builder.Entity<LikeComment>()
                .HasKey(tt => new { tt.CommentId, tt.UsuarioId });

            builder.Entity<LikePost>()
                .HasKey(tt => new { tt.PostId, tt.UsuarioId  });
        }

        public DbSet<Game> Game { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Imagem> Imagens { get; set; }

        public DbSet<Mensagem> Mensagens { get; set; }

        public DbSet<Amizade> Amizades { get; set; }

        public DbSet<Postagem> Postagens { get; set; }

        public DbSet<Comentario> Comentarios { get; set; }

        public DbSet<LikeComment> LikeComments { get; set; }

        public DbSet<LikePost> LikePosts { get; set; }
    }
}
