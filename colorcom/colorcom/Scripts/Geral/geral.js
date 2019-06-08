$(document).ready(function () {
    try {
        SetLabels();
    } catch (err) { }
    try {
        SetTextEditors();
    } catch (err) { }
});

var SetTextEditors = () => {
    SetDisableTextField();
}

var SetLabels = () => {
    SetStatusLabel();
}

var SetStatusLabel = () => {
    const cb = document.getElementById("SwitchStatus");
    if (cb.checked) {
        document.getElementById("lblStatus").innerHTML = "Ativo";
    }
    else {
        document.getElementById("lblStatus").innerHTML = "Inativo";
    }
}

var SetDisableTextField = () => {
    const txtBox = document.getElementsByClassName("disabled");
    for (var i = 0; i < txtBox.length; i++) {
        txtBox[i].disabled = true;
    }
}

var ConfirmDialog = (texto) => {
    bootbox.confirm("" + texto + "", function (result) {
        return;
    });
}