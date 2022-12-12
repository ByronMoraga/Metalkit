function datediff(first, second) {9
    // Take the difference between the dates and divide by milliseconds per day.
    // Round to nearest whole number to deal with DST.
    return Math.round((second - first) / (1000 * 60 * 60 * 24));
}

String.prototype.toDate = function (splitChar) {
    splitChar = splitChar || "-";

    let fechaArray = this.split("-");
    return new Date(fechaArray[0], fechaArray[1], fechaArray[2]);
};

Date.prototype.dateDiff = function (compareDate) {
    return Math.round((compareDate - this) / (1000 * 60 * 60 * 24));
};

$.fn.serializeObject = function (params) {
    params = params || {};

    var o = {};
    var a = this.serializeArray();

    $.each(a, function () {
        if (o[this.name] !== undefined) {
            if (!params.hasOwnProperty("tuple")) {
                if (!o[this.name].push) {
                    o[this.name] = [o[this.name]];
                }
                o[this.name].push(this.value || '');
            } else {
                let splitKey = this.name.split(".");
                if (!o.hasOwnProperty(splitKey[0])){
                    o[splitKey[0]] = {};
                }

                if (!o[splitKey[0]].hasOwnProperty(splitKey[1]))
                    o[splitKey[0]][splitKey[1]] = this.value || '';
            }
        } else {
            if (!params.hasOwnProperty("tuple")) {
                o[this.name] = this.value || '';
            } else {
                let splitKey = this.name.split(".");
                if (!o.hasOwnProperty(splitKey[0])) {
                    o[splitKey[0]] = {};
                }

                if (!o[splitKey[0]].hasOwnProperty(splitKey[1]))
                    o[splitKey[0]][splitKey[1]] = this.value || '';
            }
        }
    });
    return o;
};

$.fn.loadingButton = function (parametros) {
    parametros = parametros || {};

    parametros.selector = $(this);
    Html.loadingButton(parametros);
};

function soloTexto(event) {
    console.log(event);
    var inputValue = event.which;
    if (!(inputValue >= 65 && inputValue <= 120) && (inputValue != 32 && inputValue != 0)) {
        event.preventDefault();
    }
}

function datatableIdioma() {
    return {
        "sProcessing": "Procesando...",
        "sLengthMenu": "Mostrar _MENU_ registros",
        "sZeroRecords": "No se encontraron resultados",
        "sEmptyTable": "Ningún dato disponible en esta tabla",
        "sInfo": "Mostrando registros del _START_ al _END_ de un total de _TOTAL_ registros",
        "sInfoEmpty": "Mostrando registros del 0 al 0 de un total de 0 registros",
        "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
        "sInfoPostFix": "",
        "sSearch": "Buscar:",
        "sUrl": "",
        "sInfoThousands": ",",
        "sLoadingRecords": "Cargando...",
        "oPaginate": {
            "sFirst": "Primero",
            "sLast": "Último",
            "sNext": "Siguiente",
            "sPrevious": "Anterior"
        },
        "oAria": {
            "sSortAscending": ": Activar para ordenar la columna de manera ascendente",
            "sSortDescending": ": Activar para ordenar la columna de manera descendente"
        }
    };
}


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
    // Valida el rut con su cadena completa "XX.XXX.XXX-X"
    validaRut: function (rutCompleto) {
        console.log(rutCompleto)
        console.log("adentro de valida rut")
        rutCompleto = rutCompleto.replace(".", "");
        rutCompleto = rutCompleto.replace(".", "");
        rutCompleto = rutCompleto.replace("‐", "-");
        console.log(rutCompleto)

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
