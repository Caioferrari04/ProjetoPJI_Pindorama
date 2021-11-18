var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();


function modifyModal(idOrigem, idDestino) {
    console.log("chegou aqui3")

    let opcoes_modal = document.getElementById("opcoes");
    let botao_titulo = document.getElementById("botao_titulo")

    let botao_modal1 = document.createElement("button");
    botao_modal1.setAttribute("type", "submit");
    botao_modal1.classList = "botao-modal";
    botao_modal1.textContent = "Aceitar";
    console.log("chegou aqui14")

    let botao_modal2 = document.createElement("button");
    botao_modal2.setAttribute("type", "submit");
    botao_modal2.classList = "botao-modal botao-vermelho";
    botao_modal2.textContent = "Recusar";
    console.log("chegou aqui15")

    opcoes_modal.appendChild(botao_modal1);
    opcoes_modal.appendChild(botao_modal2);

    console.log("chegou aqui16")

    botao_titulo.removeEventListener("click", (event) => {
        event.preventDefault();
        destroyModal();
    }, { once: true });

    botao_titulo.addEventListener("click", (event) => {
        event.preventDefault();
        destroyModal();
        connection.invoke("recusarPedido", idOrigem, idDestino).catch(function (err) {
            return console.error(err.toString());
        });
    }, { once: true });
    console.log("chegou aqui17")

    botao_modal1.addEventListener("click", (event) => {
        event.preventDefault();
        destroyModal();
        connection.invoke("aceitarPedido", idOrigem, idDestino).catch(function (err) {
            return console.error(err.toString());
        });
        buildModal("Você aceitou o pedido!", "Você aceitou o pedido de amizade! Comece a conversar ao abrir a barra lateral e clicando no nome do seu novo amigo!");
    }, { once: true });
    console.log("chegou aqui18")

    botao_modal2.addEventListener("click", (event) => {
        event.preventDefault();
        destroyModal();
        connection.invoke("recusarPedido", idOrigem, idDestino).catch(function (err) {
            return console.error(err.toString());
        });
    }, {once: true});
    console.log("chegou aqui19")
}

function destroyModal() {
    let fundo = document.getElementById("fundo");
    fundo.remove();
}
    
connection.start().then(function () {
    console.log("Conectado!");
    let amigos = document.getElementsByClassName("submit-request");
    console.log("chegou aqui1",amigos)
    for (let i = 0; i < amigos.length; i++) {
        console.log(amigos[i]);
        amigos[i].addEventListener("click", function (event) {
            event.preventDefault();
            console.log("chegou aqui2", amigos[i].id)
            connection.invoke("enviarPedidoAmizade", origem, amigos[i].id).catch(function (err) {
                return console.error(err.toString());
            });
            buildModal("Pedido de amizade enviado!", "Você enviou um pedido de amizade!")
        }, { once: true});
        console.log(amigos[i]);
    }
});

connection.on("PedidoAmizade", (idOrigem, idDestino, texto, subtexto) => {
    console.log("chegou aqui4")
    buildModal(texto, subtexto);
    modifyModal(idOrigem, idDestino);
});

connection.on("AceitarPedido", (text, subtext) => {
    buildModal(text, subtext)
});

function buildModal(text, subtext) {
    let fundo = document.createElement("div");
    fundo.classList = "fundo";
    fundo.id = "fundo";
    console.log("chegou aqui5", fundo)

    let modal = document.createElement("div");
    modal.classList = "modal alinhar-centro";
    console.log("chegou aqui6")

    let titulo_modal = document.createElement("div");
    titulo_modal.classList = ("titulo-modal");
    titulo_modal.textContent = text;
    console.log("chegou aqui7")

    let botao_titulo = document.createElement("button");
    botao_titulo.classList = "botao-modal";
    botao_titulo.id = "botao_titulo";
    console.log("chegou aqui8")

    let fechar_botao = document.createElement("i");
    fechar_botao.setAttribute("type", "submit");
    fechar_botao.classList = "fa fa-times";
    console.log("chegou aqui9")

    let divisao_tab1 = document.createElement("div");
    divisao_tab1.classList = "divisao_tab";
    console.log("chegou aqui10")

    let corpo_modal = document.createElement("div");
    corpo_modal.classList = "corpo-modal";
    corpo_modal.textContent = subtext;
    console.log("chegou aqui11")

    let divisao_tab2 = document.createElement("div");
    divisao_tab2.classList = "divisao_tab";
    console.log("chegou aqui12")

    let opcoes_modal = document.createElement("div");
    opcoes_modal.classList = "opcoes-modal";
    opcoes_modal.id = "opcoes";
    console.log("chegou aqui13")

    fundo.appendChild(modal);
    botao_titulo.appendChild(fechar_botao);
    titulo_modal.appendChild(botao_titulo);
    modal.appendChild(titulo_modal);
    modal.appendChild(divisao_tab1);
    modal.appendChild(corpo_modal);
    modal.appendChild(divisao_tab2);
    modal.appendChild(opcoes_modal);
    document.body.appendChild(fundo);
    console.log("chegou aqui16")

    botao_titulo.addEventListener("click", (event) => {
        event.preventDefault();
        destroyModal();
    });
}
