let chat_amigos = document.getElementById("amigos");
let botao_header = document.getElementById("botao-amigo");
let barra_amigos = document.getElementById("barra-amigos");
let chat = document.getElementById("chat");

function minhaFuncao() {
    var DropdownConteudo = document.querySelector('.Dropdown-Conteudo');
    DropdownConteudo.classList.toggle('dropdown-toggle');
}

function abrirLista() {
    chat_amigos.classList.toggle('visible');
    chat_amigos.classList.toggle('not-visible');
    botao_header.classList.toggle('selecionado-header');
    barra_amigos.classList.toggle('visible')
    barra_amigos.classList.toggle('not-visible')
}

function abrirChat() {
    chat.classList.toggle('chat-visible');
    chat.classList.toggle('chat-not-visible');
    document.getElementById('pesquisa-amigos').classList.toggle('barra-nav')
    barra_amigos.classList.toggle('barra-lateral-chat')
}