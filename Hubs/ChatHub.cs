using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Pindorama.Auth;
using Pindorama.Data;
using Pindorama.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pindorama.Hubs
{
    public class ChatHub : Hub
    {
        PindoramaContext _context;
        UserManager<Usuario> _userManager;
        public ChatHub(PindoramaContext context, UserManager<Usuario> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        public async Task EnviarPedidoAmizade(string origem, string destino)
        {
            Usuario usuarioAtual = await _userManager.FindByIdAsync(origem);
            Usuario usuarioDestino = await _userManager.FindByIdAsync(destino);

            if (usuarioAtual.Id != origem || usuarioAtual.Id == usuarioDestino.Id || usuarioDestino is null || usuarioAtual is null) return;

            _context.Amizades.Add(new Amizade
            {
                AlvoId = destino,
                OrigemId = origem
            });

            await _context.SaveChangesAsync();

            await Clients.User(usuarioDestino.Id).SendAsync("PedidoAmizade", usuarioAtual.Id, usuarioDestino.Id, $"{usuarioAtual.UserName} enviou um pedido de amizade!", $"{usuarioAtual.UserName} enviou um pedido de amizade para você, deseja aceitar?");
        }

        public async Task AceitarPedido(string origem, string destino)
        {

            Usuario usuarioAtual = await _userManager.FindByIdAsync(destino);
            Usuario usuarioDestino = await _userManager.FindByIdAsync(origem);

            if (usuarioAtual.Id != destino || usuarioAtual.Id == usuarioDestino.Id || usuarioDestino is null || usuarioAtual is null) return;

            Amizade amizade = _context.Amizades.FirstOrDefault(u => u.AlvoId == usuarioAtual.Id && u.OrigemId == usuarioDestino.Id);
            if (amizade is null) return;

            amizade.Confirmada = true;

            if (usuarioDestino.Origem is null) usuarioDestino.Origem = new List<Amizade>();
            usuarioDestino.Origem.Add(amizade);
            if (usuarioAtual.Alvo is null) usuarioAtual.Alvo = new List<Amizade>();
            usuarioAtual.Alvo.Add(amizade);

            await _userManager.UpdateAsync(usuarioDestino);
            await _userManager.UpdateAsync(usuarioAtual);

            await _context.SaveChangesAsync();

            await Clients.User(usuarioDestino.Id).SendAsync("AceitarPedido", $"{usuarioAtual.UserName} aceitou seu pedido!", $"{usuarioAtual.UserName} aceitou seu pedido de amizade, encontre-o na sua barra de amigos e comecem a conversar!");
        }

        public async Task RecusarPedido(string origem, string destino)
        {
            Usuario usuarioAtual = await _userManager.FindByIdAsync(destino);
            Usuario usuarioDestino = await _userManager.FindByIdAsync(origem);

            if (usuarioDestino == null) return;

            Amizade amizade = _context.Amizades.FirstOrDefault(u => u.AlvoId == usuarioAtual.Id && u.OrigemId == usuarioDestino.Id);
            if (amizade is null) return;

            _context.Amizades.Remove(amizade);

            await _context.SaveChangesAsync();

            await Clients.User(usuarioDestino.Id).SendAsync("RecusarPedido", $"{usuarioDestino.UserName} recusou seu pedido!", $"Infelizmente, {usuarioDestino.UserName} recusou seu pedido. Não desista e procure mais amigos!");
        }
    }
}
