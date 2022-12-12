var FormWizard = function () {
    var wizardContent = $('#wizard');
    var wizardForm = $('#form');
    var initWizard = function () {
        // function to initiate Wizard Form
        wizardContent.smartWizard({
            selected: 0,
            keyNavigation: false,
            hideButtonsOnDisabled: false,
            cycleSteps: false,
            onLeaveStep: leaveAStepCallback,
            onShowStep: onShowStep,
        });
        var numberOfSteps = 0;
        animateBar();
        initValidator();
    };
    var animateBar = function (val) {
        if ((typeof val == 'undefined') || val == "") {
            val = 1;
        };
        numberOfSteps = $('.swMain > ul > li').length;
        var valueNow = Math.floor(100 / numberOfSteps * val);
        $('.step-bar').css('width', valueNow + '%');
    };
    var initValidator = function () {
        $("#contenido-step-1").load("PPUPV/Paso1");
        return true;
    };
    var displayConfirm = function () {
        $('.display-value', form).each(function () {
            var input = $('[name="' + $(this).attr("data-display") + '"]', form);
            if (input.attr("type") == "text" || input.attr("type") == "email" || input.is("textarea")) {
                $(this).html(input.val());
            } else if (input.is("select")) {
                $(this).html(input.find('option:selected').text());
            } else if (input.is(":radio") || input.is(":checkbox")) {

                $(this).html(input.filter(":checked").closest('label').text());
            } else if ($(this).attr("data-display") == 'card_expiry') {
                $(this).html($('[name="card_expiry_mm"]', form).val() + '/' + $('[name="card_expiry_yyyy"]', form).val());
            }
        });
    };
    var onShowStep = function (obj, context) {
        $(".next-step").unbind("click").click(function (e) {
            switch (context.toStep) {
                case 1:
                    localStorage.setItem('pagina', '2');
                    break;
                case 2:
                    localStorage.setItem('pagina', '3');
                    $('#contenido-step-3').load('PPUPV/Paso3');
                    $('#botonera-step-3 #BtnVolver').html('');
                    
                    break;
                case 3:
                    localStorage.setItem('pagina', '4');
                    $('#contenido-step-4').load('PPUPV/Paso4');
                    break;
            }
            e.preventDefault();
            wizardContent.smartWizard("goForward");
            //alert('salgo del if');
        });
        $(".back-step").unbind("click").click(function (e) {
            e.preventDefault();
            wizardContent.smartWizard("goBackward");
        });
        $(".finish-step").unbind("click").click(function (e) {
            e.preventDefault();
            onFinish(obj, context);
        });
    };
    var leaveAStepCallback = function (obj, context) {
        return validateSteps(context.fromStep, context.toStep);
        // return false to stay on step and true to continue navigation
    };
    var onFinish = function (obj, context) {
        if (validateAllSteps()) {
            $('.anchor').children("li").last().children("a").removeClass('wait').removeClass('selected').addClass('done');
            //wizardForm.submit();
        }
    };
    var validateSteps = function (stepnumber, nextstep) {
        var isStepValid = false;
        if (numberOfSteps > nextstep && nextstep > stepnumber) {
            // cache the form element selector
          //  alert(stepnumber);
            if (ValidacionPasoContinuar(stepnumber)) {
                $("#contenido-step-2").load("PPUPV/Paso2", function (responseText, statusText, xhr) {
                    if (statusText == "success") {
                       // alert('success');
                        return true;
                        isStepValid = true;
                    } else if (statusText == "error") {
                        //alert('error');
                        return false;
                    }    
                });
                $('.anchor').children("li:nth-child(" + stepnumber + ")").children("a").removeClass('wait');
                animateBar(nextstep);
                return true;
            } else {
                return false;
            }
        } else if (nextstep < stepnumber) {
            if (stepnumber > 2) {
                return false;
            } else {
                if (ValidaPasoAnterior(stepnumber)) {
                } else {

                }
                $('.anchor').children("li:nth-child(" + stepnumber + ")").children("a").addClass('wait');
                animateBar(nextstep);
                return true;
            }
            
        } else {
            $('.anchor').children("li:nth-child(" + stepnumber + ")").children("a").removeClass('wait');
            displayConfirm();
            animateBar(nextstep);
            return true;
        };
    };
    var validateAllSteps = function () {
        var isStepValid = true;
        // all step validation logic
        return isStepValid;
    };
    return {
        init: function () {
            initWizard();
        }
    };
}();


