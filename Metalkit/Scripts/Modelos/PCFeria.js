var PCFeria = {
    select2Busqueda: function (params) {
        params.element.select2({
            language: "es",
            placeholder: 'Feria',
            minimumInputLength: 2,
            width: '100%',
            templateResult: function (opcion) {
                if (opcion.hasOwnProperty("opcionAgregar")) {
                    return "<i class=\"fa fa-plus\"></i> " + opcion.Text;
                } else if (opcion.hasOwnProperty("loading")) {
                    return "<i class=\"fa fa-spin fa-refresh\"></i> " + opcion.text;
                } else {
                    return opcion.text;
                }
            },
            templateSelection: function (opcion) {
                if (opcion.hasOwnProperty("opcionAgregar")) {
                    return "<i class=\"fa fa-plus\"></i> " + opcion.Text;
                } else if (opcion.hasOwnProperty("loading")) {
                    return "<i class=\"fa fa-spin fa-refresh\"></i> " + opcion.text;
                } else {
                    return opcion.text;
                }
            },
            escapeMarkup: function (m) { return m; },
            cache: true,
            ajax: {
                url: params.url,
                type: "post",
                dataType: 'json',
                delay: 250,
                data: function (params) {
                    let not = [];

                    let obj = {
                        term: params.term,
                        type: 'public'
                    };

                    $(".idPersonaAsociada").each(function (i, e) {
                        //not.push($(e).val());
                    });

                    obj.not = not.join(",");
                    return obj;
                },
                processResults: function (data) {
                    let resultados = {};
                    resultados.results = data.Resultados;

                    //Permite opción de agregar rut
                    resultados.results.unshift({
                        opcionAgregar: true,
                        Value: "add",
                        Text: "Agregar feria"
                    });
                    resultados.results = $.map(resultados.results, function (obj) {
                        if (obj.hasOwnProperty("Value"))
                            obj.id = obj.Value;

                        if (obj.hasOwnProperty("Text"))
                            obj.text = obj.Text;

                        return obj;
                    });
                    return resultados;
                }
            }
        });
    }
}