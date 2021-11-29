using Pindorama.Data;
using Pindorama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.AspNetCore.Identity;
using Pindorama.Controllers;
using Pindorama.Services.Validation;

namespace Pindorama.Auth
{
    public class AuthService
    {
        readonly PindoramaContext _context;
        readonly UserManager<Usuario> _userManager;
        readonly SignInManager<Usuario> _signIn;
        public AuthService(UserManager<Usuario> userManager, SignInManager<Usuario> signIn, PindoramaContext context)
        {
            _userManager = userManager;
            _signIn = signIn;
            _context = context;
        }

        public async Task<Usuario> GetCurrentUserAsync() => await _userManager.GetUserAsync(_signIn.Context.User);

        public async Task<bool> RemoverAmigoAsync(string idAlvo)
        {
            try { 
                Usuario alvo = await _userManager.FindByIdAsync(idAlvo);
                Usuario atual = await GetCurrentUserAsync();

                Amizade amizade = _context.Amizades.FirstOrDefault(u => (u.AlvoId == alvo.Id || u.OrigemId == alvo.Id) && (u.AlvoId == atual.Id || u.OrigemId == atual.Id));

                _context.Amizades.Remove(amizade);

                await _context.SaveChangesAsync();

                return true;
            } 
            catch
            {
                return false;
            }
        } 

        public List<Usuario> SearchUsers(string nome)
        {
            try
            {
                List<Usuario> usuarios = _userManager.Users.Include(u => u.Origem).Include(a => a.Alvo).Where(u => u.NormalizedUserName.Contains(nome.Normalize())).ToList();
                usuarios.Remove(GetCurrentUserAsync().Result);
                return usuarios;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IdentityResult> UpdateUser(UsuarioDTO user)
        {
            Usuario usuarioValido = await GetCurrentUserAsync();

            if (user.Password is not null)
            {
                return await _userManager.ChangePasswordAsync(usuarioValido, user.Password, user.NewPassword);
            }

            usuarioValido.UserName = user.UserName is null && (user.UserName.Length < 5 || user.UserName.Length > 100) ? usuarioValido.UserName : user.UserName;
            usuarioValido.Email = user.Email is null ? usuarioValido.Email : user.Email;
            usuarioValido.DataNascimento = user.DataNascimento is null ? usuarioValido.DataNascimento : user.DataNascimento;
            usuarioValido.LinkImagem = user.LinkImagem is null ? usuarioValido.LinkImagem : user.LinkImagem;
            usuarioValido.cep = user.cep is null ? usuarioValido.cep : user.cep;

            SizeValidation validator = new SizeValidation();
            var validationResult = await validator.ValidateAsync(usuarioValido);
            dynamic result = validationResult.IsValid ? await _userManager.UpdateAsync(usuarioValido) : validationResult;
            return result;
        }

        public async Task<bool> DeleteUser(UsuarioDTO user)
        {
            try
            {
                Usuario usuarioAtual = await GetCurrentUserAsync();
                if (await _userManager.CheckPasswordAsync(usuarioAtual, user.Password))
                {
                    await _userManager.DeleteAsync(usuarioAtual);
                    return true;
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        public UsuarioDTO ConverterParaDTO(Usuario user)
        {
            return new UsuarioDTO
            {
                UserName = user.UserName,
                Email = user.Email,
                DataNascimento = user.DataNascimento,
                LinkImagem = user.LinkImagem,
                cep = user.cep,
                cnpj = user.cnpj,
                cpf = user.cpf
            };
        }

        public async Task<List<Usuario>> getAmigosAsync()
        {
            Usuario usuarioAtual = await GetCurrentUserAsync();
            List<Amizade> amizades = await _context.Amizades.Include(o => o.Alvo).Include(a => a.Origem).Where(u => u.Alvo == usuarioAtual || u.Origem == usuarioAtual).ToListAsync();
            amizades.RemoveAll(u => !u.Confirmada);
            List<Usuario> amigos = new List<Usuario>();
            await Task.Run(() => {
                amizades.ForEach(u => amigos.Add(u.Alvo));
                amizades.ForEach(u => amigos.Add(u.Origem));
            });

            amigos.RemoveAll(u => u.Id == usuarioAtual.Id);
            return amigos;
        }

        public async Task<List<Usuario>> GetPendentesAsync()
        {
            Usuario usuarioAtual = await GetCurrentUserAsync();
            List<Amizade> amizades = await _context.Amizades.Include(o => o.Alvo).Include(a => a.Origem).Where(u => u.Origem == usuarioAtual).ToListAsync();
            amizades.RemoveAll(u => u.Confirmada);
            List<Usuario> amigos = new List<Usuario>();
            await Task.Run(() => {
                amizades.ForEach(u => amigos.Add(u.Alvo));
                amizades.ForEach(u => amigos.Add(u.Origem));
            });

            amigos.RemoveAll(u => u.Id == usuarioAtual.Id);
            return amigos;
        }

        public async Task<Usuario> GetUsuarioById(string id) => await _userManager.FindByIdAsync(id);
     

        public async Task<bool> IsPj()
        {
            try
            {
                var userNew = await GetCurrentUserAsync();
                return userNew.cnpj is null ? false : true;
            } 
            catch
            {
                return false;
            }
            
        }
    }
}
