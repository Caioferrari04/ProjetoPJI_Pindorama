using Microsoft.EntityFrameworkCore;
using Pindorama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Data
{
    public class PindoramaContext : DbContext
    {
        public PindoramaContext(DbContextOptions<PindoramaContext> options) : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            //builder.Entity<CategoriasGame>()
            //    .HasKey(tt => new { tt.CategoriasId, tt.JogosId });
        }

        public DbSet<User> User { get; set; }

        public DbSet<Game> Game { get; set; }

        public DbSet<Token> Token { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        //public DbSet<CategoriasGame> CategoriasGames { get; set; }

        public DbSet<Imagem> Imagens { get; set; }
    }
}
