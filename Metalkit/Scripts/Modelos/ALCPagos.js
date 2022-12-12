$("#formDerechosVarios").validate({

    rules: {
        rutPersona: {
            required: true,
            rut: true,
         //  existe_sistema:true
        },
        PersonaNombre: {
            required: true
        },
        PersonaAPP: {
            required: true
        },
        PersonaAPM: {
            required: true
        },
        ALCParametros_Tramite_id: {
            required: true
        },
        L40_CANTIDAD: {
            required: true
        },
        L40_MONTO: {
            required: true
        },
        L40_OBSERVACION: {
            required: false
        }


    },
    messages: {
        rutPersona: {
            required: "Debe ingresar un rut",
            rut: 'Rut no valido',
        //   existe_sistema: 'No existe el rut en el sistema'
        },
        PersonaNombre: {
            required: "Debe ingresar nombres"
        },
        PersonaAPP: {
            required: "Debe ingresar un apellido"
        },
        PersonaAPM: {
            required: "Debe ingresar un apellido"
        },
        ALCParametros_Tramite_id: {
            required: "Debe seleccionar un tramite"
        },
        L40_CANTIDAD: {
            required: "Debe agregar la cantidad",
            min: "Debe ser mayor a 0"
        },
        L40_MONTO: {
            required: "Debe agregar el monto",
            min: "Debe ser mayor a 0"
        },
        L40_OBSERVACION: {
            required: "Debe ingresar una observacion"
        }
    }
});

function validaRut(campo) {
    if (campo.length == 0) { return false; }
    if (campo.length < 8) { return false; }

    campo = campo.replace('-', '')
    campo = campo.replace(/\./g, '')

    var suma = 0;
    var caracteres = "1234567890kK";
    var contador = 0;
    for (var i = 0; i < campo.length; i++) {
        u = campo.substring(i, i + 1);
        if (caracteres.indexOf(u) != -1)
            contador++;
    }
    if (contador == 0) { return false }

    var rut = campo.substring(0, campo.length - 1)
    var drut = campo.substring(campo.length - 1)
    var dvr = '0';
    var mul = 2;

    for (i = rut.length - 1; i >= 0; i--) {
        suma = suma + rut.charAt(i) * mul
        if (mul == 7) mul = 2
        else mul++
    }
    res = suma % 11
    if (res == 1) dvr = 'k'
    else if (res == 0) dvr = '0'
    else {
        dvi = 11 - res
        dvr = dvi + ""
    }
    if (dvr != drut.toLowerCase()) { return false; }
    else { return true; }
}

/* La siguiente instrucción extiende las capacidades de jquery.validate() para que
	admita el método RUT, por ejemplo:

$('form').validate({
	rules : { rut : { required:true, rut:true} } ,
	messages : { rut : { required:'Escriba el rut', rut:'Revise que esté bien escrito'} }
})
// Nota: el meesage:rut sobrescribe la definición del mensaje de más abajo
*/
// comentar si jquery.Validate no se está usando
jQuery.validator.addMethod("rut", function (value, element) {
    return this.optional(element) || validaRut(value);
}, "Revise el RUT");



jQuery.validator.addMethod("existe_sistema", function (value, element) {



    var retorno = $("#retorno").val();

    console.log('valida')

    console.log($("#retorno").val());

    if (retorno == 1) {
        return false;
    } else {
        return true;

    }


}, "Revise el RUT");




