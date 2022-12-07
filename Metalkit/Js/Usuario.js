
$("#Agregar").on("click", function () {
    $('#editModalContentAgregar').load(this.href, function () {
        $('#ModalAgregar').modal({
            keyboard: true

        }, 'show');
    });
    return false;
});

//$("#Grilla_Parametro").DataTable({

//        "processing": true, // for show progress bar  
//        "serverSide": true, // for process server side  
//        "filter": true, // this is for disable filter (search box)  
//        "orderMulti": false, // for disable multiple column at once  
//        "pageLength": 5,

//        "ajax": {
//            "url": "/MantUsuarios/ObtenerConsultas",
//            "type": "POST",
//            "datatype": "json"
//        },

//        "columnDefs":
//            [{
//                "targets": [0],
//                "visible": false,
//                "searchable": false
//            },
//            {
//                "targets": [7],
//                "searchable": false,
//                "orderable": false
//            },
//            {
//                "targets": [8],
//                "searchable": false,
//                "orderable": false
//            },
//            {
//                "targets": [9],
//                "searchable": false,
//                "orderable": false
//            }],

//        "columns": [
//            { "data": "Id", "name": "Id", "autoWidth": true },
//            { "data": "Rut", "name": "Rut", "autoWidth": true },
//            { "data": "Nombre", "title": "Nombre", "name": "Nombre", "autoWidth": true },
//            { "data": "ApellidoPaterno", "name": "ApellidoPaterno", "autoWidth": true },
//            { "data": "ApellidoMaterno", "name": "ApellidoMaterno", "autoWidth": true },
//            { "data": "Correo", "name": "Correo", "autoWidth": true },
//            { "data": "idPerfil", "name": "idPerfil", "autoWidth": true },
//            { "data": "Estado", "name": "Estado", "title": "Estado", "autoWidth": true },
//            {
//                "render": function (data, type, full, meta) { return '<a class="btn btn-info" href="/Demo/Edit/' + full.CustomerID + '">Edit</a>'; }
//            },
//            {
//                data: null, render: function (data, type, row) {
//                    return "<a href='#' class='btn btn-danger' onclick=DeleteData('" + row.CustomerID + "'); >Delete</a>";
//                }
//            },

//        ]

//    });
//$("#Editar").on("click", function () {
//    $('#editModalContentEditar').load("@Url.Action("Edit", "Usuarios")?id=" + 1, function () {
//        $('#ModalEditar').modal({
//            keyboard: true
//        }, 'show');
//    });
//    return false;
//});
//$("#Eliminar").on("click", function () {
//    $('#editModalContentEliminar').load("@Url.Action("delete ", "Usuarios")?id=" + 1, function () {
//        $('#ModalEliminar').modal({
//            keyboard: true
//        }, 'show');
//    });
//    return false;
//});