//JSON
function Create() {
    //e.preventDefault();

    _url = url_create;

    $.ajax({
        type: "POST",
        url: _url,

        data: $('#Create_Post').serialize(),
        success: function (data) {
            if (data == "success") {
                console.log("success")
                verPdf();
            }
            else {
                alert_error("no se encuentra una solicitud para denegar")

            }
            //if (data.status == "success") {
            //    //$.get(url_create, function (data) {
            //    //    $('#create_Container').html(data);
            //    //    //espero y lanzo el foco al primer control de datos
            //    //    setTimeout(function () {
            //    //        $('#TipoDenegacion').focus();
            //    //        //$('#TipoDenegacion').select();
            //    //    }, 500);
            //    //});
            //    console.log("Registro Ingresado Exitosamente.")
            //    alert_success('Registro Ingresado Exitosamente.');//exito);
            //    verPdf();

            //}
            //else {

            //    jQuery.each(data, function (key, val) {
            //        if (key == 'errors') {

            //            alert_error(val, 'Error', 1000);
            //        }

            //    });
            //}
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
            console.log(data);
            if (data == "success") {
                console.log("success")
                verPdf();

                //$.get(url_create, function (data) {
                //    //$('#create_Container').html(data);
                //    //location.reload();

                //    //$('#edit_Container').hidden;
                //    //espero y lanzo el foco al primer control de datos
                //    setTimeout(function () {
                //        console.log("Registro Actualizado Exitosamente.")
                //        alert_success('Registro Actualizado Exitosamente.');//exito);
                //        verPdf();
                //        $('#TipoDenegacion').focus();
                //        //$('#TipoDenegacion').select();
                //    }, 500);
                //});

            }
            else {
                alert_error("no se encuentra una solicitud para denegar")
              
            }
        }

    });
}
    //FIN: RESULTADO DE LAS LLAMADAS DE CREACION, MODIFICACION O ELIMINACIÓN
//BUSQUEDAS
function buscarFecha() {
   
    var fecResol = $("#L12_FECRESOL").val();
    var Duracion = $("#L12_Duracion").val();
    var Periodo = $("#L12_Periodo").val();
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
                $("#L12_FECDURAC").val(data);
            //});
        },
        error: function (xhr, ajaxOptions, thrownError) {
            alert_error(data);
        }
    });
}

function continuar() {
    var rut = $("#L12_NUMRUT").val();
    var corr = $("#L12_CORREL").val();
    var tipoDenegacion = $("#TipoDenegacion").val();
    //Validaciones
    if (tipoDenegacion == "") {
        alert_error("Campo Tipo de Denegacion obligatorio");
        return;
    }
    if (rut.length == 0) {
        alert_error("Campo RUT obligatorio");
        return;
    }
    if (corr.length == 0) {
        alert_info("Ingrese Campo CORRELATIVO");
        return;
    }
    //

  
    if (rut.indexOf(".")) {
        rut = rut.replace(".", "")
        if (rut.indexOf(".")) {
            rut = rut.replace(".", "")
        }
    }
    var id = rut + '_' + corr;

    
    url = url_continuar + "/" + id;
    $.get(url, function (data) {
        var id_control_foco = '#TipoDenegacion';

        switch (data.split("---")[0]) {
            case "nuevo":
                habilita_div_datos();
                //lleno las clases de la solicitud
                setTimeout(function () {
                    clasesOrigen = data.split("---")[1];
                    var selValues = clasesOrigen.split("&");
                    console.log(clasesOrigen)
                    console.log(selValues)
                    $("#ClasesSeleccionadas").val(selValues);
                    $("#ClasesSeleccionadas").trigger('change');


                }, 500);
                break;
            case "modificar":
                confirmar_edicion(id_control_foco, carga_modificar)
                break;
            case "mostrar":
                carga_modificar();
                bloqueaDatos('#div_cabecera');
                bloqueaDatos('#div_datos');
                break;
            default:
                console.log(data.responseText);
        }
    });
}

function habilita_div_datos() {
    bloqueaDatos('#div_cabecera');
    desbloqueaDatos('#div_datos');
    $('#Nombres').prop('readonly', true);
    $('#L12_FECDURAC').prop('readonly', true);
    if ($('#TipoDenegacion').val() == 1) {
        $('#ClasesSeleccionadas').prop('readonly', true);
        $('#ALCParametros_TipoDenegaciones_id').focus();
    } else {
        $('#ClasesSeleccionadas').prop('readonly', false);
        $('#ClasesSeleccionadas').focus();
    }
}
//FIN: BUSQUEDAS

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



function verPdf() {
    console.log("verPDF")
    var rut = $("#L12_NUMRUT").val();
    var corr = $("#L12_CORREL").val();
    var id = rut + '_' + corr;
    $.ajax({
        url: url_PDF,
        type: "get",
        data: {
            id: id
        },
        success: function (response) {
            Modal_muestraPDF(response, "Impresión de licencia de conducir");
        },
        error: function (xhr) {
        }
    });
}