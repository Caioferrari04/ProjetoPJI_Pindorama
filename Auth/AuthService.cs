using Pindorama.Data;
using Pindorama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;

namespace Pindorama.Auth
{
    public class AuthService
    {
        PindoramaContext _context;
        IMemoryCache _cache;
        public static readonly string AuthKey = "_AuthKey";

        public AuthService(PindoramaContext context, IMemoryCache cache)
        {
            _context = context;
            _cache = cache;
        }

        public string Create(UserAntigo user)
        {
            if (GetUser(user) is not null) return "Conta já existente!";
            try
            {
                user.Role = "Common";
                _context.UserAntigo.Add(user);
                _context.SaveChanges();
                return "Contra criada com sucesso!";
            }
            catch
            {
                return "Erro!";
            }
        }

        public UserAntigo GetUser(UserAntigo user)
        {
            var usuario = _context.UserAntigo.FirstOrDefault(u => u.Nome == user.Nome || u.Email == user.Email);
            if (usuario != null && user.Senha == usuario.Senha)
                return usuario;
            return null;
        }

        public List<UserAntigo> SearchUsers(string nome)
        {
            try
            {
                return _context.UserAntigo.Where(u => u.Nome.ToLower().Contains(nome.ToLower())).ToList();
            }
            catch
            {
                return null;
            }
        }

        public string UpdateUser(UserAntigo user, UserAntigo userValid)
        {
            try
            {
                UserAntigo userChange = new UserAntigo()
                {
                    Id = userValid.Id,
                    Nome = user.Nome is null || user.Nome == userValid.Senha ? userValid.Nome : user.Nome,
                    Email = user.Email is null ? userValid.Email : user.Email,
                    LinkImagem = user.LinkImagem,
                    DataNascimento = user.DataNascimento is null ? userValid.DataNascimento : user.DataNascimento,
                    Senha = user.Nome == userValid.Senha && user.Senha is not null ? user.Senha : userValid.Senha,
                    Role = userValid.Role
                };
                _context.ChangeTracker.Clear();
                _context.UserAntigo.Update(userChange);
                _context.SaveChanges();
                return "Conta editada com sucesso!";
            }
            catch
            {
                return "Houve um erro ao editar seu perfil!";
            }
        }

        public void GenerateToken(UserAntigo user)
        {
            try
            {
                Random rand = new Random();
                string preToken = $"{rand.Next(0, 999999)}UvhaUHUasad{rand.Next(0, 999999)}";
                Token token = new Token() { Role = user.Role, TokenName = preToken, UserId = user.Id, CreationTime = DateTime.Now };
                //_context.Token.Add(token);
                //_context.SaveChanges();
                if (!_cache.TryGetValue(AuthKey, out Token cacheEntry))
                {
                    // Key not in cache, so get data.
                    cacheEntry = token;

                    var cacheEntryOptions = new MemoryCacheEntryOptions()
                        // Set cache entry size by extension method.
                        .SetSize(124)
                        // Keep in cache for this time, reset time if accessed.
                        .SetSlidingExpiration(TimeSpan.FromMinutes(30));

                    // Set cache entry size via property.
                    // cacheEntryOptions.Size = 1;

                    // Save data in cache.
                    _cache.Set(AuthKey, cacheEntry, cacheEntryOptions);
                }
            }
            catch
            {
                throw new Exception("Erro ao gerar token!");
            }
        }

        public bool ValidateToken()
        {
            if (_cache.TryGetValue(AuthKey, out Token cacheEntry))
            {
                var fileToken = cacheEntry;
                var serverToken = new Token(); /*_context.Token.FirstOrDefault(token => token.TokenName == fileToken.TokenName);*/
                if (serverToken is not null) return true;
            }
            return false;
        }

        public Token GetCurrentToken()
        {
            _cache.TryGetValue(AuthKey, out Token cacheEntry);
            return new Token(); /*_context.Token.Include(u => u.UserToken).FirstOrDefault(token => token.TokenName == cacheEntry.TokenName);*/
        }

        public void Logout()
        {
            _cache.TryGetValue(AuthKey, out Token cacheEntry);
            var serverToken = 0; /*_context.Token.First(t => t.TokenName == cacheEntry.TokenName);*/
            _context.Remove(serverToken);
            _context.SaveChanges();
            _cache.Remove(AuthKey);
        }

        public bool DeleteUser(UserAntigo user, Token userValid)
        {
            try
            {
                if (user.Senha == userValid.UserToken.Senha)
                {
                    _cache.TryGetValue(AuthKey, out Token cacheEntry);
                    Token token = cacheEntry;
                    _context.Remove(userValid);
                    _cache.Remove(AuthKey);
                    _context.UserAntigo.Remove(userValid.UserToken);
                    _context.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
