var script = document.createElement('script');
script.src = './Scripts/assets/plugins/bootbox/bootbox.js';
document.head.appendChild(script);

function mostrarMensaje(content, tipo) {
    $(document).ready(function () {
        switch (tipo) {
            case "Exito": // mensaje de proceso correcto 
                alert_success(content);
                return false;
                //break;
            case "Error": // mensaje de error 
                alert_error(content);
                return false;
               // break;
            case "Informacion":// mensaje de información
                alert_info(content);
                return false;
                //break;
            case "Accion":// mensaje de acción
                alert_warning(content);
                break;
            case "ErrorLoginAdmin":// mensaje de acción
                errorLoginAdmin(content);
                break;
            case "ErrorLoginFuncionario":// mensaje de acción
                errorLoginFuncionario(content);
                break;

        }
    });
}



function alert_error(msg, title, time) {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-center",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    Command: toastr["error"](msg, "Error en proceso")
}

function alert_success(msg) {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-center",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    Command: toastr["success"](msg, "Proceso Correcto")
}

function alert_info(msg, title, time, className) {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-center",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    Command: toastr["info"](msg, "Información")
}

function alert_warning(msg, title, time, className) {
    toastr.options = {
        "closeButton": false,
        "debug": false,
        "newestOnTop": false,
        "progressBar": false,
        "positionClass": "toast-top-center",
        "preventDuplicates": true,
        "onclick": null,
        "showDuration": "300",
        "hideDuration": "1000",
        "timeOut": "5000",
        "extendedTimeOut": "1000",
        "showEasing": "swing",
        "hideEasing": "linear",
        "showMethod": "fadeIn",
        "hideMethod": "fadeOut"
    }
    Command: toastr["warning"](msg, "Alerta")
}

function confirma(boton_elimina, mensaje) {
    // bootbox.confirm("¿Confirma eliminación?", function (result) { if (result) document.getElementById(boton_elimina).click(); } );
    bootbox.confirm({
        title: '<b>Atención</b>. Confirme Proceso',

        message: mensaje,
        onEscape: false,
        buttons: {
            cancel: {
                label: '<i class="fa fa-times" aria-hidden="true"></i>Cancelar',
                className: 'btn-primary pull-left'
            },
            confirm: {
                label: '<span class="fa fa-check-square-o" aria-hidden="true"></span> Ejecutar',
                className: 'btn-danger pull-right '
            }
        },
        callback: function (result) {
            if (result) {
                document.getElementById(boton_elimina).click();
            }
        }
    });


}



function confirmaMensaje(boton_acepta, boton_cancela, mensaje) {
    // bootbox.confirm("¿Confirma eliminación?", function (result) { if (result) document.getElementById(boton_elimina).click(); } );
    bootbox.confirm({
        title: '<b>Atención</b>. Confirme Proceso',
        message: mensaje,
        onEscape: false,
        buttons: {
            cancel: {
                label: '<i class="fa fa-times" aria-hidden="true"></i>NO',
                className: 'btn-primary pull-left'
            },
            confirm: {
                label: '<span class="fa fa-check-square-o" aria-hidden="true"></span> SI',
                className: 'btn-danger pull-right '
            }
        },
        callback: function (result) {
            if (result) {
                document.getElementById(boton_acepta).click();
            }
            else {
                document.getElementById(boton_cancela).click();
            }
        }
    });


}


function confirmar_edicion(control_foco_cancela, funcion) {

    var mensaje = "¿Desea modificar el registro existente?";

    // bootbox.confirm("¿Confirma eliminación?", function (result) { if (result) document.getElementById(boton_elimina).click(); } );
    bootbox.confirm({
        title: '<b>Registro ya existe</b>.<br>Confirme edición',
        message: mensaje,
        onEscape: false,
        size: 'small',
        buttons: {
            cancel: {
                label: '<i class="fa fa-times" aria-hidden="true"></i> Cancelar',
                className: 'btn-primary pull-left'
            },
            confirm: {
                label: '<span class="fa fa-check-square-o" aria-hidden="true"></span> Si. modificar',
                className: 'btn-danger pull-right '
            }
        },
        callback: function (result) {
            if (result) {
                funcion();
            } else {
                console.log("cancelado. se devuelve el foco a: " + control_foco_cancela);

                setTimeout(function () {
                    $(control_foco_cancela).focus();
                    $(control_foco_cancela).select();
                }, 500);


            }

        }
    });


}

function confirmar_edicion2(control_foco_cancela, funcion) {

    var mensaje = "¿Desea modificar el registro existente?";

    // bootbox.confirm("¿Confirma eliminación?", function (result) { if (result) document.getElementById(boton_elimina).click(); } );
    bootbox.confirm({
        title: '<b>Registro ya existe</b>.<br>Confirme edición',
        message: mensaje,
        onEscape: false,
        size: 'small',
        buttons: {
            cancel: {
                label: '<i class="fa fa-times" aria-hidden="true"></i> Cancelar',
                className: 'btn-primary pull-left'
            },
            confirm: {
                label: '<span class="fa fa-check-square-o" aria-hidden="true"></span> Si. modificar',
                className: 'btn-danger pull-right '
            }
        },
        callback: function (result) {
            if (result) {
                funcion();
            } else {
                console.log("cancelado. se devuelve el foco a: " + control_foco_cancela);

                setTimeout(function () {
                    $(control_foco_cancela).focus();
                    //$(control_foco_cancela).select();
                }, 500);


            }

        }
    });


}




function confirmar_elimina(control_foco_cancela, mensaje, funcion) {

    //var mensaje = "¿Desea modificar el registro existente?";

    // bootbox.confirm("¿Confirma eliminación?", function (result) { if (result) document.getElementById(boton_elimina).click(); } );
    bootbox.confirm({
        title: '<b>Registro ya existe</b>.<br>Confirme edición',
        message: mensaje,
        onEscape: false,
        size: 'small',
        buttons: {
            cancel: {
                label: '<i class="fa fa-times" aria-hidden="true"></i> Cancelar',
                className: 'btn-primary pull-left'
            },
            confirm: {
                label: '<span class="fa fa-check-square-o" aria-hidden="true"></span> Si. modificar',
                className: 'btn-danger pull-right '
            }
        },
        callback: function (result) {
            if (result) {
                funcion();
            } else {
                console.log("cancelado. se devuelve el foco a: " + control_foco_cancela);

                setTimeout(function () {
                    $(control_foco_cancela).focus();
                    $(control_foco_cancela).select();
                }, 500);


            }

        }
    });


}



function confirmar_Registros(control_foco_cancela, mensaje, funcion) {

    //var mensaje = "¿Desea modificar el registro existente?";

    // bootbox.confirm("¿Confirma eliminación?", function (result) { if (result) document.getElementById(boton_elimina).click(); } );
    bootbox.confirm({
        title: '<b>Eliminar</b>.<br>Confirme Aliminación',
        message: mensaje,
        onEscape: false,
        size: 'small',
        buttons: {
            cancel: {
                label: '<i class="fa fa-times" aria-hidden="true"></i> Cancelar',
                className: 'btn-primary pull-left'
            },
            confirm: {
                label: '<span class="fa fa-check-square-o" aria-hidden="true"></span> Aceptar',
                className: 'btn-danger pull-right '
            }
        },
        callback: function (result) {
            if (result) {
                funcion();
            } else {
                console.log("cancelado. se devuelve el foco a: " + control_foco_cancela);

                setTimeout(function () {
                    $(control_foco_cancela).focus();
                    $(control_foco_cancela).select();
                }, 500);


            }

        }
    });


}
