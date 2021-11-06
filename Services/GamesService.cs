using Microsoft.EntityFrameworkCore;
using Pindorama.Auth;
using Pindorama.Data;
using Pindorama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Services
{
    public class GamesService
    {
        PindoramaContext context;
        public GamesService(PindoramaContext context)
        {
            this.context = context;
        }

        public List<Game> GetAll(Categoria categoria = null) /*Como não há uma função de busca ainda, é valido implementar ela agora?*/
        {
            return getMostPopular(categoria);
        }

        public Game Get(int? id)
        {
            return context.Game.Include(c => c.Categorias).Include(i => i.Imagens).FirstOrDefault(p => p.Id == id); ;
        }

        public List<Game> GetAllOwnedGames(Token token)
        {
            User currentUser = context.User.First(u => u.Id == token.UserId);
            return context.Game.Where(g => g.Users.Contains(currentUser)).ToList();
        }

        public bool BuyGame(Token token, Game game)
        {
            try 
            { 
                User currentUser = context.User.First(u => u.Id == token.UserId);
                game.Users = game.Users == null ? new List<User>() : game.Users;
                if (!game.Users.Contains(currentUser)) { 
                    game.Users.Add(currentUser);
                    game.compras++;
                    context.Update(game);
                    context.SaveChanges();
                    return true;
                }
                return false;
            } 
            catch
            {
                return false;
            }
        }

        public List<Game> getMostPopular(Categoria categoria = null)
        {
            try
            {
                List<Game> games = new List<Game>();
                if (categoria != null) {
                    Categoria catGames = context.Categorias.Include(u => u.Jogos).FirstOrDefault(ct => ct.Id == categoria.Id);
                    games = catGames.Jogos;
                } 
                else 
                { 
                    games = context.Game.ToList();
                    games = games.OrderByDescending(p => p.compras).ToList();
                }
                return games;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao devolver os jogos mais populares!", ex);
            }
        }
    }
}
