var cidadeCascata = (edit) => {
    const ddlEstado = document.getElementById("DropDownEstado");
    var select = $('#DropDownCidade');
    $(select).empty();
    $.getJSON(EmitenteUrl.CidadeCascata + "?estadoID=" + ddlEstado.selectedIndex, function (result) {
        $.each(result, function (i, field) {
            $('<option>', {
                value: field.Codigo
            }).html(field.Nome).appendTo(select);
        });
    });
}