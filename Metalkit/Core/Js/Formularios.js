﻿function Continuar() {
    //llaves para id
    var rut = $('#tbRutBusqueda').val();
    console.log(rut);
    url = url_continuar + '?rut=' + rut;

    $.get(url, function (data) {
        console.log(data);
        desbloqueaDatos('#div_datos');
        bloqueaDatos('#div_cabecera');

        $('#tbRazonSocial').val(data.RazonSocial);
        $('#tbDireccion').val(data.Direccion);
        $('#iregion').val(data.IdRegion);
        $('#tbGiro').val(data.Giro);
        $('#tbNombre').val(data.NombreContacto);
        $('#tbApellido').val(data.ApellidoContacto);
        $('#tbCorreo').val(data.CorreoContacto);
        $('#tbTelefono').val(data.TelefonoContacto);
        CargaComunas();
        //espero y lanzo el foco al primer control de datos
        setTimeout(function () {
            $('#iComuna').val(data.IdComuna);
            $('#itipoproyecto').focus();

        }, 500);
    });
}

function cargaGrilla() {
    var oTable = $("#tabla_Producto").DataTable({
        "processing": false,
        "serverSide": true,
        "filter": false,
        "orderMulti": false,
        "pagingType": "full_numbers",
        "paging": false,
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
            { "data": "id", "name": "id", "autoWidth": true },
            { "data": "codigo", "title": "Código", "name": "codigo", "autoWidth": true },
            { "data": "descripcion", "title": "Descripción", "name": "Descripción", "autoWidth": true },
            { "data": "superficie", "title": "Superficie", "name": "Superficie", "autoWidth": true },
            { "data": "precio", "title": "Precio", "name": "Precio", "autoWidth": true }
        ]
    });
}

function CargarProyecto() {
    var identificador = $("#iproyecto :selected").val();
    $.get(url_cargarproyecto, { id: identificador }, function (data) {
        var id_control_foco = '#L14_NUMRUT';
        console.log(data);

        switch (data) {
            case "Ok":
                cargaGrilla();
                break;
            default:
                console.log(data.responseText);
        }
    });
}

function CargaComunas() {
    $("#icomuna").empty();
    var identificador = $("#iregion :selected").val();
    $.ajax({
        url: url_cargarcomunas,
        type: "post",
        data: {
            id: identificador
        },
        success: function (response) {
            if (!response.error) {
                $.each(response, function (i, e) {
                    $('#icomuna').append('<option value="' + e.Value + '">' + e.Text + '</option>');
                });
            }
        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });
}

function CargaComunasEnvio() {
    $("#icomunaEnvio").empty();
    var identificador = $("#iregionEnvio :selected").val();
    $.ajax({
        url: url_cargarcomunas,
        type: "post",
        data: {
            id: identificador
        },
        success: function (response) {
            if (!response.error) {
                $.each(response, function (i, e) {
                    $('#icomunaEnvio').append('<option value="' + e.Value + '">' + e.Text + '</option>');
                });
            }
        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });
}

function MostrarProyectoSeleccionado() {
    var identificador = $("#itipoproyecto :selected").val();

    $.get(url_mostrarproyecto, { id: identificador }, function (data) {
        var id_control_foco = '#L14_NUMRUT';
        console.log(data);

        switch (data) {
            case "CotizacionEstandar":
                $.get(url_createEstandar, function (data) {
                    ////lleno y despliego el dialogo de edición
                    $('#container').html(data);
                    //$('#div_EditModal').modal('show');
                    //espero y lanzo el foco al primer control de datos
                    setTimeout(function () {
                        //$('#Clases').focus();
                        //$('#Nombres').prop('readonly', true);

                    }, 500);
                });
                break;
            case "CotizacionPersonalizada":
                $.get(url_createPersonalizada, function (data) {
                    ////lleno y despliego el dialogo de edición
                    $('#container').html(data);
                    //$('#div_EditModal').modal('show');

                    //espero y lanzo el foco al primer control de datos
                    setTimeout(function () {
                        //$('#Clases').focus();
                        //$('#Nombres').prop('readonly', true);
                        //$('#L14_FECDURAC').prop('readonly', true);

                    }, 500);
                });
                break;
            default:
                console.log(data.responseText);
        }
    });
}

$("btnEditar").click(function () {
    $("btnGuardar").removeClass("hidden");
    $("btnEditar").addClass("hidden");
});

$("btnGuardar").click(function () {
    $("btnEditar").removeClass("hidden");
    $("btnGuardar").addClass("hidden");
});

///**** Create Ajax Form CallBack ********/
function CreateEstandar_Success(data) {
    console.log("CreateEstandar_Success");
    console.log(data.status);

    if (data.status !== "success") {
        //$('#create_Container').html(data);
        alert_error('Error, No se ha podido Ingresar el Registro ' + data.errors,
            function () {
                setTimeout(function () {
                    //$('#TipoDenegacion').focus();
                }, 500);
            }
        );

        habilita_div_datos();

        return;
    } else {
        //$('#div_CreateModal').modal('hide');
        //Grid_VM.refresh();

        $('#create_Container').html("");

        //$('#create_Container').load(url_create);
        ////$.get(url_create, function (data) {
        ////espero y lanzo el foco al primer control de datos
        //setTimeout(function () {
        //    $('#TipoDenegacion').focus();
        //    $('#TipoDenegacion').select();
        //}, 500);

        alert_success('OK', 'Registro Ingresado Exitosamente.');
    }
}

function Create_Failure(data) {

    console.log(data.responseText);

}
///**** Edit Ajax Form CallBack ********/
function Update_Success(data) {
    console.log(data.status);
    if (data.status !== "success") {
        $('#edit_Container').html(data);
        alert_error('Error', 'Error, No se ha podido Modificar el Registro' + data);
        return;
    } else {
        //$('#div_EditModal').modal('hide');
        $('#create_Container').html("");
        //$('#edit_Container').html("");
        //Grid_VM.refresh();
        alert_success('OK', 'Registro Modificado Exitosamente.');

    }


}
///**** Delet Ajax Form CallBack ********/
function Delete_Success(data) {

    if (data !== "success") {
        $('#delete_Container').html(data);
        mensaje('Error', 'Error,No se ha podido Eliminar el Registro');
        return;
    }
    $('#div_DeleteModal').modal('hide');
    $('#delete_Container').html("");
    Grid_VM.refresh();
    mensaje('OK', 'Registro Eliminado Exitosamente.');
}


//$("#Agregar").on("click", function () {
//    $('#editModalContentAgregar').load(this.href, function () {
//        $('#ModalAgregar').modal({
//            keyboard: true
//        }, 'show');
//    });
//    return false;
//});
