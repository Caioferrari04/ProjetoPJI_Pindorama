var connection = new signalR.HubConnectionBuilder().withUrl("/chathub").build();
let mensagemRecente;

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
        recusarPedido(idOrigem, idDestino);
    }, { once: true });

    botao_modal1.addEventListener("click", (event) => {
        event.preventDefault();
        destroyModal();
        aceitarPedido(idOrigem, idDestino);
    }, { once: true });

    botao_modal2.addEventListener("click", (event) => {
        event.preventDefault();
        destroyModal();
        recusarPedido(idOrigem, idDestino);
    }, {once: true});
}

function recusarPedido(idOrigem, idDestino) {
    console.log("x");
    connection.invoke("recusarPedido", idOrigem, idDestino).catch(function (err) {
        return console.error(err.toString());
    });
}

function aceitarPedido(idOrigem, idDestino) {
    console.log("y");
    connection.invoke("aceitarPedido", idOrigem, idDestino).catch(function (err) {
        return console.error(err.toString());
    });
    buildModal("Você aceitou o pedido!", "Você aceitou o pedido de amizade! Comece a conversar ao abrir a barra lateral e clicando no nome do seu novo amigo!");
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

    let modal = document.createElement("div");
    modal.classList = "modal alinhar-centro";

    let titulo_modal = document.createElement("div");
    titulo_modal.classList = ("titulo-modal");
    titulo_modal.textContent = text;

    let botao_titulo = document.createElement("button");
    botao_titulo.classList = "botao-modal";
    botao_titulo.id = "botao_titulo";

    let fechar_botao = document.createElement("i");
    fechar_botao.setAttribute("type", "submit");
    fechar_botao.classList = "fa fa-times";

    let corpo_modal = document.createElement("div");
    corpo_modal.classList = "corpo-modal";
    corpo_modal.textContent = subtext;

    let opcoes_modal = document.createElement("div");
    opcoes_modal.classList = "opcoes-modal";
    opcoes_modal.id = "opcoes";

    fundo.appendChild(modal);
    botao_titulo.appendChild(fechar_botao);
    titulo_modal.appendChild(botao_titulo);
    modal.appendChild(titulo_modal);
    modal.appendChild(corpo_modal);
    modal.appendChild(opcoes_modal);
    document.body.appendChild(fundo);

    botao_titulo.addEventListener("click", (event) => {
        event.preventDefault();
        destroyModal();
    });
}

function buildMessage(author, data, text, img) {

    let corpo_mensagem = document.createElement("div");
    let imagem_mensagem = document.createElement("img");
    let mensagem = document.createElement("p");
    let data_envio = document.createElement("span");

    imagem_mensagem.src = img;
    
    mensagem.textContent = text;
    mensagem.classList = "texto-chat";
    data_envio.textContent = data;

    if (author === origem) {
        corpo_mensagem.classList = "container-darker";
        data_envio.classList = "time-left";
        imagem_mensagem.className = "right"
    }
    else {
        corpo_mensagem.classList = "container-chat";
        data_envio.classList = "time-right";
        imagem_mensagem.className = "left"
    }

    corpo_mensagem.appendChild(imagem_mensagem);
    corpo_mensagem.appendChild(mensagem);
    corpo_mensagem.appendChild(data_envio);
    return corpo_mensagem;
}

connection.on("CarregarMensagens", (mensagens, destino) => {
    dialogo = document.getElementById("dialogo-" + destino);
    for (let i = 0; i < mensagens.length; i++) {
        let mensagem = buildMessage(mensagens[i].nome, formatDate(mensagens[i].data), mensagens[i].text, mensagens[i].img);
        if (i === mensagens.length - 1) {
            guardarMensagem(mensagens[i]);
        }
        dialogo.appendChild(mensagem)
    }
    dialogo.scrollTop = dialogo.scrollHeight;
});

function guardarMensagem(mensagem) {
    mensagemRecente = mensagem
}

function formatDate(dateString) {
    var date = new Date(Date.parse(dateString))
    var dateStr =
        ("00" + date.getDate()).slice(-2) + "/" +
        ("00" + (date.getMonth() + 1)).slice(-2) + " " +
        ("00" + date.getHours()).slice(-2) + ":" +
        ("00" + date.getMinutes()).slice(-2)
    return dateStr
}

connection.on("RemovidoGrupo", () => {
    console.log("Removido do grupo!");
});

connection.on("ReceberMensagem", (msg, origemMsg, destino) => {
    console.log("recebeuMensagem")
    let mensagem = buildMessage(msg.nome, formatDate(msg.data), msg.text, msg.img)
    guardarMensagem(msg);
    let id = origemMsg != origem ? origemMsg : destino
    console.log(id, origemMsg, destino)
    dialogo = document.getElementById("dialogo-" + id);
    dialogo.appendChild(mensagem);
    dialogo.scrollTop = dialogo.scrollHeight;
});

connection.on("somarLike", (postId, isPost, sub) => {
    let soma_like = isPost ? document.getElementById("qtyLikes_" + postId) : document.getElementById("qtyLikes_c_" + postId);
    try {
        console.log(soma_like);
        let numLike = parseInt(soma_like.textContent);
        numLike = sub ? numLike - 1 : numLike + 1;
        soma_like.innerHTML = numLike;
    } catch (ex) {
        console.log(ex);
    }
});
