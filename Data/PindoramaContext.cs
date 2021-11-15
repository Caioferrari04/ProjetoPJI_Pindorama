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


            //builder.Entity<CategoriasGame>()
            //    .HasKey(tt => new { tt.CategoriasId, tt.JogosId });
        }

        public DbSet<UserAntigo> UserAntigo { get; set; }

        public DbSet<Game> Game { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        //public DbSet<CategoriasGame> CategoriasGames { get; set; }

        public DbSet<Imagem> Imagens { get; set; }
    }
}
