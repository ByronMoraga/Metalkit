var Html = {
    ajax: {
        procesarDeleteModal: function (params) {
            params = params || {};
            let callbacks = {
                beforeSend: function () {
                    Html.loadingButton({
                        accion: "loading",
                        selector: conf.button
                    });
                },
                success_ok: function (response) {
                    location.reload();
                },
                success_error: function (response) {
                    alert_error(response.mensaje);
                },
                success: function (response) {
                    if (response.error) {
                        callbacks.success_error(response);
                    } else {
                        callbacks.success_ok(response);
                    }
                },
                error: function (error) {
                    alert_error(error);
                },
                complete: function (jqXHR, textStatus) {
                    Html.loadingButton({
                        accion: "reset",
                        selector: conf.button
                    });
                }
            };

            if (params.hasOwnProperty("callbacks")) {
                callbacks = Object.assign(callbacks, params.callbacks);
                delete params.callbacks;
            }

            let conf = Object.assign({
                url: "",
                data: {},
                type: "post",
                dataType: "JSON",
                button: $(".modalEliminar")
            }, params);

            $.ajax({
                url: conf.url,
                type: conf.type,
                data: conf.data,
                dataType: conf.dataType,
                beforeSend: callbacks.beforeSend(),
                success: function (response) { callbacks.success(response) },
                error: function (error) { callbacks.error(error) },
                complete: function (jqXHR, textStatus) { callbacks.complete(jqXHR, textStatus) }
            });
        }
    },
    link: function (params, returnString) {
        let funcionClick = false;
        params = params || {};
        returnString = (typeof returnString === 'undefined') ? true : returnString;

        let a = $(document.createElement('a'));
        let atributos = {};
        if (params.hasOwnProperty("href")) {
            if (params.href instanceof Object)
                atributos.href = this.url(params.href);
            else
                atributos.href = params.href;
            delete params.href;
        }

        if (params.hasOwnProperty("fn_click")) {
            funcionClick = params.fn_click;
            delete params.fn_click;
        }

        a.append(params.texto);
        delete params.texto;

        atributos = $.extend(true, atributos, params);
        a.attr(atributos);

        if (funcionClick !== false) {
            a.on("click", function (event) {
                event.preventDefault();
                funcionClick(event);
            });
        }

        if (returnString)
            return a.prop("outerHTML");
        else
            return a;
    },
    btnGroup: function (params) {
        let string = "";
        let div = $(document.createElement('div'));
        let a = $(document.createElement('a'));
        let ul = $(document.createElement('ul'));
        params = params || {};

        div.addClass("btn-group");
        if (params.hasOwnProperty("btnClass"))
            div.addClass(params.btnClass);

        a.attr("href", "#");
        a.addClass("btn btn-primary dropdown-toggle btn-sm");
        if (params.hasOwnProperty("linkClass"))
            a.addClass(params.linkClass);

        a.attr("data-toggle", "dropdown");
        a.append(params.textoBoton);
        ul.addClass("dropdown-menu");
        if (params.hasOwnProperty("ulClass"))
            ul.addClass(params.ulClass);

        ul.attr("role", "menu");
        $.each(params.opciones, function (i, link) {
            let li = $(document.createElement('li'));
            if (link.trim().toLocaleLowerCase() != "divider") {
                li.attr("role", "presentation");
                li.append(link);
            } else {
                li.attr("class", "divider");
            }
            ul.append(li);
        });
        div.append(a);
        div.append(ul);
        return div.prop("outerHTML");
    },
    select: function (params) {
        let select = params.selector;
        let opciones = {};
        if (params.hasOwnProperty("empty"))
            opciones = $.extend(opciones, params.empty);

        if (params.hasOwnProperty("options"))
            opciones = $.extend(opciones, params.options);

        select.find("option").remove();
        $.each(Object.keys(opciones), function (i, key) {
            select.append("<option value=\"" + key + "\">" + opciones[key] + "</option>");
        });

        if (select.data("select2")) {
            let firstOption = select.find("option:first").val();
            select.select2("val", firstOption);
            select.trigger("change");
        }
    },
    url: function (params, fullUrl) {
        if (params.hasOwnProperty("url"))
            return params.url;

        fullUrl = fullUrl || false;
        let url = [""];
        if (params.hasOwnProperty("plugin"))
            url.push(params.plugin);

        if (params.hasOwnProperty("controller"))
            url.push(params.controller);

        if (params.hasOwnProperty("action"))
            url.push(params.action);

        if (params.hasOwnProperty("url"))
            url = [params.url];

        if (params.hasOwnProperty("params")) {
            url = url.concat(params.params);
        }

        url[0] = base_url.slice(0, -1);
        let urlRetorno = url.join("/");
        if (params.hasOwnProperty("get")) {
            urlRetorno = urlRetorno + "?" + $.param(params.get);
        }
        return urlRetorno;
    },
    input: function (params) {
        let input = $(document.createElement('input'));
        input.attr(params);
        return input.prop("outerHTML");
    },
    icheck: function (params) {
        let elemento = params.element;
        let defecto = {
            checkboxClass: 'icheckbox_square',
            radioClass: 'iradio_square',
        }

        if (params.hasOwnProperty("mini")) {
            defecto = {
                checkboxClass: 'icheckbox_minimal',
                radioClass: 'iradio_minimal'
            }
            delete params.mini;
        }

        if (params.hasOwnProperty("extraClass")) {
            defecto.checkboxClass += " " + params.extraClass;
            defecto.radioClass += " " + params.extraClass;
            delete params.extraClass;
        }

        delete params.element;
        let parametros = $.extend(true, defecto, params);
        elemento.iCheck(parametros);
    },
    asignarMaskMoney: function (params) {
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
            params.elemento.maskMoney('destroy');
        } catch (err) { }
        params.elemento.maskMoney(opciones);
        params.elemento.maskMoney('mask');
    },
    dibujarSelect2: function (selector) {
        $(selector).select2("destroy");
        $(selector).select2();
    },
    dibujarDatepicker: function (params) {
        if (typeof params.element === 'string')
            params.element = $(params.element);

        let elemento = params.element;
        let opcionesEspecificas = {};

        if (params.hasOwnProperty("opciones"))
            opcionesEspecificas = params.opciones;

        let opciones = $.extend({}, opcionesEspecificas, {
            changeYear: true,
            changeMonth: true,
            language: "es",
            weekStart: 1,
            format: "dd/mm/yyyy",
            autoclose: true
        });
        // elemento.datepicker("destroy");
        elemento.datepicker(opciones);
    },
    dibujarDataTable: function (params) {
        let defecto = {
            columnaOrden: 1,
            paginacion: true
        }
        let parametros = $.extend(true, defecto, params);

        let defaultObject = {
            scrollX: false
        };

        if (parametros.hasOwnProperty("paginacion"))
            defaultObject.paging = parametros.paginacion;

        if (parametros.hasOwnProperty("columnaOrden"))
            defaultObject.order = [[parametros.columnaOrden, "desc"]];

        if (parametros.hasOwnProperty("extraParams"))
            defaultObject = $.extend(true, defaultObject, parametros.extraParams);

        params.elemento.DataTable(defaultObject);
        $('.dataTables_length select').select2();
        $('.dataTables_length select').addClass('input-xs');
        $(".dataTables_filter input[type='search']").addClass("form-control input-sm");

        $("div.dataTables_info").parent("div").removeClass("col-md-6").addClass("col-md-12");
        $("div.dataTables_paginate").parent("div").removeClass("col-md-6").addClass("col-md-12");
    },
    ul: function (params) {
        let opciones = [];
        if (params.hasOwnProperty("opciones"))
            opciones = params.opciones;

        let ul = $(document.createElement("ul"));
        $.each(opciones, function (i, opcion) {
            let li = $(document.createElement("li"));
            li.append(opcion);
            ul.append(li);
        });
        return ul.prop("outerHTML");
    },
    confirm: function (params) {
        params = params || {};

        if (params.hasOwnProperty("accion") && params.accion.trim().toLocaleLowerCase() == "cerrar") {
            $("#modalConfirm").modal("toggle");

            $('#modalConfirm').on('hidden.bs.modal', function () {
                $('.modal-backdrop').remove();
                $("#modalConfirm").remove();
            });
            return true;
        }

        let botones = [];
        let datos = {};
        if (!params.hasOwnProperty("botones")) {
            let parametrosCancelar = {
                texto: "<i class=\"fa fa-cancel\"></i> Cancelar",
                href: "#",
                class: "btn btn-default btn-sm modalCancelar",
                "data-dismiss": "modal",
            };
            let parametrosAceptar = {
                texto: "<i class=\"fa fa-trash\"></i> Eliminar",
                href: "#",
                class: "btn btn-red btn-sm modalEliminar"
            };
            if (params.hasOwnProperty("fn_cancelar"))
                parametrosCancelar.fn_click = params.fn_cancelar;

            if (params.hasOwnProperty("fn_aceptar"))
                parametrosAceptar.fn_click = params.fn_aceptar;

            let btnCancelar = Html.link(parametrosCancelar, false);
            let btnEliminar = Html.link(parametrosAceptar, false);
            botones.push(btnCancelar);
            botones.push(btnEliminar);
        } else {
            $.each(params.botones, function (i, boton) {
                let botonDom = Html.link(boton, false);
                botones.push(botonDom);
            });
        }
        let modal = $(document.createElement("div"));
        let modalDialog = $(document.createElement("div"));
        let modalContent = $(document.createElement("div"));
        let modalHeader = $(document.createElement("div"));
        let modalBody = $(document.createElement("div"));
        let modalFooter = $(document.createElement("div"));

        modal.attr({
            id: "modalConfirm",
            class: "modal fade",
            tabindex: "-1",
            role: "dialog",
            "aria-labelledby": "myModalLabel"
        });

        let modalClass = "modal-xs";
        let modalStyle = "width: 350px !important;";
        if (params.hasOwnProperty("modalClass")) {
            modalClass = params.modalClass;
            modalStyle = false;
        }

        modalDialog.attr({
            class: "modal-dialog " + modalClass,
            role: "document",
            style: modalStyle
        });

        modalContent.attr({ class: "modal-content" });
        modalHeader.attr({ class: "modal-header" });
        modalBody.attr({ class: "modal-body", style: "overflow-y: auto;" });
        modalFooter.attr({ class: "modal-footer" });

        if (params.hasOwnProperty("titulo")) {
            let h4 = $(document.createElement("h4"));
            h4.attr({ class: "modal-title", id: "myModalLabel" });
            h4.append(params.titulo);
            modalHeader.append(h4);
        }

        if (params.hasOwnProperty("mensaje"))
            modalBody.append(params.mensaje);

        if (params.titulo) modalContent.append(modalHeader);
        modalContent.append(modalBody);
        modalContent.append(modalFooter);
        modalDialog.append(modalContent);
        modal.append(modalDialog);

        if (params.hasOwnProperty("beforeSend"))
            params.beforeSend();

        $('.modal-backdrop').remove();
        $("#modalConfirm").remove();
        $("body").append(modal);
        $("#modalConfirm").modal({
            backdrop: 'static', keyboard: false
        });

        $.each(botones, function (i, btn) {
            $(".modal-footer").append(btn);
        });
    },
    alerta: function (params) {
        let options = {
            container: $("body"),
            class: "alert-info",
            tituloIcono: "fa fa-info-circle",
            titulo: "Información",
            mensaje: ""
        };

        if (params.hasOwnProperty("container")) {
            if (typeof params.container === 'string' || params.container instanceof String)
                options.container = $(params.container);
            else
                options.container = params.container;
        }

        if (params.hasOwnProperty("mensaje"))
            options.mensaje = params.mensaje;

        if (params.hasOwnProperty("tipo")) {
            switch (params.tipo) {
                case "info":
                    options.class = "alert-info";
                    options.tituloIcono = "fa fa-info-circle";
                    options.titulo = "Información";
                    break;
                case "warning":
                    options.class = "alert-warning";
                    options.tituloIcono = "fa fa-exclamation-triangle";
                    options.titulo = "Advertencia";
                    break;
                case "error":
                    options.class = "alert-danger";
                    options.tituloIcono = "fa fa-times-circle";
                    options.titulo = "Error";
                    break;
                case "success":
                    options.class = "alert-success";
                    options.tituloIcono = "fa fa-check-circle";
                    options.titulo = "Correcto";
                    break;
            }
        } else {
            options.class = params.class;
            options.tituloIcono = params.tituloIcono;
            options.titulo = params.titulo;
        }

        let divAlert = $(document.createElement("div")).attr({
            class: "alert alert-block " + options.class
        });
        let row = $(document.createElement("div")).attr({ class: "row" });

        let titulo = $(document.createElement("div")).attr({ class: "col-md-12" });
        titulo.append($(document.createElement("i")).attr({ class: options.tituloIcono }));
        titulo.append($(document.createElement("b")).html(" " + options.titulo));

        let mensaje = $(document.createElement("div")).attr({ class: "col-md-12", style: "padding-top: 5px;" });
        mensaje.html(options.mensaje);

        row.append(titulo);
        row.append(mensaje);
        divAlert.append(row);

        options.container.html(divAlert);
    },
    modalDinamico: function (params) {
        let modalParams = {} || params.modalParams;
        $(".modalContainer").remove();
        let divModalContainer = $(document.createElement('div')).attr({ class: "modalContainer" });
        $("body").append(divModalContainer);
        $(".modalContainer").append(params.html);
        $(".modalContainer").find(".modal").first().modal(modalParams);

        if (params.hasOwnProperty("afterDraw"))
            params.afterDraw();
    },
    loadingButton: function (params) {
        let defaultOpt = {
            icono: "fa fa-spinner fa-spin",
            texto: "Procesando"
        };
        let opciones = Object.assign({}, defaultOpt, params);
        if (typeof params.selector === 'string')
            params.selector = $(params.selector);

        if (params.accion == "loading") {
            let i = $(document.createElement("i")).attr({ class: opciones.icono });
            params.selector.attr("data-loading-text", i.prop("outerHTML") + " " + opciones.texto);
            params.selector.button('loading');
        } else if (params.accion == "reset") {
            params.selector.button('reset');
            params.selector.removeAttr("data-loading-text");
        }
    }
}

$.fn.loadingButton = function (parametros) {
    parametros = parametros || {};

    parametros.selector = $(this);
    Html.loadingButton(parametros);
}