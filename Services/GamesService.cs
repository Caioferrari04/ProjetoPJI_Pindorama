using Microsoft.AspNetCore.Identity;
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
        PindoramaContext _context;
        UserManager<Usuario> _userManager;
        SignInManager<Usuario> _signIn;
        public GamesService(PindoramaContext context, UserManager<Usuario> userManager, SignInManager<Usuario> signIn)
        {
            _context = context;
            _userManager = userManager;
            _signIn = signIn;
        }

        public List<Game> GetAll(Categoria categoria = null, int? pagina = null) /*Como não há uma função de busca ainda, é valido implementar ela agora?*/
        {
            return getMostPopular(categoria, pagina);
        }

        public Game GetGameById(int? id)
        {
            return _context.Game.Include(c => c.Categorias).Include(i => i.Imagens).Include(u => u.Postagens).FirstOrDefault(p => p.Id == id); ;
        }

        public async Task<List<Game>> GetAllOwnedGames()
        {
            Usuario currentUser = await _userManager.GetUserAsync(_signIn.Context.User);
            return _context.Game.Where(g => g.Users.Contains(currentUser)).ToList();
        }

        public async Task<bool> BuyGame(Game game)
        {
            try 
            { 
                Usuario currentUser = await _userManager.GetUserAsync(_signIn.Context.User);
                game.Users = game.Users == null ? new List<Usuario>() : game.Users;
                if (!game.Users.Contains(currentUser)) { 
                    game.Users.Add(currentUser);
                    game.compras++;
                    _context.Game.Update(game);
                    await _context.SaveChangesAsync();
                    return true;
                }
                return false;
            } 
            catch
            {
                return false;
            }
        }

        public async Task<bool> HasGame(Game game)
        {
            Usuario currentUser = await _userManager.GetUserAsync(_signIn.Context.User);
            Game gameAtual = await _context.Game.Include(o => o.Users).FirstAsync(u => u.Id == game.Id);
            if (gameAtual.Users is not null && gameAtual.Users.Contains(currentUser)) return true;
            return false;
        }

        public List<Game> getMostPopular(Categoria categoria = null, int? pagina = null)
        {
            try
            {
                List<Game> games = new List<Game>();
                if (categoria != null) {
                    int? contaPagina = pagina is null ? 8 : pagina * 8;
                    Categoria catGames = _context.Categorias.Include(u => u.Jogos).FirstOrDefault(ct => ct.Id == categoria.Id && ct.Id <= contaPagina);
                    games = catGames.Jogos;
                } 
                else 
                { 
                    games = _context.Game.ToList();
                    games = games.OrderByDescending(p => p.compras).ToList();
                }
                return games;
            }
            catch (Exception ex)
            {
                throw new Exception("Houve um erro ao devolver os jogos mais populares!", ex);
            }
        }
    
        public List<Postagem> GetGamePostagens(int id) => GetGameById(id).Postagens;
    }
}
