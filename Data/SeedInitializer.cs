using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Pindorama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Data
{
    public static class SeedInitializer
    {
        public static void Initializer(IHost app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var provedorServico = scope.ServiceProvider;
                var context = provedorServico.GetRequiredService<PindoramaContext>();
                context.Database.Migrate();
                Random rand = new Random();

                List<Categoria> categorias = context.Categorias.ToList();

                foreach (Game game in context.Game.Include(u => u.Categorias))
                    foreach (Categoria categoria in categorias)
                        if(rand.Next(10) > 7 && game.Categorias.Count == 0)
                            game.Categorias.Add(categoria);

                
                context.SaveChanges();
            }
        }
    }
}
