let chat_amigos = document.getElementById("amigos");
let botao_header = document.getElementById("botao-amigo");
let barra_amigos = document.getElementById("barra-amigos");
let amigos = document.getElementsByClassName("amigo");
let chats = document.getElementsByClassName("chat");
let fechar_chat = document.getElementsByClassName("fechar-chat");
let notificacoes = document.getElementById("notificacoes");
let enviar_mensagem = document.getElementsByClassName("Msg");
let dialogo;

for (let i = 0; i < amigos.length; i++) {
    fechar_chat[i].addEventListener("click", () => {
        let chat = document.getElementById("chat-" + fechar_chat[i].id);
        chat_amigos.classList.toggle("small");
        chat.classList.toggle("chat-visible");
        chat.classList.toggle("chat-not-visible");
        
        carregarMensagens(fechar_chat[i].id, false, true);
    })
}

for (let i = 0; i < amigos.length; i++) {
    amigos[i].addEventListener("click", (event) => {
        event.preventDefault();
        console.log("chegou aq");
        chat_amigos.classList.toggle("small");
        let chat = document.getElementById("chat-" + amigos[i].id);
        chat.classList.toggle("abertoUm");
        let aberto = chat.classList.contains("abertoUm");
        chat.classList.toggle('chat-visible');
        chat.classList.toggle('chat-not-visible');
        carregarMensagens(amigos[i].id, aberto);
    });
}

for (let i = 0; i < chats.length; i++) {
    enviar_mensagem[i].addEventListener("submit", function (event) {
        event.preventDefault();
        let input = document.getElementById("enviarMsg_" + fechar_chat[i].id);
        let data = {
            text: input.value,
            data: Date.now
        }
        console.log(enviar_mensagem[i].firstChild);
        input.value = "";
        connection.invoke("enviarMensagem", origem, fechar_chat[i].id, data).catch(function (err) {
            return console.error(err.toString());
        });
    });
}

function carregarMensagens(destino, aberto) {
    connection.invoke("carregarMensagens", origem, destino, aberto, connection.connectionId, mensagemRecente).catch(function (err) {
        return console.error(err.toString());
    });
}

function minhaFuncao() {
    var DropdownConteudo = document.querySelector('.Dropdown-Conteudo');
    DropdownConteudo.classList.toggle('dropdown-toggle');
}

function destroyPedido(idAlvo) {
    let destruir = document.getElementById(idAlvo);
    let parente = destruir.parentElement;
    let notif_remov = document.getElementById("num-notif");
    let quantidade_notif = parseInt(notif_remov.textContent) > 0 ? parseInt(notif_remov.textContent) - 1 : 0;
    destruir.remove();
    if (quantidade_notif == 0) {
        notif_remov.remove();
        let texto = document.createElement("p");
        texto.textContent = "Não há notificações!";
        texto.className = "white-text";
        parente.appendChild(texto);
    } else { notif_remov.textContent = quantidade_notif; }
}

function exibirNotificacoes() {
    notificacoes.classList.toggle("not-visible")
}

function abrirLista() {
    chat_amigos.classList.toggle('visible');
    chat_amigos.classList.toggle('not-visible');
    botao_header.classList.toggle('selecionado-header');
    barra_amigos.classList.toggle('visible')
    barra_amigos.classList.toggle('not-visible')
}

