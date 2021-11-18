function minhaFuncao() {
    var DropdownConteudo = document.querySelector('.Dropdown-Conteudo');
    DropdownConteudo.classList.toggle('dropdown-toggle');
}

function abrirLista() {
    document.getElementById("amigos").classList.toggle('visible');
    document.getElementById("botao-amigo").classList.toggle('selecionado-header');
}