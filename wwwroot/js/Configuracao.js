let botoes = document.getElementsByClassName("botao-nav");

function mostrarAba(x) {
    console.log(x);
    for (let i = 0; i < 5; i++) {
        if (i == x) {
            botoes[i].classList = "botao-nav selecionado";
        } else {
            botoes[i].classList = "botao-nav";
        }
    }
}