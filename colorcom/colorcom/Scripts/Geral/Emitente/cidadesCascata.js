var cidadeCascata = (edit) => {
    const ddlEstado = document.getElementById("DropDownEstado");
    filtrarCidades(ddlEstado.selectedIndex);
}

var filtrarCidades = (estadoId) => {
    var ddlCidade = $('#DropDownCidade');
    $(ddlCidade).empty();
    $.getJSON(EmitenteUrl.CidadeCascata + "?estadoID=" + estadoId, function (result) {
        $.each(result, function (i, field) {
            $('<option>', {
                value: field.Codigo
            }).html(field.Nome).appendTo(ddlCidade);
        });
    });
}
