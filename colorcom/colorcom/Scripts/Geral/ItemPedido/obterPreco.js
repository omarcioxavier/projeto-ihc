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
    //var precoOriginal = result[0].Preco;
    var precoOriginal = 60;//Apagar
    var qtd = parseInt(document.getElementById("TxtBoxQuantidade").value);
    var total = qtd * precoOriginal;
    $('#TxtBoxPreco').val(total);
}

var atualizarSubtotal = (btn) => {
    var linha = $(btn).closest("tr");
    var precoVenda = parseFloat(linha.find("#tdPreco").text());
    var qtdAtual = parseInt(linha.find("#tdQtd").text());
    var subTotal = parseFloat(linha.find("#tdSubTotal").text());
    
    if (btn.id == "btnMais"){
        if (qtdAtual < 10){
            qtdAtual ++;
            subTotal = qtdAtual * precoVenda;
            linha.find("#tdSubTotal").text(subTotal);
            linha.find("#tdQtd").text(qtdAtual);
        }
    }else{
        if (qtdAtual > 1){
            qtdAtual --;
            subTotal = qtdAtual * precoVenda;
            linha.find("#tdSubTotal").text(subTotal);
            linha.find("#tdQtd").text(qtdAtual);
        }
    }
    atualizarTotal();
    //var precoOriginal = result[0].Preco;
    // var precoOriginal = 60;//Apagar
    // var qtd = parseInt(document.getElementById("TxtBoxQtdRow").value);
    // var total = qtd * precoOriginal;
    // $('#TxtBoxPreco').val(total);    
}

var atualizarTotal = () => {
    var total = 0;
    var tabela = document.getElementById("tabelaItens");
    for(var i = 1; i < tabela.rows.length - 1; i++)
    {
        total = total + parseFloat(tabela.rows[i].cells[4].innerHTML);
    }
    $('#tdTotal').text(total);
}

var adicionarItem = (item) => {
    var row = '<tr> <th scope="row">1</th> <td>Pincel</td> <td id="tdPreco">20</td><td id="tdQtd" class="fit-column">1</td><td id="tdSubTotal" class=".calc-sub">20</td> <td class="fit-column"> <button type="button" class="btn btn-success btn-sm" id="btnMais" onclick="atualizarSubtotal(this)"><b>+</b></button> <button type="button" class="btn btn-warning btn-sm" id="btnMenos" onclick="atualizarSubtotal(this)"><b>-</b></button> <button type="button" class="btn btn-outline-danger btn-sm" onclick="removerItem(this)">Remover</button> </td> </tr>';
    $('#tabelaItens tr:last').before(row);
}

var removerItem = (item) => {
	var tr = $(item).closest('tr');	
    tr.remove();
    return false;
}
