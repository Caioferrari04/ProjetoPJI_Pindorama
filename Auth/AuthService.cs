using Pindorama.Data;
using Pindorama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;

namespace Pindorama.Auth
{
    public class AuthService
    {
        PindoramaContext context;
        public AuthService(PindoramaContext context)
        {
            this.context = context;
        }

        public string Create(User user)
        {
            if (GetUser(user) != null) return "Conta já existente!";
            try
            {
                user.Role = "Common";
                context.User.Add(user);
                context.SaveChanges();
                return "Contra criada com sucesso!";
            }
            catch
            {
                return "Erro!";
            }
        }

        public User GetUser(User user)
        {
            var usuario = context.User.FirstOrDefault(u => u.Nome == user.Nome || u.Email == user.Email);
            if (usuario != null && user.Senha == usuario.Senha)
                return usuario;
            return null;
        }

        public bool UpdateUser(User user)
        {
            try
            {
                context.User.Update(user);
                context.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        //public User GetCurrentUser(Token token)
        //{
        //    try
        //    {
        //        return context.User.First(u => u.Id == token.UserId);
        //    }
        //    catch
        //    {
        //        throw new Exception("Usuário não autenticado!");
        //    }
        //}

        public void GenerateToken(User user)
        {
            try { 
                Random rand = new Random();
                string preToken = $"{rand.Next(0, 999999)}UvhaUHUasad{rand.Next(0, 999999)}";
                Token token = new Token() { Role = user.Role, TokenName = preToken, UserId = user.Id, CreationTime = DateTime.Now };
                context.Token.Add(token);
                context.SaveChanges();
                File.WriteAllText("authKey.txt", token.TokenName);
            } 
            catch
            {
                throw new Exception("Erro ao gerar token!");
            }
        }

        public bool ValidateToken()
        {
            if (File.Exists("authKey.txt")) { 
                var fileToken = File.ReadAllText("authKey.txt");
                var serverToken = context.Token.FirstOrDefault(token => token.TokenName == fileToken);
                if (serverToken != null)
                {
                    if ((DateTime.Now - serverToken.CreationTime).TotalMinutes >= 10)
                    {
                        File.Delete("authKey.txt");
                        context.Token.Remove(serverToken);
                        return false;
                    }
                    return true;
                }
            }
            return false;
        }

        public Token GetCurrentToken()
        {
            var fileToken = File.ReadAllText("authKey.txt");
            return context.Token.Include(u => u.UserToken).FirstOrDefault(token => token.TokenName == fileToken); ;
        }

        public void Logout()
        {
            var fileToken = File.ReadAllText("authKey.txt");
            var serverToken = context.Token.First(t => t.TokenName == fileToken);
            context.Remove(serverToken);
            context.SaveChanges();
            File.Delete("authKey.txt");
        }
    }
}
