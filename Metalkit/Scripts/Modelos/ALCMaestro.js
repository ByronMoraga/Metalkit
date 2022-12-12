var Clases = [];
agrupacionMTT = 0;
var buscaDatosPermiso = function (idPersona) {


    $.ajax({
        url: urlPropia + "/PADirecciones/buscaDireccionPrincipal",
        type: "post",
        data: {
            id: idPersona
        },
        success: function (response) {
            if (response.ParametroUno !== "" && response.ParametroUno !== "") {
                $("#idireccion").val(response.ParametroUno);
                $('#icomuna').val(response.ParametroDos);
                $('#icomuna').trigger("change");
            }
        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });

    $.ajax({
        //url: "@Url.Action('buscarFonoPrincipal', 'PAFonos')",
        url: urlPropia + "/PAFonos/buscarFonoPrincipal",
        type: "post",
        data: {
            id: idPersona
        },
        success: function (response) {
            if (response.telefono === "") {
                response.telefono = "";
            }
            $("#itelefono").val(response.telefono);
        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });

    $.ajax({
        //url: '@Url.Action("buscarCorreoPrincipal", "PACorreos")',
        url: urlPropia + "/PACorreos/buscarCorreoPrincipal",
        type: "post",
        data: {
            id: idPersona
        },
        success: function (response) {
            if (response.correo === "") {
                response.correo = "";
            }
            $("#imail").val(response.correo);
        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });

};
function BusquedaRut2() {
    let idPersona = $("#irut").val();
    if (idPersona.trim() !== "") {

        $.ajax({
            //url: '@Url.Action("BusquedaJSON", "PAPersonas")',
            url: urlPropia + "/PAPersonas/BusquedaJSON",
            type: "post",
            data: {
                id: idPersona
            },
            success: function (response) {
                //console.log(response);

                //console.log(response.Resultados);
                if (response.Resultados.PAPersonaId === 0) {
                    alert_info("No existe el rut");
                }
                else {

                    $("#iNombres").val(response.Resultados.Nombres);
                    $("#iPaterno").val(response.Resultados.ApellidoPaterno);
                    $("#iMaterno").val(response.Resultados.ApellidoMaterno);
                    $("#idPersona").val(response.Resultados.PAPersonaId);
                    $("#iestadocivil").val(response.Resultados.PAEstadoCivilId);
                    buscaDatosPermiso(response.Resultados.PAPersonaId);
                }
            },
            error: function (xhr) {
                //$this.loadingButton({ accion: "reset" });
            }
        });

    }
}

$(document).ready(function () {

    console.log("ESTOY EN EL READY DEL JS");

    $(".checkexamen").hide();
    $(".search-select").select2();

    $("body").off("click", ".btnGrabar");
    $("body").on("click", ".btnGrabar", function () {
        $("form.formModal").submit();
    });


    $(".selectPersona").on("change", function (e) {
        //console.log("en change de select persona");
        let idPersona = $(this).val();
        buscaDatosPermiso(idPersona);
    });

    //BusquedaClases();
    $('#iclases').select2().on('select2:unselecting', function (e) {
        // before removing tag we check option element of tag and 
        // if it has property 'locked' we will create error to prevent all select2 functionality
        console.log("ELIMINANDO SELECCIONJ");
        console.log(e.params.args.data);
        //if ($(e.params.args.data.element).attr('locked')) {
        //    e.preventDefault();
        //}
        let eliminar = e.params.args.data.text;
        Clases = Clases.filter(cl => cl.Clase !== eliminar);
    });
    $('#ClasesListadas_Ant2').select2().on('select2:unselecting', function (e) {
        // before removing tag we check option element of tag and 
        // if it has property 'locked' we will create error to prevent all select2 functionality
        console.log("ELIMINANDO SELECCIONJ");
        console.log(e.params.args.data);
        //if ($(e.params.args.data.element).attr('locked')) {
        //    e.preventDefault();
        //}
        let eliminar = e.params.args.data.text;
        Clases = Clases.filter(cl => cl.Clase !== eliminar);
    });


    BusquedaComunas();
    BusquedaTipoEstudios();
    BusquedaProfesion();
    BusquedaNacionalidad();
    $('#itramite').select2();
    $('#itramite2').select2();
    $('#icomuna').select2();
    $('#iprofesion').select2();
    $('#ClasesListadas').select2();


   

});


function BusquedaTipoEstudios() {
    $.ajax({
        //url: '@Url.Action("BusquedaTipoEstudios", "ALCParametros_Generales")',
        url: urlPropia + "/ALCParametros_Generales/BusquedaTipoEstudios",
        type: "post",
        data: {

        },
        success: function (response) {

            if (!response.error) {
                $.each(response.Resultados, function (i, e) {
                    $('#iestudios').append('<option value="' + e.Value + '">' + e.Text + '</option>');
                });
            }

        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });
}


function BusquedaComunas() {
    $.ajax({
        //url: '@Url.Action("BusquedaComunas", "PAComunas")',
        url: urlPropia + "/PAComunas/BusquedaComunas",
        type: "post",
        data: {

        },
        success: function (response) {
            //console.log("response asdasd", response);
            if (!response.error) {
                $.each(response.Resultados, function (i, e) {
                    $('#icomuna').append('<option value="' + e.Value + '">' + e.Text + '</option>');
                });
            }

        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });
}
function BusquedaProfesion() {
    $.ajax({
        //url: '@Url.Action("BusquedaProfesion", "ALCParametros_Generales")',
        url: urlPropia + "/ALCParametros_Generales/BusquedaProfesion",
        type: "post",
        data: {

        },
        success: function (response) {

            if (!response.error) {
                $.each(response.Resultados, function (i, e) {
                    $('#iprofesion').append('<option value="' + e.Value + '">' + e.Text + '</option>');
                });
            }

        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });
}


function BusquedaNacionalidad() {
    $.ajax({
        //url: '@Url.Action("BusquedaNacionalidad", "ALCParametros_Generales")',
        url: urlPropia + "/ALCParametros_Generales/BusquedaNacionalidad",
        type: "post",
        data: {

        },
        success: function (response) {

            if (!response.error) {
                $.each(response.Resultados, function (i, e) {
                    $('#inacionalidad').append('<option value="' + e.Value + '">' + e.Text + '</option>');
                });
            }

        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });
}

var ttefiltrado;
function BusquedaTramiteFiltrado() {
    agrupacionMTT = 0;
    $("#itramite2").empty();
    var identificador = $("#itramite :selected").val();
    $.ajax({
        //url: '@Url.Action("BusquedaTramitesFiltrados", "ALCParametros_Tramites")',
        url: urlPropia + "/ALCParametros_Tramites/BusquedaTramitesFiltrados",
        type: "post",
        data: {
            id: identificador
        },
        success: function (response) {
            if (!response.error) {
                $.each(response, function (i, e) {
                    $('#itramite2').append('<option value="' + e.Value + '">' + e.Text + '</option>');
                });
                BusquedaAgrupamiento();
            }
            BuscarAgrupacionMTT(identificador);
            

        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });


}

function BusquedaAgrupamiento() {
    var codigo = $("#itramite :selected").val();
    if (codigo !== "") {
        $.ajax({
            //url: '@Url.Action("BusquedaTramitesFiltrados", "ALCParametros_Tramites")',
            url: urlPropia + "/ALCParametros_Generales/BusquedaAgrupamiento",
            type: "post",
            data: {
                id: codigo
            },
            success: function (response) {
                console.log("RESPUESTA: " + response);
                $("#iAgrupa").val(response);

            },
            error: function (xhr) {
                //$this.loadingButton({ accion: "reset" });
            }
        });
    }

}

function BuscarAgrupacionMTT(identificador) {
    console.log(identificador);
    $.ajax({
        //url: '@Url.Action("BusquedaTramitesFiltrados", "ALCParametros_Tramites")',
        url: urlPropia + "/ALCMaestros/ObtenerAgrupacionMTT",
        type: "post",
        data: {
            idTramite: identificador
        },
        success: function (response) {
            agrupacionMTT = response;
            if (licAnteriorValidacion === "False") {
                if (agrupacionMTT === 1159) {
                    // deshabilitamos el ingreso de licencia anterior.
                    $(".formLicenAnterior").attr("disabled", "disabled");
                    $('#ClasesListadas_Ant').val(null).trigger('change');
                } else {
                    $(".formLicenAnterior").removeAttr("disabled");
                }
                
            }
        },
        error: function (xhr) {
        }
    });
    
}


function formateaRut(rut) {
    //console.log(rut);
    //console.log(id);
    var actual = rut.trim();
    if (actual !== '' && actual.length > 1) {
        var sinPuntos = actual.replace(/\./g, "");
        var actualLimpio = sinPuntos.replace(/-/g, "");
        var inicio = actualLimpio.substring(0, actualLimpio.length - 1);
        var rutPuntos = "";
        var i = 0;
        var j = 1;
        for (i = inicio.length - 1; i >= 0; i--) {
            var letra = inicio.charAt(i);
            rutPuntos = letra + rutPuntos;

            j++;
        }
        var dv = actualLimpio.substring(actualLimpio.length - 1);
        rutPuntos = rutPuntos + "-" + dv;
    }

    //console.log($('#rutInicio').val());
    return rutPuntos;
}

function AgregarPestana(lic) {
    $.ajax({
        //url: '@Url.Action("EscuelasLicencias", "ALCMaestros")',
        url: urlPropia + "/ALCMaestros/EscuelasLicencias",
        type: "get",
        data: {

        },
        success: function (response) {
            var pestana = '<li class="active"><a onclick="CargarGrilla();" id-nav="' + lic + '" data-toggle="tab">titulo</a>';
            var final = '</li>';
            $("#GrillaLicencias").html(pestana + response + final);
        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });

}

var seleccionados;
$("#iclases").change(function () {

    seleccionados = $('#iclases').select2('data');

    seleccionados.forEach(function (item, index) {
        var letraClase = $.trim(item.text);

        if (Clases.length > 0) {
            var existe = false;

            $.each(Clases, function (ind, elem) {

                if (letraClase === elem.Clase) {
                    existe = true;
                }
            });
            if (existe === false) {
                var ele = {};
                ele.Clase = letraClase;
                ele.Escuela = "-1";
                ele.Rut = "";
                ele.Certificado = "";
                ele.FechaAP = "";
                ele.Especialidad = "";
                ele.IdSoliciud = edicionId;
                ele.Autorizacion17 = "";
                ele.Tipo = "";
                ele.CerEscuela = "";
                ele.AutNotarial = "";
                Clases.push(ele);

            }
        }
        else {

            var elemento = {};
            elemento.Clase = letraClase;
            elemento.Escuela = "-1";
            elemento.Rut = "";
            elemento.Certificado = "";
            elemento.FechaAP = "";
            elemento.Especialidad = "";
            elemento.IdSoliciud = edicionId;
            elemento.Autorizacion17 = "";
            elemento.Tipo = "";
            elemento.CerEscuela = "";
            elemento.AutNotarial = "";
            Clases.push(elemento);

        }
    });

    $.ajax({
        //url: '@Url.Action("EscuelasLicencias", "ALCMaestros")',
        url: urlPropia + "/ALCMaestros/EscuelasLicencias",
        type: "post",
        data: {
            CLASES: Clases,
            tramite: $("#itramite").val(),

        },
        success: function (response) {
            $("#boxClasesProfesionales").html(response);
            $("select").select2();
        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });

    validaTramitesClases();

});
/*
 * FELIPE MIRANDA:
 *                  CREO QUE ESTO NO SE ESTA USANDO LO DEJO COMENTADO HASTA REVISION
 * 
$("#ClasesListadas_Ant2").change(function () {
    
    seleccionados = $('#ClasesListadas_Ant2').select2('data');

    
    seleccionados.forEach(function (item, index) {
        var letraClase = $.trim(item.text);

        if (Clases.length > 0) {
            var existe = false;

            $.each(Clases, function (ind, elem) {

                if (letraClase === elem.Clase) {
                    existe = true;
                }
            });
            if (existe === false) {
                var ele = {};
                ele.Clase = letraClase;
                ele.Escuela = "-1";
                ele.Rut = "";
                ele.Certificado = "";
                ele.FechaAP = "";
                ele.Especialidad = "";
                ele.IdSoliciud = edicionId;
                ele.Autorizacion17 = "";
                ele.Tipo = "";
                ele.CerEscuela = "";
                ele.AutNotarial = "";
                Clases.push(ele);

            }
        }
        else {

            var elemento = {};
            elemento.Clase = letraClase;
            elemento.Escuela = "-1";
            elemento.Rut = "";
            elemento.Certificado = "";
            elemento.FechaAP = "";
            elemento.Especialidad = "";
            elemento.IdSoliciud = edicionId;
            elemento.Autorizacion17 = "";
            elemento.Tipo = "";
            elemento.CerEscuela = "";
            elemento.AutNotarial = "";
            Clases.push(elemento);

        }
    });

    $.ajax({
        //url: '@Url.Action("EscuelasLicencias", "ALCMaestros")',
        url: urlPropia + "/ALCMaestros/EscuelasLicencias",
        type: "post",
        data: {
            CLASES: Clases,
            tramite: $("#itramite").val(),

        },
        success: function (response) {
            $("#boxClasesProfesionales").html(response);
            $("select").select2();
        },
        error: function (xhr) {
            //$this.loadingButton({ accion: "reset" });
        }
    });

    validaTramitesClases();

});

*/




function GuardarClasesProfesionales() {
    console.log("9. GuardarClasesProfesionales");
    var retorno = true;
    $.each(Clases, function (ind, elem) {
        console.log("10 each atodas las clases");
        var clase = elem.Clase;
        var resputaProfesionalActivo = $("#ClasesProfesionalesActivas").val();
        //var resputa18 = $("#ClasesProfesionalesActivas").val();
        console.log("elem:")
        console.log(elem)
        if ((elem.Clase === "A1" || elem.Clase === "A2" || elem.Clase === "A3" || elem.Clase === "A4" || elem.Clase === "A5") && resputaProfesionalActivo==="True") {

            if (elem.Escuela === "-1" || elem.Escuela === null) {
                alert_error("No se ha ingresado Escuela en la licencia clase: " + clase);
                retorno = false;
            }

            if (elem.Certificado === "" || elem.Certificado === null) {
                alert_error("No se ha ingresado Certificado en la licencia clase: " + clase);
                retorno = false;
            }
            elem.FechaAP = $("#ifechaaprobacion_" + clase).val();

            if (elem.FechaAP === "" || elem.FechaAP === null) {
                alert_error("No se ha ingresado Fecha de aprobación en la licencia clase: " + clase);
                retorno = false;
            }
            elem.Especialidad = $("#iespecialidad_" + clase).val();
        }
        if (elem.Clase === "B" && contribuyente17anios=="S") {
            if (elem.Escuela === "-1" || elem.Escuela === null) {
                alert_error("No se ha ingresado Escuela en la licencia clase: " + clase);
                retorno = false;
            }
            //elem.chkEscuela = $("#chkEscuela_" + clase).val();
            console.log("elem.CerEscuela")
            console.log(elem.CerEscuela)
            if (elem.CerEscuela === "" || elem.CerEscuela === null) {
                alert_error("No se ha ingresado Certificado de Escuela en la licencia clase: " + clase);
                retorno = false;
            }
            console.log("elem.AutNotarial")
            console.log(elem.AutNotarial)

            if (elem.AutNotarial === "" || elem.AutNotarial === null) {
                alert_error("No se ha ingresado Autorizacion notarial en la licencia clase: " + clase);
                retorno = false;
            }
            //elem.chkNotarial = $("#chkNotarial_" + clase).val();
           
            elem.FechaAP = $("#ifechaAut_" + clase).val();
            console.log("FECHA")
            console.log(elem.FechaAP)
            if (elem.FechaAP === "" || elem.FechaAP === null || elem.FechaAP === "0001-01-01") {
                alert_error("No se ha ingresado Fecha de aprobación en la licencia clase: " + clase);
                retorno = false;
            }
        }

    });

    return retorno;
}


var felipe;
function GuardarDatos(item, elemento) {

    var claseActual = item.id.split('_')[1];

    $.each(Clases, function (ind, elem) {
        //console.log("CLASE actual: " + elem.Clase);
        if (claseActual === elem.Clase) {
            switch (elemento) {
                case "Escuela":
                    elem.Escuela = item.value;
                    break;
                case "Certificado":
                    elem.Certificado = item.value;
                    break;
                case "Fecha":
                    elem.FechaAP = item.value;
                    break;
                case "Especialidad":
                    elem.Especialidad = item.value;
                    break;
                case "chkNotarial":
                    elem.AutNotarial = $("#" + item.id).is(":checked").toString();
                    break;
                case "chkEscuela":
                    elem.CerEscuela = $("#" + item.id).is(":checked").toString();
                    break;
            }
        }

    });
}

function Validaciones() {

    
    ObtenerTramitesDos();
    var validacionClasesProf = GuardarClasesProfesionales();
    console.log(validacionClasesProf);
    if (validacionClasesProf) {
        var licencias = JSON.stringify(Clases);
        $("#licenciasProfesionales").val(licencias);
        $("form").submit();
    }
}


function validar() {
    console.log("2. VALIDAR")
    $.validator.addMethod("FechaOtorgamiento", function (value, element) {

        var fechaNac = $('#ifechanacimiento').val();
        var FechaOtorgamiento = $('#FechaOtorgamiento_ant').val();
        var start = new Date(fechaNac);
        start.setFullYear(start.getFullYear() + 17);

        var respuesta = true;
        /// no puede ser menor que fechaNac
        if (Date.parse(FechaOtorgamiento) < Date.parse(fechaNac)) {
            respuesta = false;
        }
           
        /// desde fecha nacimiento  no puede ser menor de 17 años
        if (Date.parse(FechaOtorgamiento) < Date.parse(start)) {
            respuesta = false;
        }
        return respuesta;

    });

    $.validator.addMethod("fechaNac", function (value, element) {
        var fechaNac = $('#ifechanacimiento').val();
        //no puede ser menor de 17 años
        var respuesta = true;
        var fnacArray = fechaNac.split("-");
        var today = new Date();
        var age = today.getFullYear() - fnacArray[0];
        if (today.getMonth() < fnacArray[1] - 1 || (today.getMonth() === fnacArray[1] - 1 && today.getDate() < fnacArray[2])) {
            age--;
        }
        if (age < 17)
            respuesta = false;
        return respuesta;
    });

    $.validator.addMethod("FechaVencimiento", function (value, element) {

        var FechaOtorgamiento = $('#FechaOtorgamiento_ant').val();
        var FechaVencimiento = $('#FechaVencimiento_ant').val();
        var UltimoControl = $('#UltimoControl_ant').val();
        // no puede ser menor que FechaOtorgamiento
        var respuesta = true;
        if (Date.parse(FechaVencimiento) < Date.parse(FechaOtorgamiento))
            respuesta = false;
        // no puede ser menor que UltimoControl
        if (Date.parse(FechaVencimiento) < Date.parse(UltimoControl))
            respuesta = false;
        return respuesta;
    });

    $.validator.addMethod("UltimoControl_ant", function (value, element) {

        var FechaOtorgamiento = $('#FechaOtorgamiento_ant').val();
        var FechaVencimiento = $('#FechaVencimiento_ant').val();
        var UltimoControl = $('#UltimoControl_ant').val();
        var respuesta = true;
        // no puede ser menor que FechaOtorgamiento
        if (Date.parse(FechaOtorgamiento) > Date.parse(UltimoControl))
            respuesta = false;
        // no puede ser mayor que FechaVencimiento
        if (Date.parse(FechaVencimiento) < Date.parse(UltimoControl))
            respuesta = false;
        return respuesta;
    });

    $.validator.addMethod("ValidacionEmail", function (value, element) {
        var respuesta = true;

        var email = $("#imail").val();
        console.log(email);
        //var lblError = $("#lblError");
        //console.log(lblError)
        //lblError.innerHTML = "";
        var expr = /^([a-z0-9_\.-]+)@([\da-z\.-]+)\.([a-z\.]{2,6})$/;
        console.log(expr)
        console.log(expr.test(email))
        if (!expr.test(email) /*|| !email.includes("@")*/) {
            respuesta = false;
            //lblError.innerHTML = "Ingrese un correo válido.";
        }
        console.log(respuesta);

        return respuesta;

    });

   
    /// variable "licAnteriorValidacion" se declara al inicio del script en create
    ///si licencia anterior no pertenece a la comuna (entonces licAnteriorValidacion == false)
    /// Y no es una primera licencia
    console.log("ANTERIOR " + licAnteriorValidacion);
    var tramiteSeleccionado = $("#itramite").val();
    console.log("validando campos", licAnteriorValidacion);
    console.log("validando campos", agrupacionMTT);
    if (licAnteriorValidacion === 'false' && agrupacionMTT !== 1159) {        
    //if (licAnteriorValidacion === 'False') {
        $("#formSolcitud").validate({
            rules: {
                iPaterno: {required: true},
                iMaterno: {required: true},
                iNombres: {required: true},
                itelefono: { required: true },
                icomuna: { required: true },
                isexo: { required: true },
                inacionalidad: { required: true },
                imail: { required: true/*, ValidacionEmail:true */},
                iestudios: { required: true },
                iprofesion: { required: true },
                iclases: { required: true },
                Numerolicencia_ant: { required: true },
                FolioLicencia_ant: {required: true, min: true},
                Clases_ant: { required: true },
                Procedencia_ant: { required: true },
                //UltimoControl_ant: { required: true },
                //fechas
                ifechanacimiento: {required: true,fechaNac: true},
                FechaVencimiento_ant: {required: true, FechaVencimiento: true},
                FechaOtorgamiento_ant: {required: true, FechaOtorgamiento: true},
                UltimoControl_ant: {required: true,UltimoControl_ant: true},
                itramite: { required: true }

            },
            messages: {
                iPaterno: {required: "Debe ingresar un apellido"},
                iMaterno: {required: "Debe ingresar un apellido"},
                iNombres: {required: "Debe ingresar nombres"},
                itelefono: { required: "Debe ingresar un teléfono" },
                icomuna: {required: "Debe seleccionar comuna"},
                isexo: { required: "Debe seleccionar una opción" },
                inacionalidad: { required: "Debe seleccionar una opción" },
                imail: { required: "Debe ingresar un correo electrónico"/*, ValidacionEmail:"Ingrese un correo válido." */},
                iestudios: { required: "Debe seleccionar estudios" },
                iprofesion: { required: "Debe seleccionar profesión" },
                iclases: { required: "Debe solicitar una clase" },
                Numerolicencia_ant: {required: "Debe ingresar el numero de licencia anterior"},
                FolioLicencia_ant: {required: "Falta folio licencia", min: "Debe tener numeros positivos"},
                //fechas
                ifechanacimiento: {required: "Falta información", fechaNac: "Inconsistencia en las fechas"},
                FechaOtorgamiento_ant: {required: "Falta información", FechaOtorgamiento: "Inconsistencia en las fechas"},
                FechaVencimiento_ant: {required: "Falta información", FechaVencimiento: "Inconsistencia en las fechas"},
                UltimoControl_ant: {required: "Falta información", UltimoControl_ant: "Inconsistencia en las fechas"},
                Clases_ant: { required: "Faltan clases anteriores" },
                Procedencia_ant: { required: "Falta comuna anterior"},
                itramite:{ required:"Debe seleccionar trámite"}
            }
        });
    } else {
        $("#formSolcitud").validate({

            rules: {
                iPaterno: { required: true },
                iMaterno: { required: true },
                iNombres: { required: true },
                ifechanacimiento: { required: true, fechaNac: true },
                itelefono: { required: true },
                imail: { required: true/*, ValidacionEmail:true */},
                idireccion: {
                    required: {
                        depends: function (elem) {
                            var buleano = false;
                            if ($("#calle").val().length === 0 || $("#numero").val().length === 0) {
                                buleano = true;
                            }
                            return buleano;
                        }
                    }
                },
                icomuna: { required: true },
                iestadocivil: { required: true },
                isexo: { required: true },
                inacionalidad: { required: true },
                iestudios: { required: true },
                iprofesion: { required: true },
                iclases: { required: true },
                itramite: { required: true }

            },
            messages: {
                iPaterno: { required: "Debe ingresar un apellido" },
                iMaterno: { required: "Debe ingresar un apellido" },
                iNombres: { required: "Debe ingresar nombres" },
                ifechanacimiento: {required: "Falta información", fechaNac: "Inconsistencia en las fechas"},
                idireccion: { required: "Debe ingresar un domicilio" },
                itelefono: { required: "Debe ingresar un teléfono" },
                icomuna: { required: "Debe seleccionar comuna" },
                iestadocivil: { required: "Debe seleccionar un estado civil" },
                isexo: { required: "Debe seleccionar una opción" },
                inacionalidad: { required: "Debe seleccionar una opción" },
                imail: { required: "Debe ingresar un correo electrónico"/*, ValidacionEmail:"Ingrese un correo válido." */},
                iestudios: { required: "Debe seleccionar estudios" },
                iprofesion: { required: "Debe seleccionar profesión" },
                iclases: { required: "Debe solicitar una clase" },
                itramite: { required: "Debe seleccionar trámite" }

            }
        });
    }
}

$("#chkDiplomatico").on("change", function () {
    if ($("#chkDiplomatico").is(":checked")) {
        $("#inputDiplomatico").val(true);
        $(".checkexamen").show();
    }
    else {
        $("#inputDiplomatico").val(false);
        $(".checkexamen").hide();
        if ($("#chkRindeExamen").is(":checked")) {
            $("#chkRindeExamen").click();
            $("#inputRindeExamen").val(false);
        }
    }
});


$("#itramite2").on("change", function () {
    console.log("valor change tramite2");
    BuscarTramitesSeleccionados();
});
$("#itramite").on("change", function () {
    console.log("valor change tramite");
    console.log($(this).val());
    BuscarTramitesSeleccionados();
});

function BuscarTramitesSeleccionados() {

    var data = $("#itramite").val() + "%";
    var tr2 = $("#itramite2").val();

    if (tr2.length > 0) {
        $.each(tr2, function (ind, elem) {
            data = data + elem + "%";
        });
    }
    data = data.substring(0, data.length - 1);
   
    BusquedaClases(data);
    //BusquedaClases2(data);
}

function BusquedaClases(stringTramites) {
    var clasesActuales = $("#iclases").val();
    var idMaestro = $("#iSolicitud").val();

    $("#iclases").empty().trigger("change");
    var clasesObtenidas = [];
    $.ajax({
        url: urlPropia + "/ALCParametros_clases/BusquedaClases",
        type: "post",
        data: {
            stringTramites: stringTramites,
            clasesActuales: clasesActuales,
            idMaestro: idMaestro
        },
        success: function (response) {

            if (!response.error) {
                $.each(response.Resultados, function (i, e) {
                    clasesObtenidas.push(e.Value);
                    if (e.Selected === true) {
                        $('#iclases').append('<option Selected="Selected" value="' + e.Value + '">' + e.Text + '</option>');
                    } else {
                        $('#iclases').append('<option value="' + e.Value + '">' + e.Text + '</option>');
                    }
                });
            }

        },
        error: function (xhr) { }
    });
}
function BusquedaClases2(stringTramites) {
    var clasesActuales = $("#ClasesListadas_Ant2").val();
    var idMaestro = $("#idMaestro").val();

    $("#ClasesListadas_Ant2").empty().trigger("change");
    $.ajax({

        url: urlPropia + "/ALCParametros_clases/BusquedaClasesLicencia",
        type: "post",
        data: {
            idMaestro: idMaestro
        },
        success: function (response) {
            console.log("RESULTADOS DE BUSQUEDACLASE2")
            console.log(response.Resultados)
            if (!response.error) {
                $.each(response.Resultados, function (i, e) {
                    if (e.Selected === true) {
                        $('#ClasesListadas_Ant2').append('<option Selected="Selected" value="' + e.Value + '">' + e.Text + '</option>');
                    } else {
                        $('#ClasesListadas_Ant2').append('<option value="' + e.Value + '">' + e.Text + '</option>');
                    }
                });
            }

        },
        error: function (xhr) { }
    });
}




function ObtenerTramitesDos() {

    console.log("6. dentro de obtener tramite 2")
    var tr2 = $("#itramite2").val();
    var data = "";
    if (tr2.length > 0) {
        $.each(tr2, function (ind, elem) {

            data = data + elem + "%";

        });
        data = data.substring(0, data.length - 1);
    }
    console.log("7. pasar valores a segunda eleccion")
    $("#SegundaEleccion").val(data);
}

$("#iclases").focusout(function () {
    console.log("estamos en la funcion iclases");
    validaTramitesClases();
    
});

function validaTramitesClases() {
    var tramitePrincipal = $("#itramite").val();
    var tramiteSecundario = $("#itramite2").val();
    var clases = $("#iclases").val();
    console.log("Clases =" + clases+"/hasta aca");
    if (clases != "") {
        console.log("IGUAL ENTRE");
        var idLicencia = 0;
        if ($("#ultimaLicencia").length > 0) {
            idLicencia = $("#ultimaLicencia").val();
        }

        $.ajax({
            url: urlPropia + "/ALCParametros_clases/ValidaTramiteClase",
            type: "post",
            data: {
                tramitePrincipal: tramitePrincipal,
                tramiteSecundario: tramiteSecundario,
                clases: clases,
                idLicencia: idLicencia
            },
            success: function (response) {
                console.log(response);
                if (response['TodoOk'] === false) {
                    alert_error(response['mensaje']);
                    $("#btnGuardar").attr("disabled", "disabled");
                } else {
                    $("#btnGuardar").removeAttr("disabled");
                }
            },
            error: function (xhr) { }
        });
    }
}

function LicenciasOtorgadas(papaersonaId, solictudId) {
    var PAPersona_id = papaersonaId;
    var idMaestro = solictudId;

    muestraContenidoModal('LicenciasOtorgadas', 'Examenes', 'Mantenedor de clases otorgadas', 'get', {
        PAPersona_id: PAPersona_id,
        idMaestro: idMaestro
    }, {
            beforeSend: function () { },
            complete: function () { }
        });
}

function AgregaDV() {
    muestraContenidoModal('Create', 'ALCPagos', 'Crear Derecho Varios', 'get', {
        beforeSend: function () {
        },
        complete: function () {
            // cargamos los select2
            $("#ALCParametros_Tramite_id").select2({
                dropdownParent: $('#ModalGrande'),
                allowClear: true,
                placeholder: 'Seleccione'
            });
            // Cargamos el rut
            
        }
    }, '', 'grande');
}

function AgregaDeclaracionesJ() {
    muestraContenidoModal('DeclaracionJurada', 'InfCertificadosOficios', 'Declaraciones Juradas', 'get', {
        beforeSend: function () {
        },
        complete: function () {
        }
    }, '', 'grande');
}

