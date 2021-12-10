let botoes = document.getElementsByClassName("botao-nav");
let adicionarImg = document.getElementById("adicionar_imagem");
let imgs = document.getElementById("imagens");

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

function criarInput(url = null) {
    let countImg = document.getElementsByName("imagens").length + 1;

    let labelImg = document.createElement("label");
    labelImg.textContent = "Imagem " + countImg;
    labelImg.htmlFor = "imagens";

    let inputImg = document.createElement("input");
    inputImg.placeholder = url === null ? "Coloque aqui o link da imagem" + countImg : "";
    inputImg.type = "url";
    inputImg.className = "input_login";
    inputImg.name = "imagens";
    inputImg.value = url === null ? "" : url;

    let removeImgBtn = document.createElement("button");
    removeImgBtn.type = "button";
    removeImgBtn.className = "botaoImg";
    removeImgBtn.addEventListener("click", () => {
        labelImg.remove();
        inputImg.remove();
        removeImgBtn.remove();
    });

    let removeIcon = document.createElement("i");
    removeIcon.classList = "fa fa-times";

    removeImgBtn.appendChild(removeIcon);
    labelImg.appendChild(removeImgBtn);
    imgs.appendChild(labelImg);
    imgs.appendChild(inputImg);
}

adicionarImg.addEventListener("click", () => {
    criarInput();
});

