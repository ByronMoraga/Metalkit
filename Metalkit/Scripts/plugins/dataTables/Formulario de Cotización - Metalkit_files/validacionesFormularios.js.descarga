$("#formCrear").validate({
    errorClass: 'help-block animation-slideDown',
    errorElement: 'div',
    errorPlacement: function (error, e) {
        e.parents('.form-group > div').append(error);
    },
    highlight: function (e) {

        $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
        $(e).closest('.help-block').remove();
    },
    success: function (e) {
        e.closest('.form-group').removeClass('has-success has-error');
        e.closest('.help-block').remove();
    },
    rules: {
        TipoPagoId: {
            required: true,
            number: true,
            maxlength: 5
        },
        Descripcion: {
            required: true,
            minlength: 2
        },
        tipoBoletin: {
            required: true
        },
        Valor: {
            required: true,
            maxlength: 12
        },
        TipoAnotacionId: {
            required: true,
            number: true,
            maxlength: 5
        },
        TipoCarroceriaId: {
            required: true,
            number: true,
            maxlength: 1
        },
        Codigo: {
            required: true,
            number: true,
            maxlength: 5
        },
        TipoSelloId: {
            required: true,
            number: true,
            maxlength: 1
        },
        TipoSituacionId: {
            required: true,
            number: true,
            maxlength: 3
        },
        Glosa: {
            required: true,
            minlength: 2
        },
        Porcentaje: {
            required: true,
            maxlength: 9
        },
        TipoTrasladoid: {
            required: true,
            number: true,
            maxlength: 3
        },
        TipoVehiculoId: {
            required: true,
            number: true,
            maxlength: 5
        },
        PeriodoId: {
            required: true,
            number: true,
            maxlength: 3
        },
        Impuesto: {
            required: true,
            maxlength: 5
        },
        AseguradoraId: {
            required: true,
            number: true,
            maxlength: 5
        },
        PrimerVencimiento: {
            required: true,
            date: true
        },
        SegundoVencimiento: {
            required: true,
            date: true
        },
        PlantaId: {
            required: true,
            number: true,
            maxlength: 3
        },
        PVReajusteId: {
            required: true,
            number: true,
            maxlength: 5
        },
        Anio: {
            required: true,
            number: true,
            maxlength: 4,
            minlength: 4
        },
        RangoCargaId: {
            required: true,
            number: true,
            maxlength: 3
        },
        TipoCombustibleId: {
            required: true,
            number: true,
            maxlength: 3
        }

    },
    messages: {
        TipoPagoId: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 5 caracteres"

        },
        Descripcion: {
            required: "Falta completar campo.",
            minlength: "Debe tener un minimo de 2 caracteres"
        },
        tipoBoletin: {
            required: "Debe seleccionar una opción."
        },
        Valor: {
            required: "Falta completar campo.",
            maxlength: "No ingresar mas de 12 caracteres"
        },
        TipoAnotacionId: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 5 caracteres"
        },
        TipoCarroceriaId: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 1 caracteres"
        },
        Codigo: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 5 caracteres"
        },
        TipoSelloId: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 1 caracteres"
        },
        TipoSituacionId: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 3 caracteres"
        },
        Glosa: {
            required: "Falta completar campo.",
            minlength: "Debe tener un minimo de 2 caracteres"
        },
        Porcentaje: {
            required: "Falta completar campo.",
            maxlength: "No ingresar mas de 9 caracteres"
        },
        TipoTrasladoid: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 3 caracteres"
        },
        TipoVehiculoId: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 5 caracteres"
        },
        PeriodoId: {
            required: "Debe seleccionar una opción.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 3 caracteres"
        },
        Impuesto: {
            required: "Falta completar campo.",
            maxlength: "No ingresar mas de 5 caracteres"
        },
        AseguradoraId: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 5 caracteres"
        },
        PrimerVencimiento: {
            required: "Falta completar fecha.",
            date: "Ingrese una fecha valida"
        },
        SegundoVencimiento: {
            required: "Falta completar fecha.",
            date: "Ingrese una fecha valida"
        },
        PlantaId: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 3 caracteres"
        },
        PVReajusteId: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 5 caracteres"
        },
        Anio: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 4 caracteres",
            minlength: "Debe ingresar 4 caracteres"
        },
        RangoCargaId: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 3 caracteres"
        },
        TipoCombustibleId: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 3 caracteres"
        }



    }
});

//

