function CargaInicial()
{
    desbloqueaDatos('#div_cabecera');
    bloqueaDatos('#div_datos_empresa');
    bloqueaDatos('#div_datos_cliente');
    bloqueaDatos('#div_tipo_proyecto');
    $("#b_editar").removeClass("disabled");
    $("#b_guardar").addClass("disabled");
    $('.input_rut').rut();
    $('.search-select').select2();
    $('.i-checks').iCheck({
        checkboxClass: 'icheckbox_square-blue',
        radioClass: 'iradio_square-blue',
    });

}

function Continuar() {
    //llaves para id
    var rut = $('#tbRutBusqueda').val();
    if (rut == "") {
        alert_warning('para continuar. Ingrese un rut');
        return;
    }
    console.log(rut);
    url = url_continuar + '?rut=' + rut;

    $.get(url, function (data) {
        if (data == "") {
            $("#b_guardar").removeClass("disabled");
            $("#b_editar").addClass("disabled");
            desbloqueaDatos('#div_datos_empresa');
            desbloqueaDatos('#div_datos_cliente');
        } else {
            $('#iIdCliente').val(data.Id);
            $('#tbRazonSocial').val(data.RazonSocial);
            $('#tbDireccion').val(data.Direccion);
            $('#iregion').val(data.IdRegion);
            $('#tbGiro').val(data.Giro);
            $('#tbNombre').val(data.NombreContacto);
            $('#tbApellido').val(data.ApellidoContacto);
            $('#tbCorreo').val(data.CorreoContacto);
            $('#tbTelefono').val(data.TelefonoContacto);

            $("#b_editar").removeClass("disabled");
            $("#b_guardar").addClass("disabled");
            console.log($('#iIdCliente').val());
        }
        setTimeout(function () {
            CargaComunas();


        }, 500);
        //espero y lanzo el foco al primer control de datos
        setTimeout(function () {
            $("#icomuna").val(data.IdComuna);
            $('#itipoproyecto').focus();

            bloqueaDatos('#div_cabecera');
            bloqueaDatos('#div_datos_empresa');
            bloqueaDatos('#div_datos_cliente');
            desbloqueaDatos('#div_tipo_proyecto');
        }, 500);
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
                $.each(response.Resultados, function (i, e) {
                    $('#icomuna').append($("<option></option>").val(e.Value).html(e.Text));

                });
            }
        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });
}
function CargaComunasEnvio() {
    $("#iComunaEnvio").empty();
    var identificador = $("#iRegionEnvio :selected").val();
    $.ajax({
        url: url_cargarcomunas,
        type: "post",
        data: {
            id: identificador
        },
        success: function (response) {
            if (!response.error) {
                $.each(response.Resultados, function (i, e) {
                    $('#iComunaEnvio').append($("<option></option>").val(e.Value).html(e.Text));

                });
            }
        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });
}


function MostrarProyectoSeleccionado() {
    var tp = $("#itipoproyecto :selected").val();
    var rut = $('#tbRutBusqueda').val();

    $.get(url_mostrarproyecto, { tipoProyecto: tp, rut: rut }, function (data) {
        var id_control_foco = '#L14_NUMRUT';
        console.log(data);

        switch (data) {
            case "CotizacionEstandar":
                $.get(url_createEstandarget, function (data) {
                    ////lleno y despliego el dialogo de edición
                    $('#container_Cotizacion').html(data);
                    Carga_GrillaProductoSeleccionado();
                    Carga_GrillaParametros();
                    $('#my-card').CardWidget('toggle')

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
                    $('#container_Cotizacion').html(data);
                    //$('#div_EditModal').modal('show');
                    $('#my-card').CardWidget('toggle')

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

function Carga_GrillaProductoSeleccionado(identificador) {
    $.ajax({
        url: url_carga_productoSeleccionado,
        datatype: "html",
        type: "get",
        data: {
            id: identificador
        },
        success: function (response) {
            console.log(response)
            $("#div_grilla_productoSeleccionado").html('').html(response);
            $('#ModalMediano').modal('hide');
        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });
}
function Carga_GrillaParametros(identificador) {
    $.ajax({
        url: url_carga_parametros,
        datatype: "html",
        type: "get",
        data: {
            id: identificador
        },
        success: function (response) {
            console.log(response)
            $("#div_grilla_parametros").html('').html(response);
            $('#ModalMediano').modal('hide');
        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });
}

function CargaModal_SubParametros(identificacion) {

    muestraContenidoModal(
        'GrillaSubParametros',
        'Formularios',
        'Sub Parametros',
        'get',
        {
            id: identificacion
        },
        {
            beforeSend: function () { },
            complete: function () { }
        },
        "mediano"
    );
}
function CargaModal_Productos(identificacion) {

    muestraContenidoModal(
        'GrillaProductos',
        'Formularios',
        'Productos',
        'get',
        {
            id: identificacion
        },
        {
            beforeSend: function () { },
            complete: function () { }
        },
        "mediano"
    );
}
$("#b_editar").click(function () {
    $("#b_guardar").removeClass("disabled");
    $("#b_editar").addClass("disabled");
    desbloqueaDatos('#div_datos_empresa');
    desbloqueaDatos('#div_datos_cliente');
    bloqueaDatos('#div_tipo_proyecto');
    
});

//function SubmitForm(form) {
//    $.ajax({
//        type: "POST",
//        url: form.action,
//        data: $(form).serialize(),
//        success: function (data) {
//            if (data.success) {
//                alert_success('Dato almacenado con éxito.');//exito);
//                //alert_success(data.message);
//                console.log("data.success")
//                bloqueaDatos('#div_datos_empresa');
//                bloqueaDatos('#div_datos_cliente');
//                $("#b_editar").removeClass("disabled");
//                $("#b_guardar").addClass("disabled");
//                desbloqueaDatos('#div_tipo_proyecto');
//            } else {
//                alert_error(data.message);
//            }
//        }
//    });

//    return false;

//};
    //$.ajax({
    //    type: "POST",
    //    url: url_createCliente,
    //    data: $('#formSolcitud').submit(),
    //    success: function (data) {
    //        if (data.status) {
    //            debugger;
    //            alert_success('Dato almacenado con éxito.');//exito);
    //            bloqueaDatos('#div_datos_empresa');
    //            bloqueaDatos('#div_datos_cliente');
    //            $("#b_editar").removeClass("disabled");
    //            $("#b_guardar").addClass("disabled");
    //            desbloqueaDatos('#div_tipo_proyecto');
    //        }
    //        else {
    //            alert_error(data.error);
    //        }

    //    }
    //});
//});
//$("#b_guardar").click(function () {
//    $("#formSolcitud").submit();
//    bloqueaDatos('#div_datos_empresa');
//    bloqueaDatos('#div_datos_cliente');
//    $("#b_editar").removeClass("disabled");
//    $("#b_guardar").addClass("disabled");
//    desbloqueaDatos('#div_tipo_proyecto');
    
//});

///**** Create Ajax Form CallBack ********/

function OnBeginRequest() {

    alert('On Begin');

}

function OnCompleteRequest() {

    alert('On Completed');

}

function OnSuccessRequest() {

    alert('On Success');

}

function OnFailureRequest() {

    alert('On Failure');

}

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

        alert_success('Registro Ingresado Exitosamente.');
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
