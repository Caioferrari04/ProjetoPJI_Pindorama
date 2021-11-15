var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();


function buildModal(idOrigem, idDestino, nomeUsuario) {
    console.log("chegou aqui3")
    let fundo = document.createElement("div");
    fundo.classList = "fundo";
    fundo.id = "fundo";
    console.log("chegou aqui5", fundo)

    let modal = document.createElement("div");
    modal.classList = "modal alinhar-centro";
    console.log("chegou aqui6")

    let titulo_modal = document.createElement("div");
    titulo_modal.classList = ("titulo-modal");
    titulo_modal.textContent = "Você recebeu um pedido de amizade de " + nomeUsuario + "!";
    console.log("chegou aqui7")

    let botao_titulo = document.createElement("button");
    botao_titulo.classList = "botao-modal";
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
    corpo_modal.textContent = nomeUsuario + " enviou-lhe um pedido de amizade, deseja aceitar?"
    console.log("chegou aqui11")

    let divisao_tab2 = document.createElement("div");
    divisao_tab2.classList = "divisao_tab";
    console.log("chegou aqui12")

    let opcoes_modal = document.createElement("div");
    opcoes_modal.classList = "opcoes-modal";
    console.log("chegou aqui13")

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

    fundo.appendChild(modal);
    botao_titulo.appendChild(fechar_botao);
    titulo_modal.appendChild(botao_titulo);
    opcoes_modal.appendChild(botao_modal1);
    opcoes_modal.appendChild(botao_modal2);
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
        connection.invoke("recusarPedido", idOrigem, idDestino).catch(function (err) {
            return console.error(err.toString());
        });
    });
    console.log("chegou aqui17")

    botao_modal1.addEventListener("click", (event) => {
        event.preventDefault();
        destroyModal();
        connection.invoke("AceitarPedido", idOrigem, idDestino).catch(function (err) {
            return console.error(err.toString());
        });
    });
    console.log("chegou aqui18")

    botao_modal2.addEventListener("click", (event) => {
        event.preventDefault();
        destroyModal();
        connection.invoke("recusarPedido", idOrigem, idDestino).catch(function (err) {
            return console.error(err.toString());
        });
    });
    console.log("chegou aqui19")
}

function destroyModal() {
    console.log("chegou aqui21")
    let fundo = document.getElementById("fundo");
    console.log("chegou aqui22")
    fundo.remove();
    console.log("chegou aqui23")
}
    
connection.start().then(function () {
    connection.invoke("CreateConnection", connection.connectionId, origem)
    console.log("Conectado!");
    let amigos = document.getElementsByClassName("submit-request");
    console.log("chegou aqui1",amigos)
    for (let i = 0; i < amigos.length; i++) {
        console.log(amigos[i]);
        amigos[i].addEventListener("click", function (event) {
            event.preventDefault();
            console.log("chegou aqui2")
            connection.invoke("enviarPedidoAmizade", parseInt(origem), parseInt(amigos[i].id)).catch(function (err) {
                return console.error(err.toString());
            });
        });
        console.log(amigos[i]);
    }
});

connection.on("PedidoAmizade", (idOrigem, idDestino, nomeUsuario) => {
    console.log("chegou aqui4")
    buildModal(idOrigem, idDestino, nomeUsuario);
});
