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
   

    "columns": [
        { "data": "Id", "name": "Id", "autoWidth": true },
        { "data": "Rut", "name": "Rut", "autoWidth": true },
        { "data": "Nombre", "title": "Nombre", "name": "Nombre", "autoWidth": true },
        { "data": "ApellidoPaterno", "name": "ApellidoPaterno", "autoWidth": true },
        { "data": "ApellidoMaterno", "name": "ApellidoMaterno", "autoWidth": true },
        { "data": "Correo", "name": "Correo", "autoWidth": true },
        { "data": "idPerfil", "name": "idPerfil", "autoWidth": true },
        { "data": "Estado", "name": "Estado", "title": "Estado", "autoWidth": true },
        {
            "data": "Id", "name": "Id", "autoWidth": true, "searchable": false, "sortable": false, "render": function (data) {
                
                salida = '<a class="editclass btn btn-success btn-sm" href="' + url_edit + '?id=' + data + '"' + ' title="Editar">Editar&nbsp;<span class="glyphicon glyphicon-pencil" /></a> ';
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
function Busqueda() {
    muestraContenidoModal('GrillaParametros', 'Denegaciones', 'Busqueda', 'get', {
        beforeSend: function () {
            //$this.loadingButton({ accion: "loading" })
        },
        complete: function () {
            //$this.loadingButton({ accion: "reset" })
        }
    }, '', 'grande');
}
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