function ValidacionPasoContinuar(stepnumber) {
   // alert("stepnumber = " + stepnumber);
    if (stepnumber == 1) {

        if (ValidaClienteReserva()) {
            var cantidad = 0;
            $("#contCalendario .btn").each(function (index) {
                if ($(this).attr("checked")) {
                    cantidad++;
                }
            });

            if (cantidad > 0) {
                //tiene todo correcto y ahora realizamos insert en la tabla registro
                var respuesta = function () {
                    var rpta = false;
                    $("#contCalendario .btn").each(function (index) {
                        if ($(this).attr("checked")) {
                            //estado = 0 primera reserva
                            $.ajax({
                                url: "ReservaHora/AgendaHora",
                                type: "POST",
                                data: {
                                    RegistroHoraId: $(this).attr('id'),
                                    PasoReserva: 1
                                },
                                success: function (data) {
                                    if (data[0] == 'False') {
                                        var mensaje = data[1];
                                        mostrarMensaje("Informaci&oacute;n Importante", mensaje, "Informacion");
                                        rpta = false;
                                    } else {
                                        rpta = true;
                                    }

                                },
                                error: function () {
                                    var mensaje = "Se encuentra con inconveniente el agendamiento de hora, favor colocarse en contacto, con el departamento de licencia de conducir. Hasta las 09:00 hrs se puede agendar";
                                    mostrarMensaje("Error de agendamiento de horas", mensaje, "Error");
                                    rpta = false;
                                },
                                async: false, // La petición es síncrona
                                cache: false // No queremos usar la caché del navegador
                            });
                        }
                    });
                    return rpta;
                };
                return respuesta();
            } else {
                var mensaje = "Tiene que seleccionar una hora, para poder continuar.";
                mostrarMensaje("Error de agendamiento de horas", mensaje, "Informacion");
                return false;
            }
        } else {
            var mensaje = "";
            mostrarMensaje("Informaci&oacute;n importante", "Usted no puede continuar con el proceso, ya cuenta con un hora vigente.", "Error");
            return false;
        }
        
    } else if (stepnumber == 2) {
        if ($("#terminos").is(':checked')) {
            return true;
        } else {
            var mensaje = "Tiene que aceptar los t&eacute;rminos y condiciones, para poder continuar.";
            mostrarMensaje("Informaci&oacute;n importante", mensaje, "Informacion");
            return false;
        }
        
    } else {
        return false;
    }
    
}

var ValidaClienteReserva = function () {
    var rpta = false;
    $.ajax({
        url: "ReservaHora/consultaHotasTomadas",
        type: "POST",
        success: function (data) {
            if (data[0] == 'False') {
                rpta = false;
            } else {
                rpta = true;
            }

        },
        error: function () {
            var mensaje = "Se encuentra con inconveniente el agendamiento de hora, favor colocarse en contacto, con el departamento de licencia de conducir. Hasta las 09:00 hrs se puede agendar";
            mostrarMensaje("Error de agendamiento de horas", mensaje, "Error");
            rpta = false;
        },
        async: false, // La petición es síncrona
        cache: false // No queremos usar la caché del navegador
    });
    return rpta;
};

function ValidaPasoAnterior() {
    $.ajax({
        url: "ReservaHora/ActualizaPasoAtras",
        type: "POST",
        success: function (data) {
            if (data[0] == 'False') {
                var mensaje = "Se produjo un error al tratar  de eliminar su hora seleccionada.";
                mostrarMensaje("Error de agendamiento", mensaje, "Error");
                rpta = false;
            } else {
                rpta = true;
            }

        },
        error: function () {
            var mensaje = "Se encuentra con inconveniente el agendamiento de hora, favor colocarse en contacto, con el departamento de licencia de conducir. Hasta las 09:00 hrs se puede agendar";
            mostrarMensaje("Error de agendamiento de horas", mensaje, "Error");
            rpta = false;
        },
        async: false, // La petición es síncrona
        cache: false // No queremos usar la caché del navegador
    });
}