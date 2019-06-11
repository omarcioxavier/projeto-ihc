var cidadeCascata = (edit) => {
    const ddlEstado = document.getElementById("DropDownEstado");
    if (edit == 0) {
        filtrarCidades(ddlEstado.selectedIndex);
    } else {
    }
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