$("#formEditar").validate({
    errorClass: 'help-block animation-slideDown',
    errorElement: 'div',
    errorPlacement: function (error, e) {
        e.parents('.form-group > div').append(error);
    },
    highlight: function (e) {

        $(e).closest('.form-group').removeClass('has-success has-error').addClass('has-error');
        $(e).closest('.help-block').remove();
    },
    success: function (e) {
        e.closest('.form-group').removeClass('has-success has-error');
        e.closest('.help-block').remove();
    },
    rules: {
        TipoPagoId: {
            required: true,
            number: true,
            maxlength: 5
        },
        Descripcion: {
            required: true,
            minlength: 2
        },
        tipoBoletinEditar: {
            required: true
        },
        Valor: {
            required: true,
            maxlength: 12
        },
        TipoAnotacionId: {
            required: true,
            number: true,
            maxlength: 5
        },
        TipoCarroceriaId: {
            required: true,
            number: true,
            maxlength: 5
        },
        Codigo: {
            required: true,
            number: true,
            maxlength: 5
        },
        TipoSelloId: {
            required: true,
            number: true,
            maxlength: 5
        },
        TipoSituacionId: {
            required: true,
            number: true,
            maxlength: 5
        },
        Glosa: {
            required: true,
            minlength: 2
        },
        Porcentaje: {
            required: true,
            maxlength: 9
        },
        PeriodoId: {
            required: true
        },
        Impuesto: {
            required: true,
            maxlength: 5
        },
        PrimerVencimiento: {
            required: true,
            date: true
        },
        SegundoVencimiento: {
            required: true,
            date: true
        },
        Anio: {
            required: true,
            number: true,
            maxlength: 4,
            minlength: 3
        },
        tipoMonedaEditar: {
            required: true
        }



    },
    messages: {
        TipoPagoId: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 5 caracteres"

        },
        Descripcion: {
            required: "Falta completar campo.",
            minlength: "Debe tener un minimo de 2 caracteres"
        },
        tipoBoletinEditar: {
            required: "Debe seleccionar una opción."
        },
        Valor: {
            required: "Falta completar campo.",
            maxlength: "No ingresar mas de 12 caracteres"

        },
        TipoAnotacionId: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 5 caracteres"
        },
        TipoCarroceriaId: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 5 caracteres"
        },
        Codigo: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 5 caracteres"
        },
        TipoSelloId: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 5 caracteres"
        },
        TipoSituacionId: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 5 caracteres"
        },
        Glosa: {
            required: "Falta completar campo.",
            minlength: "Debe tener un minimo de 2 caracteres"
        },
        Porcentaje: {
            required: "Falta completar campo.",
            maxlength: "No ingresar mas de 9 caracteres"
        },
        PeriodoId: {
            required: "Debe seleccionar una opción."
        },
        Impuesto: {
            required: "Falta completar campo.",
            maxlength: "No ingresar mas de 5 caracteres"
        },
        PrimerVencimiento: {
            required: "Falta completar fecha.",
            date: "Ingrese una fecha valida"
        },
        SegundoVencimiento: {
            required: "Falta completar fecha.",
            date: "Ingrese una fecha valida"
        },
        Anio: {
            required: "Falta completar campo.",
            number: "Debe ingresar solo números",
            maxlength: "No ingresar mas de 4 caracteres",
            minlength: "Debe ingresar 4 caracteres"
        },
        tipoMonedaEditar: {
            required: "Debe seleccionar una opción."
        }


    }
});

//jQuery('#Porcentaje').keyup(function (e) {
//    if (($(this).val().split(".")[0]).indexOf("00") > -1) {
//        $(this).val($(this).val().replace("00", "0"));
//    } else {
//        $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
//    }

//    if ($(this).val().split(".")[2] != null || ($(this).val().split(".")[2]).length) {
//        $(this).val($(this).val().substring(0, $(this).val().lastIndexOf(".")));
//    }
//});

//jQuery('#Impuesto').keyup(function (e) {
//    if (($(this).val().split(".")[0]).indexOf("00") > -1) {
//        $(this).val($(this).val().replace("00", "0"));
//    } else {
//        $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
//    }

//    if ($(this).val().split(".")[2] != null || ($(this).val().split(".")[2]).length) {
//        $(this).val($(this).val().substring(0, $(this).val().lastIndexOf(".")));
//    }
//});

jQuery('#Anio').keyup(function (e) {
        $(this).val($(this).val().replace(/[^0-9]/g, ''));
});


//jQuery('#Factor').keyup(function (e) {
//    if (($(this).val().split(".")[0]).indexOf("00") > -1) {
//        $(this).val($(this).val().replace("00", "0"));
//    } else {
//        $(this).val($(this).val().replace(",", '.'));
//        $(this).val($(this).val().replace(/[^0-9\.]/g, ''));
//    }

//    if ($(this).val().split(".")[2] != null || ($(this).val().split(".")[2]).length) {
//        $(this).val($(this).val().substring(0, $(this).val().lastIndexOf(".")));
//    }
//});
