var PAPersona = {
    select2Busqueda: function (params) {
        let callbacks = {
            fn_formatText: function (resultados) {
                return $.map(resultados, function (obj) {
                    if (obj.hasOwnProperty("id"))
                        obj.id = obj.id;

                    if (obj.hasOwnProperty("Value"))
                        obj.id = obj.Value;

                    if (obj.hasOwnProperty("Text"))
                        obj.text = obj.Text;

                    return obj;
                });
            },
            fn_formatAddOption: function (opcion) {
                if (opcion.hasOwnProperty("opcionAgregar")) {
                    return "<i class=\"fa fa-plus\"></i> " + opcion.text;
                } else if (opcion.hasOwnProperty("loading")) {
                    return "<i class=\"fa fa-spin fa-refresh\"></i> " + opcion.text;
                } else {
                    return opcion.text;
                }
            },
            fn_formatAddOptionSelection: function (opcion) {
                if (opcion.hasOwnProperty("opcionAgregar")) {
                    return "<i class=\"fa fa-plus\"></i> " + opcion.text;
                } else if (opcion.hasOwnProperty("loading")) {
                    return "<i class=\"fa fa-spin fa-refresh\"></i> " + opcion.text;
                } else {
                    if (params.hasOwnProperty("allowClear")) {
                        if (opcion.id.length > 0 && $("a.btnLimpiarFiltro").length < 1)
                            opcion.text += "<a class='btnLimpiarFiltro'><i class='fa fa-times-circle-o'></i></a>";
                        return opcion.text;
                    } else {
                        return opcion.text;
                    }
                }
            },
            fa_data: function (params) {
                return {
                    term: params.term,
                    type: 'public'
                }
            }
        }

        if (params.hasOwnProperty("callbacks"))
            callbacks = Object.assign(callbacks, params.callbacks);

        let defecto = {
            language: "es",
            placeholder: 'RUT',
            minimumInputLength: 7,
            width: '100%',
            templateResult: callbacks.fn_formatAddOption,
            templateSelection: callbacks.fn_formatAddOptionSelection,
            escapeMarkup: function (m) { return m; },
            allowClear: false,
            cache: true,
            ajax: {
                url: params.url,
                type: "post",
                dataType: 'json',
                delay: 100,
                data: function (parametros) {
                    console.log(parametros);
                    return callbacks.fa_data(parametros);
                },
                processResults: function (data) {
                    let resultados = {};
                    resultados.results = data.Resultados;

                    //Permite opción de agregar rut
                    if (params.hasOwnProperty("allowAdd")) {
                        resultados.results.unshift({
                            opcionAgregar: true,
                            Value: "add",
                            Text: "Agregar contribuyente"
                        });
                    }

                    if (params.hasOwnProperty("allowAdd")) {
                        resultados.results = callbacks.fn_formatText(resultados.results);
                    } else {
                        if (data.Error) {
                            if (params.hasOwnProperty("fn_no_encontrado")) {
                                params.fn_no_encontrado(data);
                            } else
                                callbacks.fn_no_encontrado(data);
                        } else {
                            resultados.results = callbacks.fn_formatText(resultados.results);

                            if (params.hasOwnProperty("fn_encontrado"))
                                params.fn_encontrado(data);
                        }
                    }
                    if (params.hasOwnProperty("complete"))
                        params.complete();

                    return resultados;
                }
            }
        };

        if (params.hasOwnProperty("opciones"))
            defecto = $.extend(true, defecto, params.opciones);

        params.element.select2(defecto);
    },
    addModal: function (params) {
        console.log(params["rut addModal"]);
        var rut = params["rut"];

        $("#select2-irut-container").text(rut);

        muestraContenidoModal('crearPersona', 'PAPersonas', 'Agregar contribuyente', 'get', { rut }, {
            beforeSend: function () {
                //$this.loadingButton({ accion: "loading" })
            },
            complete: function () {
                //$this.loadingButton({ accion: "reset" })
            }
        });
        
    },
    editModal: function (params) {
        muestraContenidoModal('EditarPersona', 'PAPersonas', 'Contribuyente', 'get', { id : params.id }, {
            beforeSend: function () {
                if (params.hasOwnProperty("btn")) {
                    params.btn.loadingButton({ accion: "loading" })
                }
            },
            complete: function () {
                if (params.hasOwnProperty("btn")) {
                    params.btn.loadingButton({ accion: "reset" })
                }
            }
        });
    },

    createModal: function (params) {
        console.log("WSASDADSFD");
         muestraContenidoModal('crearPersona', 'PAPersonas', 'Crear contribuyente', 'get', {}, {
            beforeSend: function () {
                if (params.hasOwnProperty("btn")) {
                    params.btn.loadingButton({ accion: "loading" })
                }
            },
            complete: function () {
                if (params.hasOwnProperty("btn")) {
                    params.btn.loadingButton({ accion: "reset" })
                }
            }
        });
    }
}