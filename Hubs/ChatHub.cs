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
        PindoramaContext context;
        AuthService auth;
        public ChatHub(PindoramaContext context, AuthService auth)
        {
            this.context = context;
            this.auth = auth;
        }

        public async Task CreateConnection(string conexao, int id)
        {
            UserAntigo user = auth.GetCurrentToken().UserToken;
            if (id != user.Id) return;

            user.ConnectionString = conexao;
            context.UserAntigo.Update(user);
            await context.SaveChangesAsync();
        }

        public async Task EnviarPedidoAmizade(int origem, int destino)
        {
            if (origem != auth.GetCurrentToken().UserId) return;

            UserAntigo usuarioOrigem = context.UserAntigo.FirstOrDefault(u => u.Id == origem);
            UserAntigo usuarioDestino = context.UserAntigo.FirstOrDefault(u => u.Id == destino);

            if (usuarioDestino == null) return;

            /*Como o usuário que envia o pedido não pode ver o pedido aparecendo na tela, apenas o destinatário deve receber*/
            //await Clients.User(usuarioDestino.ConnectionString).SendAsync("PedidoAmizade", usuarioOrigem.Id, usuarioDestino.Id, usuarioOrigem.Nome);
            await Clients.Client(usuarioDestino.ConnectionString).SendAsync("PedidoAmizade", usuarioOrigem.Id, usuarioDestino.Id, usuarioOrigem.Nome);
        }

        public async Task AceitarPedido(int origem, int destino)
        {
            if (destino != auth.GetCurrentToken().UserId) return;

            UserAntigo usuarioOrigem = new UserAntigo(); /*context.UserAntigo.Include(u => u.Origem).FirstOrDefault(u => u.Id == origem);*/
            UserAntigo usuarioDestino = new UserAntigo(); /*context.UserAntigo.Include(u => u.Origem).FirstOrDefault(u => u.Id == destino);*/
            List<string> usuarios = new List<string>() { usuarioOrigem.ConnectionString, usuarioDestino.ConnectionString };

            if (usuarioOrigem == null) return;

            Amizade amizade = new Amizade()
            {
                AlvoId = "",
                OrigemId = ""
            };

            //if(usuarioDestino.Origem is null) usuarioDestino.Origem = new List<Amizade>();
            //usuarioDestino.Origem.Add(amizade);

            amizade = new Amizade()
            {
                AlvoId = "",
                OrigemId = ""
            };

            //if (usuarioOrigem.Origem is null) usuarioOrigem.Origem = new List<Amizade>();
            //usuarioOrigem.Origem.Add(amizade);

            context.UserAntigo.Update(usuarioOrigem);
            context.UserAntigo.Update(usuarioDestino);
            await context.SaveChangesAsync();

            await Clients.Clients(usuarios).SendAsync("AceitarPedido", usuarioDestino.Nome);
        }

        public async Task RecusarPedido(string origem, int destino)
        {
            UserAntigo usuarioDestino = context.UserAntigo.FirstOrDefault(u => u.Id == destino);

            if (usuarioDestino == null) return;

            List<string> usuarios = new List<string>() { origem, usuarioDestino.ConnectionString };

            await Clients.Clients(usuarios).SendAsync("RecusarPedido", usuarioDestino.Nome);
        }
    }
}
