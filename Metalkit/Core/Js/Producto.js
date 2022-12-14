var oTable = $("#Grilla_Parametro").DataTable({
    //"processing": false,
    "serverSide": true,
    //"filter": false,
    //"orderMulti": false,
    "pagingType": "full_numbers",

    "language": datatableIdioma(),
    "ajax": {
        "url": url_datatable,
        "data": function (d) {
            d.filtro = "";
        },
        "type": "POST",
        "datatype": "json"
    },
    //"columnDefs":
    //    [{
    //        "targets": [0],
    //        "visible": false,
    //        "searchable": false
    //    },
    //    {
    //        "targets": [7],
    //        "searchable": false,
    //        "orderable": false
    //    },
    //    {
    //        "targets": [8],
    //        "searchable": false,
    //        "orderable": false
    //    },
    //    {
    //        "targets": [9],
    //        "searchable": false,
    //        "orderable": false
    //    }],

    "columns": [
        { "data": "Id", "name": "Id", "autoWidth": true },
        { "data": "Codigo", "title": "Codigo", "name": "Codigo", "autoWidth": true },
        { "data": "Descripcion", "title": "Descripcion", "name": "Descripcion", "autoWidth": true },
        { "data": "Superficie", "name": "Superficie", "autoWidth": true },
        { "data": "Precio", "name": "Precio", "autoWidth": true },
        { "data": "Imagen", "name": "Imagen", "autoWidth": true },
        {
            "data": "Id", "name": "Id", "autoWidth": true, "searchable": false, "sortable": false, "render": function (data) {
                
                salida = '<a class="editclass btn-success btn-sm" href="' + url_edit + '?id=' + data + '"' + ' title="Editar">Editar&nbsp;<span class="glyphicon glyphicon-pencil" /></a> ';
                salida += '<a class="deleteclass btn btn-danger btn-sm" href="' + url_delete + '?id=' + data + '"' + ' title="Editar">Eliminar&nbsp;<span class="glyphicon glyphicon-trash" /></a> ';

                return salida;
                //  return salida;
            }
        },

    ],
    dom: 'Bfrtip',
    buttons: [
        'copy', 'csv', 'excel', 'pdf', 'print'
    ]

});

////metodos get
$("#btnAgregar").on("click", function () {

    var url = $(this).data("url");
    console.log(url)
    $.get(url, function (data) {
        $('#createContainer').html(data);
        $('#createModal').modal('show');
    });

});
$('#Grilla_Parametro').on("click", ".editclass", function (event) {

    event.preventDefault();

    var url = $(this).attr("href");

    $.get(url, function (data) {
        $('#editContainer').html(data);

        $('#editModal').modal('show');
    });

});
$('#Grilla_Parametro').on("click", ".deleteclass", function (event) {

    event.preventDefault();

    var url = $(this).attr("href");

    $.get(url, function (data) {
        $('#editContainer').html(data);

        $('#editModal').modal('show');
    });

});

//$("#Agregar").on("click", function () {
//    $('#editModalContentAgregar').load(this.href, function () {
//        $('#ModalAgregar').modal({
//            keyboard: true
//        }, 'show');
//    });
//    return false;
//});


