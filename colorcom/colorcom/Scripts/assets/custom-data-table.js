//$(document).ready(function () {
//    $.fn.dataTable.moment('DD/MM/YYYY HH:mm:ss');
//    $.fn.dataTable.moment('DD/MM/YYYY');
//    $.fn.dataTable.moment('HH:mm:ss');
//    $.fn.dataTable.Buttons.defaults.dom.button.className = 'btn btn-default btn-sm';
//    $(this).css("width", "100%");
//    $('.data-table').DataTable({
//        dom: 'Bfrtip',
//        sScrollX: "auto",
//        bScrollCollapse: true,
//        bPaginate: true,
//        buttons: [
//            {
//                extend: 'colvis',
//                collectionLayout: 'fixed two-column',
//                text: 'Colunas',
//                exportOptions: {
//                    columns: ':visible'
//                }
//            },
//            {
//                extend: 'excelHtml5',
//                exportOptions: {
//                    columns: ':visible',
//                    format: {
//                        body: function (data) {
//                            data = $('<p>' + data + '</p>').text();
//                            return $.isNumeric(data.replace(',', '.')) ? data.replace(',', '.') : data;
//                        }
//                    }
//                }
//            },
//            {
//                extend: 'print',
//                text: 'Imprimir',
//                exportOptions: {
//                    columns: ':visible'
//                }
//            }
//        ],
//        "pageLength": 10,
//        "language": {
//            url: '//cdn.datatables.net/plug-ins/1.10.19/i18n/Portuguese-Brasil.json',
//            decimal: ",",
//            thousands: "."
//        }
//    });
//});