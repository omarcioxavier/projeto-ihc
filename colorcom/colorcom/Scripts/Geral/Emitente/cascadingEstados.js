///Filtrando cidades de acordo com o estado selecionado
//$(document).ready(function () {
//    //Pega o índice dos DropDown de Estado e Cidade
//    const stateIndex = document.getElementById("DropDownEstado").selectedIndex;
//    const cityIndex = document.getElementById("DropDownCidade").selectedIndex;


//    //Se já existe Cidade e Estado selecionados, no caso de Editar, faz o filtro e seleciona a cidade correta
//    //Sem filtro nesta etapa, irão aparecer todas as cidades de todos os estados na DropDown
//    if ((stateIndex !== 0) && (cityIndex !== 0)) {

//        //Pega o ID da Cidade da BD
//        const cityID = ($("#cityID").val());

//        //Função GET para filtrar as Cidades pelo Estado
//        $.ajax({
//            type: "GET",
//            data: { stateID: stateIndex },
//            url: MyAppUrlSettings.CascadeStates,// /Company/GetCities
//            success: function (result) {
//                var aux = 0;
//                var c = '<option value = "- 1">Cidade</option>';
//                for (var i = 0; i < result.length; i++) {
//                    c += '<option value ="' + result[i].Id + '">' + result[i].Name + '</option>';

//                    //Salva o índice do for para usar no índice do DropDown
//                    if (result[i].Id == cityID) {
//                        aux = i + 1;
//                    }

//                }
//                $('#DropDownCity').html(c);

//                //Setar no DropDown a cidade com o ID correto
//                $("select#DropDownCity").prop('selectedIndex', aux);
//            }
//        });
//    }
//    //Se não, apenas desabilita a DropDown Cidade até que seja selecionado um Estado
//    else {
//        $("#DropDownCity").prop("disabled", true);
//    }

//    //Ao selecionar um estado, verifica se não é o 1° índice vazio da DropDown 
//    $("#DropDownState").on("change", function () {
//        const state = $("#DropDownState option:selected").val();
//        if (document.getElementById("DropDownState").selectedIndex === 0) {
//            $("#DropDownCity").prop("disabled", true);
//            $("select#DropDownCity").prop('selectedIndex', 0);
//        }
//        //Se não for, faz o Filtro com Ajax
//        else {
//            $("#DropDownCity").prop("disabled", false);
//            //Ajax Aqui
//            $.ajax({
//                type: "GET",
//                data: { stateID: state },
//                url: MyAppUrlSettings.CascadeStates,// /Company/GetCities
//                success: function (result) {
//                    var c = '<option value = "- 1">Cidade</option>';
//                    for (var i = 0; i < result.length; i++) {
//                        c += '<option value ="' + result[i].Id + '">' + result[i].Name + '</option>';
//                    }
//                    $('#DropDownCity').html(c);
//                }
//            });
//        }
//    });
//});