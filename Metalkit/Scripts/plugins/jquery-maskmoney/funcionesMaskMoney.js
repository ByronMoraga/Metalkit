$.fn.asignarMaskMoney = function (params) {
    let $this = this;
    params = params || {};

    let opciones = {
        thousands: '.',
        decimal: ',',
        precision: 0,
        prefix: "$ ",
        allowNegative: false,
        allowZero: true
    };

    if (params.hasOwnProperty("signo") && params.signo != null)
        opciones.prefix = params.signo;

    if (params.hasOwnProperty("decimales"))
        opciones.precision = params.decimales;

    if (params.hasOwnProperty("allowNegative"))
        opciones.allowNegative = params.allowNegative;

    if (params.hasOwnProperty("allowZero"))
        opciones.allowZero = params.allowZero;

    try {
        $this.maskMoney('destroy');
    } catch (err) { }
    $this.maskMoney(opciones);
    $this.maskMoney('mask');
}

String.prototype.removerFormatoPeso = function (params){
    let number = this.replace(/\$/g, '').replace(/\./g, '').trim();
    number = number.replace(/\,/g, '.');

    return parseFloat(number);
}

Number.prototype.removerFormatoPeso = function (){
    return this;
}

String.prototype.convertirEnPeso = function (params) {
    let number = parseFloat(this);
    if (isNaN(number))
        number = 0;

    return number.convertirEnPeso(params);
}

Number.prototype.convertirEnPeso = function (params) {
    let valor = this;
    var decimales = valor % 1;
    if (!isNaN(decimales)) {
        valor = Math.round(valor);
    }
    decimales = 0;
    var itemInput = document.createElement('input');
    $(itemInput).maskMoney('destroy');
    $(itemInput).val(valor);
    $(itemInput).maskMoney({
        thousands: '.',
        decimal: ',',
        precision: decimales,
        prefix: "$ ",
        symbolStay: true,
        allowNegative: true
    });

    $(itemInput).maskMoney('mask');
    var conFormato = $(itemInput).val();
    $(itemInput).remove();
    return conFormato;
}