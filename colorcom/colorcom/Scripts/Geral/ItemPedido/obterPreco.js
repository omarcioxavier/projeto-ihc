var obterPreco = () => {
    var item = document.getElementById("DropDownItem");
    try {
        $.getJSON(ItemPedidoUrl.itemSelecionado + "?itemID=" + item.value, function (result) {
            $.each(result, function (i, field) {
                atualizarPreco(result);
            });
        });
    }
    catch (err) {
        $('#TxtBoxPreco').val("0");
    }
}

var atualizarPreco = (result) => {
    var preco = document.getElementById("TxtBoxPreco");
    preco.value = result[0].Preco;
    calcularValor();
}

var calcularValor = () => {
    //var total = 0;
    var preco = parseInt(document.getElementById("TxtBoxPreco").value);
    var qtd = parseInt(document.getElementById("TxtBoxQuantidade").value);
    var total = preco * qtd;
    console.log(preco + "*" + qtd + "=" + total);
    $('#TxtBoxPreco').val(total);
}