using Microsoft.EntityFrameworkCore;
using Pindorama.Data;
using Pindorama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Services
{
    public class CategoriasService
    {
        PindoramaContext context;
        public CategoriasService(PindoramaContext context)
        {
            this.context = context;
        }

        public List<Categoria> getAll() => context.Categorias.ToList();

        public Categoria getSingle(int? id) => context.Categorias.Include(u => u.Jogos).FirstOrDefault(p => p.Id == id);
    }
}
