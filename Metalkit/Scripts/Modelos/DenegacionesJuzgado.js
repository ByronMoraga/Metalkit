$(function () {/*Grid_VM*/ });
    //BOTON QUE DESPLIEGA MODAL DE CREACION
    //Create New Row
    $("#btn_Create").on("click", function () {
        var url = $(this).data("url");
        console.log('Creación:');
        console.log(url);
        $.get(url, function (data) {
            $('#edit_Container').html('');
            $('#create_Container').html(data);
            $('#div_CreateModal').modal('show');
            //espero y lanzo el foco al primer control de datos
            setTimeout(function () {
                //$('#TipoDenegacion').focus();
                //$('#TipoDenegacion').select();
            }, 500);

        });

});
//divTabla

//BOTONES DENTRO DE GRILLA
//Edit Row
$('#Grid_DataTable').on("click", ".edit_row", function (event) {
        event.preventDefault();
        var url = $(this).attr("href");
        console.log('Edición:');
        console.log(url);
        $.get(url, function (data) {
            //$('#create_Container').html('');
            //$('#edit_Container').html(data);
            //$('#div_EditModal').modal('show');

            //espero y lanzo el foco al primer control de datos
            setTimeout(function () {
                //$('#TipoDenegacion').focus();
                //$('#AFP_USU_CREACION').prop('readonly', true);
                //$('#AFP_FECHA_CREACION').prop('readonly', true);
            }, 500);

        });

    });

//Delete Row
$('#Grid_DataTable').on("click", ".delete_row", function (event) {
        event.preventDefault();

        var url = $(this).attr("href");
        console.log('Eliminación:');
        console.log(url);

        $.get(url, function (data) {
            console.log('Trajo la info');
            $('#delete_Container').html(data);

            $('#div_DeleteModal').modal('show');
        });

    });
//FIN: BOTONES DENTRO DE GRILLA

//RESULTADO DE LAS LLAMADAS DE CREACION, MODIFICACION O ELIMINACIÓN
//AJAX
function Print_Success(res) {
        console.log("Imprimir Success");
        if (res.status === "success") {

            event.preventDefault();
            console.log("window.open('_blank')");
            window.open(res.url, '_blank');
        }
    }
