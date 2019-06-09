var ExibirComponentes = () => {
    const index = document.getElementById("ddlTipoCliente").value;
    if (index == 0) {
        HideContent();
    } else if (index == 1) {
        ExibirComponentesFisica();
        ShowContent();
    } else if (index == 2) {
        ExibirComponentesJuridica();
        ShowContent();
    }
    try {
        SetMask();
    } catch (err) { }
}

var ExibirComponentesFisica = () => {

    const div = document.getElementsByClassName("pessoa-juridica");
    for (var i = 0; i < div.length; i++) {
        div[i].classList.add("hide-element");
    }
    var lblNome = document.getElementById("nomeCliente");
    var lblDocumento = document.getElementById("documentoCliente");

    lblNome.innerHTML = "Nome Completo";
    lblDocumento.innerHTML = "CPF";

    const inputDoc = document.getElementById("TxtEmitenteDocumento");
    inputDoc.classList.remove("cnpj");
    inputDoc.classList.add("cpf");

    LimparCamposJuridica();
}

var ExibirComponentesJuridica = () => {
    const div = document.getElementsByClassName("pessoa-juridica");
    for (var i = 0; i < div.length; i++) {
        div[i].classList.remove("hide-element");
    }

    var lblNome = document.getElementById("nomeCliente");
    var lblDocumento = document.getElementById("documentoCliente");
    lblNome.innerHTML = "Razão Social";
    lblDocumento.innerHTML = "CNPJ";

    const inputDoc = document.getElementById("TxtEmitenteDocumento");
    inputDoc.classList.remove("cpf");
    inputDoc.classList.add("cnpj");
}

var ShowContent = () => {
    const div = document.getElementById("formCliente");
    div.classList.remove("hide-element");
}

var HideContent = () => {
    const div = document.getElementById("formCliente");
    div.classList.add("hide-element");
}

var LimparCamposJuridica = () => {
    var fantasia = document.getElementById("TxtEmitenteNmFantasia");
    var inscricaoEstadual = document.getElementById("TxtEmitenteIE");
    fantasia.value = "";
    inscricaoEstadual.value = "";
}