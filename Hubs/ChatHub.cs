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

            await Clients.User(usuarioDestino.Id).SendAsync("AceitarPedido", $"{usuarioDestino.UserName} recusou seu pedido!", $"Infelizmente, {usuarioDestino.UserName} recusou seu pedido. Não desista e procure mais amigos!");
        }

        public async Task CarregarMensagens(string origem, string destino, bool aberto, string connectionId, MensagemDTO mensagemRecente = null)
        {
            Usuario usuarioAtual = await _userManager.FindByIdAsync(destino);
            Usuario usuarioDestino = await _userManager.FindByIdAsync(origem);

            if (usuarioAtual is null || usuarioDestino is null) return;

            string[] nomes = new string[] { usuarioAtual.UserName, usuarioDestino.UserName };
            Array.Sort(nomes, 0, 2);
            string grupo = nomes[0] + nomes[1];

            if (aberto) { 
                await Groups.AddToGroupAsync(connectionId, grupo);
                List<Mensagem> mensagens = _context.Mensagens.Where(u => (u.autorId == usuarioAtual.Id && u.alvoId == usuarioDestino.Id) || (u.autorId == usuarioDestino.Id && u.alvoId == usuarioAtual.Id)).ToList();
                List<MensagemDTO> mensagemDTOs = new List<MensagemDTO>();

                if(mensagemRecente is not null) mensagens.RemoveAll(u => mensagemRecente.data > u.dataEnvio || mensagemRecente.data == u.dataEnvio);

                mensagens.ForEach(u => mensagemDTOs.Add(new MensagemDTO { 
                    nome = u.autor.Id,
                    data = u.dataEnvio,
                    text = u.corpoMensagem,
                    img = u.autor.LinkImagem is null ? "/css/img/Usuario.jpg" : u.autor.LinkImagem,
                }));
                
                await Clients.Caller.SendAsync("CarregarMensagens", mensagemDTOs, destino);
            } 
            else
            {
                await Groups.RemoveFromGroupAsync(connectionId, grupo);
                await Clients.Group(grupo).SendAsync("RemovidoGrupo");
            }
        }

        public async Task EnviarMensagem(string origem, string destino, MensagemDTO msg)
        {
            Usuario usuarioAtual = await _userManager.FindByIdAsync(origem);
            Usuario usuarioDestino = await _userManager.FindByIdAsync(destino);

            if (usuarioAtual is null || usuarioDestino is null) return;

            if (String.IsNullOrWhiteSpace(msg.text)) return;

            string[] nomes = new string[] { usuarioAtual.UserName, usuarioDestino.UserName };
            Array.Sort(nomes, 0, 2);
            string grupo = nomes[0] + nomes[1];

            _context.Mensagens.Add(new Mensagem()
            {
                corpoMensagem = msg.text,
                dataEnvio = DateTime.Now,
                autorId = origem,
                alvoId = destino
            });

            MensagemDTO novaMensagem = new MensagemDTO()
            {
                nome = usuarioAtual.Id,
                data = DateTime.Now,
                img = usuarioAtual.LinkImagem is null ? "/css/img/Usuario.jpg" : usuarioAtual.LinkImagem,
                text = msg.text
            };

            await _context.SaveChangesAsync();
            await Clients.Group(grupo).SendAsync("ReceberMensagem", novaMensagem, usuarioAtual.Id, usuarioDestino.Id);
        }

        public class MensagemDTO
        {
            public string nome { get; set; }

            public DateTime? data { get; set; }

            public string text { get; set; }

            public string img { get; set; }
        }
    }
}
