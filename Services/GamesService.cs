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
                .Include(c => c.Postagens)
                .ThenInclude(k => k.Likes)
                .FirstOrDefault(p => p.Id == id);
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
                    Categoria catGames = _context.Categorias.Include(u => u.Jogos).FirstOrDefault(ct => ct.Id == categoria.Id);
                    games = catGames.Jogos;
                    var contador = contaPagina - 8;
                    if(games.Count > 8) { 
                        while (contador != contaPagina || games.Count > contaPagina)
                        {
                            if (games.Count == contaPagina) break;
                            contador++;
                            games.Remove(games.Last());
                        }
                    }
                } 
                else 
                { 
                    games = _context.Game.ToList();
                    games = games.OrderByDescending(p => p.compras).ToList();
                    if (games.Count > 24) {
                        while (games.Count > 24) {
                            games.Remove(games.Last());
                        }
                    }
                }
                return games;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
        }
    
        public List<Postagem> GetGamePostagens(int id) => _context.Postagens.Include(u => u.Likes).Include(c => c.Comentarios).Where(p => p.ComunidadeId == id).ToList();

        public async Task<bool> Postar(string texto, string imagemPost, int jogoId)
        {
            if (string.IsNullOrWhiteSpace(texto)) return false;

            Usuario user = await _authService.GetCurrentUserAsync();
            Game game = GetGameById(jogoId);

            Postagem newPostagem = new Postagem()
            {
                Conteudo = texto,
                DataPostagem = DateTime.Now,
                LinkImagem = imagemPost,
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

        public async Task<Postagem> GetPostagemAsync(int id) => await Task.Run(() => _context.Postagens.Include(u => u.Usuario).Include(g => g.Comunidade).Include(u => u.Likes).FirstOrDefault(p => p.Id == id));

        public async Task<List<Comentario>> GetComentariosInPostAsync(int id) => await Task.Run(() => _context.Comentarios.Include(u => u.Autor).Include(u => u.Likes).Where(p => p.PostagemPaiId == id).ToListAsync());

        public async Task<Comentario> GetComentarioByIdAsync(int id) => await Task.Run(() => _context.Comentarios.Include(u => u.Autor).Include(u => u.Likes).FirstOrDefault(p => p.Id == id));

        public async Task<bool> PostarComentario(string conteudoComment, string linkimagem, int id)
        {
            if (string.IsNullOrWhiteSpace(conteudoComment)) return false;

            Usuario user = await _authService.GetCurrentUserAsync();
            Postagem postagem = await GetPostagemAsync(id);

            Comentario newPostagem = new Comentario()
            {
                Texto = conteudoComment,
                DataPostagem = DateTime.Now,
                LinkImagem = linkimagem,
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

        public async Task<Game> AddGameAsync(Game game, string[] imagens, string[] categorias)
        {
            if (_context.Game.FirstOrDefault(u => u.Nome == game.Nome) is not null) return null;
            try { 
                
                var usuario = await _authService.GetCurrentUserAsync();
                game.DistribuidoraId = usuario.Id;
                game.DataLancamento = DateTime.UtcNow;
                game.Users = new List<Usuario>() { await _authService.GetCurrentUserAsync() };
                await _context.Game.AddAsync(game);
                await _context.SaveChangesAsync();
                Categoria[] categoriasExistentes = _context.Categorias.ToArray();

                foreach (string imagem in imagens)
                {
                    var imagemAdd = new Imagem
                    {
                        LinkImagem = imagem,
                        GameId = game.Id
                    };

                    await _context.Imagens.AddAsync(imagemAdd);
                }
                game.Categorias = new List<Categoria>();
                for (int i = 0; i < categoriasExistentes.Length; i++)
                {
                    for(int j = 0; j < categorias.Length; j++) { 
                        if (categoriasExistentes[i].Nome.ToLower().Equals(categorias[j]))
                        {
                            game.Categorias.Add(categoriasExistentes[i]);
                        }
                    }
                }
                _context.Game.Update(game);
                await _context.SaveChangesAsync();

                return game;
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<Game> UpdateGameAsync(Game game, string[] imagens, string[] categorias)
        {
            try
            {
                Game gameValido = await _context.Game.Include(g => g.Imagens).Include(g => g.Categorias).FirstOrDefaultAsync(g => g.Id == game.Id);
                gameValido.Categorias = _context.Categorias.Where(c => categorias.Contains(c.Nome.ToLower())).ToList();
                _context.Imagens.RemoveRange(gameValido.Imagens);

                gameValido.Nome = game.Nome;
                gameValido.Descricao = game.Descricao;
                gameValido.Preco = game.Preco;
                gameValido.LinkLogo = game.LinkLogo;
                gameValido.Desenvolvedor = game.Desenvolvedor;
                gameValido.LinkVideo = game.LinkVideo;
                gameValido.LinkBanner = game.LinkBanner;
                
                gameValido.Imagens = new List<Imagem>();
                foreach (string imagem in imagens)
                {
                    if (!string.IsNullOrWhiteSpace(imagem))
                    {
                        var imagemAdd = new Imagem
                        {
                            LinkImagem = imagem,
                            GameId = game.Id
                        };
                        
                        //await _context.Imagens.AddAsync(imagemAdd);
                        gameValido.Imagens.Add(imagemAdd);
                    }
                }

                _context.Game.Update(gameValido);
                await _context.SaveChangesAsync();
                return gameValido;
            }
            catch(Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> IsLiked(string origem, int postId, bool isPost) =>
            await Task.Run(() => {
                if (isPost) {
                    Postagem postagens = _context.Postagens.Include(u => u.Likes).ThenInclude(p => p.Usuario).First(z => z.Id == postId);
                    List<LikePost> likes = postagens.Likes.Where(u => u.UsuarioId == origem).ToList();
                    return likes.Count > 0;
                }
                Comentario postagensC = _context.Comentarios.Include(u => u.Likes).ThenInclude(p => p.Usuario).First(z => z.Id == postId);
                List<LikeComment> likesC = postagensC.Likes.Where(u => u.UsuarioId == origem).ToList();
                return likesC.Count > 0;
            });

        public async Task<List<Postagem>> GetPostagemsFromUserAsync(string origem) => await Task.Run(() =>
            _context.Postagens
                .Include(u => u.Likes)
                .Include(u => u.Comentarios)
                .Include(u => u.Comunidade)
                .Where(p => p.UsuarioId.Equals(origem)).ToList()
        );

        public Game[] GetDevelopedGamesAsync(Usuario distribuidora)
        {
            try
            {
                return _context.Game.Where(game => game.DistribuidoraId == distribuidora.Id).ToArray();
            } 
            catch (Exception ex)
            {
                Console.Error.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task<bool> DeletePostagemAsync(int id, bool isComment)
        {
            try
            {
                if (isComment) {
                    Comentario comment = await GetComentarioByIdAsync(id);
                    _context.Comentarios.Remove(comment);
                    
                } else {
                    Postagem post = await GetPostagemAsync(id);
                    _context.Postagens.Remove(post);
                    _context.Comentarios.RemoveRange(await GetComentariosInPostAsync(id));
                }
                await _context.SaveChangesAsync();
                return true;
            } 
            catch(Exception ex)
            {
                await Console.Error.WriteLineAsync(ex.Message);
                return false;
            }
        }

        public async Task<int> GetQuantidadePaginasAsync(Categoria categoria) => 
            await Task.Run(() =>
            {
                List<Game> games = GetAll();
                games.RemoveAll(g => !categoria.Jogos.Contains(g));
                int total = 1;
                int contador = 1;
                for(int i = 0; i < games.Count; i++)
                {
                    if(i >= contador * 8)
                    {
                        total++;
                        contador++;
                    }
                }
                return total;
            });

        public async Task<List<Game>> SearchGamesInCategoryAsync(string nome, Categoria cat) =>
            await _context.Game.Include(c => c.Categorias).Where(g => g.Categorias.Contains(cat) && g.Nome.Contains(nome)).ToListAsync();
    }
}
