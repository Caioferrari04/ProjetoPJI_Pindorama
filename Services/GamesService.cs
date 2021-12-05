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
        AuthService _authService;
        public GamesService(PindoramaContext context, UserManager<Usuario> userManager, SignInManager<Usuario> signIn, AuthService authService)
        {
            _context = context;
            _userManager = userManager;
            _signIn = signIn;
            _authService = authService;
        }

        public List<Game> GetAll(Categoria categoria = null, int? pagina = null) /*Como não há uma função de busca ainda, é valido implementar ela agora?*/
        {
            return getMostPopular(categoria, pagina);
        }

        public Game GetGameById(int? id)
        {
            return _context.Game
                .Include(c => c.Categorias)
                .Include(i => i.Imagens)
                .Include(u => u.Postagens)
                .ThenInclude(p => p.Usuario)
                .Include(u => u.Postagens)
                .ThenInclude(y => y.Comentarios)
                .FirstOrDefault(p => p.Id == id); ;
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

        public async Task<bool> Postar(string texto, int jogoId)
        {
            if (string.IsNullOrWhiteSpace(texto)) return false;

            Usuario user = await _authService.GetCurrentUserAsync();
            Game game = GetGameById(jogoId);

            Postagem newPostagem = new Postagem()
            {
                Conteudo = texto,
                DataPostagem = DateTime.Now,
                ComunidadeId = game.Id,
                UsuarioId = user.Id
            };

            if (game.Postagens is null) game.Postagens = new List<Postagem>();
            game.Postagens.Add(newPostagem);

            if (user.Postagens is null) user.Postagens = new List<Postagem>();
            user.Postagens.Add(newPostagem);

            try { 
                await _userManager.UpdateAsync(user);
                _context.Game.Update(game);
                _context.Postagens.Add(newPostagem);
                Console.WriteLine("Postagem criada com sucesso!");
                return true;
            } 
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message, ex.Data);
                return false;
            }
        }

        public async Task<Postagem> GetPostagemAsync(int id) => await Task.Run(() => _context.Postagens.Include(u => u.Usuario).First(p => p.Id == id));

        public async Task<List<Comentario>> GetComentariosInPostAsync(int id) => await Task.Run(() => _context.Comentarios.Include(u => u.Autor).Where(p => p.PostagemPaiId == id).ToListAsync());

        public async Task<bool> PostarComentario(string conteudoComment, int id)
        {
            if (string.IsNullOrWhiteSpace(conteudoComment)) return false;

            Usuario user = await _authService.GetCurrentUserAsync();
            Postagem postagem = await GetPostagemAsync(id);

            Comentario newPostagem = new Comentario()
            {
                Texto = conteudoComment,
                DataPostagem = DateTime.Now,
                AutorId = user.Id,
                PostagemPaiId = postagem.Id
            };

            if (postagem.Comentarios is null) postagem.Comentarios = new List<Comentario>();
            postagem.Comentarios.Add(newPostagem);

            if (user.Comentarios is null) user.Comentarios = new List<Comentario>();
            user.Comentarios.Add(newPostagem);

            try
            {
                await _userManager.UpdateAsync(user);
                _context.Postagens.Update(postagem);
                _context.Comentarios.Add(newPostagem);
                Console.WriteLine("Comentario criado com sucesso!");
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message, ex.Data);
                return false;
            }
        }

        public async Task<bool> UpdateGameAsync(Game game, string[] imagens)
        {
            try
            {
                Game gameValido = GetGameById(game.Id);
                foreach(string imagem in imagens)
                {
                    var imagemAdd = new Imagem
                    {
                        LinkImagem = imagem,
                        GameId = game.Id
                    };
                    if (!gameValido.Imagens.Contains(imagemAdd)) { 
                        _context.Imagens.Remove(await _context.Imagens.LastOrDefaultAsync(u => u.GameId == gameValido.Id));
                        await _context.Imagens.AddAsync(imagemAdd);
                    }
                }
                game.Id = gameValido.Id;
                game.Imagens = gameValido.Imagens;
                game.Categorias = gameValido.Categorias;
                game.Postagens = gameValido.Postagens;
                game.Users = gameValido.Users;
                gameValido = game;

                _context.Game.Update(gameValido);
                await _context.SaveChangesAsync();
                return true;
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

    }
}