///**** Create Ajax Form CallBack ********/
function Create_Success(data) {
        console.log("Create_Success");
        console.log(data.status);

        if (data.status !== "success") {
            $('#create_Container').html(data);
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

//JSON
function Create() {
    //e.preventDefault();

    _url = url_create;

    $.ajax({
        type: "POST",
        url: _url,

        data: $('#Create_Post').serialize(),
        success: function (data) {
            if (data.status === "success") {
                $.get(url_create, function (data) {
                    $('#create_Container').html("");
                    $('#create_Container').html(data);
                    //espero y lanzo el foco al primer control de datos
                    setTimeout(function () {
                        $('#TipoDenegacion').focus();
                        //$('#TipoDenegacion').select();
                    }, 500);
                });
                alert_success('Registro Ingresado Exitosamente.');//exito);

            }
            else {

                jQuery.each(data, function (key, val) {
                    if (key === 'errors') {

                        alert_error(val, 'Error', 1000);
                    }

                });
            }
        }

    });
}
function Update() {
    //e.preventDefault();

    _url = url_edit;

    console.log(_url);
    $.ajax({
        type: "POST",
        url: _url,

        data: $('#Update_Post').serialize(),
        success: function (data) {
            if (data.status == "success") {
                $.get(url_create, function (data) {
                    $('#edit_Container').html("");
                    $('#create_Container').html(data);

                    //$('#edit_Container').hidden;
                    //espero y lanzo el foco al primer control de datos
                    setTimeout(function () {
                        alert_success('Registro Actualizado Exitosamente.');//exito);

                        $('#TipoDenegacion').focus();
                        //$('#TipoDenegacion').select();
                    }, 500);
                });

            }
            else {

                jQuery.each(data, function (key, val) {
                    if (key == 'errors') {

                        alert_error(val, 'Error', 1000);
                    }

                });
            }
        }

    });
}

    //FIN: RESULTADO DE LAS LLAMADAS DE CREACION, MODIFICACION O ELIMINACIÓN
//BUSQUEDAS
function buscarFecha() {
   
    var fecResol = $("#L14_FECRESOL").val();
    var Duracion = $("#L14_DURACION").val();
    var Periodo = $("#L14_PERIODO").val();
    if (fecResol == "") {
        alert_info("Ingrese Campo Fecha Resolución");
        return;
    }
    if (Duracion == "") {
        alert_info("Ingrese Campo Duración");
        return;
    }
    if (Periodo == "") {
        alert_info("Ingrese Campo Periodo");
        return;
    }
    var id = fecResol+'_'+ Duracion + '_' + Periodo;
    $.ajax({
        dataType: "json",
        cache: false,
        url: url_BuscarFecha,
        data: { "id": id },
        type: "GET",
        success: function (data) {
            //$.each(data, function (PAPersonaId, option) {
                $("#L14_FECDURAC").val(data);
            //});
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert_error(data);
        }
    });
}
function buscarPersona() {
    var rut = $("#L14_NUMRUT").val();

    if (rut.length == 0) {
        alert_info("Ingrese Campo RUT");
        return;
    }

    var blnRutValido = Fn.validaRut(rut);

    var id = rut;
    if (blnRutValido) {
        $.ajax({
            dataType: "json",
            cache: false,
            url: url_BuscarPersona,
            data: { "id": id },
            type: "GET",
            success: function (data) {
                if (data == "norut") {
                    $("#L14_OFICIO").val(1);
                    $('#L14_OFICIO').focus();
                } else {

                $.each(data, function (PAPersonaId, option) {
                    
                        $("#L14_OFICIO").val(option.L14_OFICIO);
                        $('#L14_OFICIO').focus();
                        $("#Nombres").val(option.Nombres);
                        //$("#Clases").val(option.Clases);
                   
                    });
                }

            },
            error: function (xhr, ajaxOptions, thrownError) {
                alert_error(data);
            }
        });
    }
}
//BuscarPersona por correlativo y rut
function buscarPersona2() {
    if ($("#L14_NUMRUT").val().length == 0) {
        alert_info("Ingrese Campo RUT");
        return;
    }
    if ($("#L14_RIT").val().length == 0 || $("#L14_ROLCAUSA").val().length == 0 || $("#L14_OFICIO").val().length == 0) {
        alert_info("Porfavor, Complete todos los campos");
        return;
    }
    
    var rut = $("#L14_NUMRUT").val();
    var corr = $("#L14_OFICIO").val();
    var id = rut + '_' + corr;

    $.ajax({
        dataType: "json",
        cache: false,
        url: url_BuscarPersonaXCorr,
        data: { "id": id },
        type: "GET",
        success: function (data) {
            if (data.status = "OK") {
                $("#Nombres").val(data.nombres);
                //$("#Clases").val(option.Clases);
            } else if (data.status ="NUEVO") {
                $("#Nombres").val("");
            } else {
                //NOOK
                alert_error(data.mensaje)
            }
            continuar();
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert_error(data);
        }
    });
}

//Funciones Genericas
function bloqueaDatos(nombre_div) {
        $(nombre_div).find("input,textarea,button").prop("readonly", true);
        $(nombre_div).find("select").prop("disabled", true);
        //$(nombre_div).find("select option:not(:selected)").prop("disabled", true);

        //$(nombre_div).children().attr("disabled", "disabled");    
    }
function desbloqueaDatos(nombre_div) {
        $(nombre_div).find("input,textarea,button").prop("readonly", false);
        $(nombre_div).find("select").prop("disabled", false);
        //$(nombre_div).find("select option:not(:selected)").prop("disabled", false);

        //$(nombre_div).children().attr("disabled", "disabled");    
}
//valida rut
var Fn = {
        // Valida el rut con su cadena completa "XXXXXXXX-X"
        validaRut: function (rutCompleto) {

            if (rutCompleto.indexOf(".")) {
                rutCompleto = rutCompleto.replace(".", "")
                if (rutCompleto.indexOf(".")) {
                    rutCompleto = rutCompleto.replace(".", "")
                }
            }
            if (!/^[0-9]+[-|‐]{1}[0-9kK]{1}$/.test(rutCompleto))
                return false;
            var tmp = rutCompleto.split('-');
            var digv = tmp[1];
            var rut = tmp[0];
            if (digv == 'K') digv = 'k';
            return (Fn.dv(rut) == digv);
        },
        dv: function (T) {
            var M = 0, S = 1;
            for (; T; T = Math.floor(T / 10))
                S = (S + T % 10 * (9 - M++ % 6)) % 11;
            return S ? S - 1 : 'k';
        }
    }
//Fin Funciones Genericas