
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

function openModal(accion, controlador, url, tituloModal, metodo, datos, tipoModal, eventos) {
    var link = "";
    var dataPost = null;
    var titulo = "";
    var icono = "";
    var tipoConsulta = "get";
    eventos = eventos || {};
    console.log("tipoModal =) -> " + tipoModal);
    tipoModal = tipoModal || "grande";

    let callbacks = {
        beforeSend: function () { /*alert("hola");*/ },
        complete: function () { },
        afterDraw: function () { }
    };

    callbacks = Object.assign(callbacks, eventos);

    link = url;
    titulo = tituloModal;

    if (metodo === 'post') {
        dataPost = datos;
        tipoConsulta = 'post';
    }
    else {
        tipoConsulta = 'get';
        if (typeof datos === "object") {
            link = link;
            dataPost = datos;
        } else {
            link = link + "/" + datos;
        }
    }

    var claseModal = "";
    if (tipoModal === 'grande') {
        console.log("modal grande");
        claseModal = "#ModalGrande";
    }
    else if (tipoModal === 'chico') {
        console.log("modal chico");
        claseModal = "#ModalChico";
    }
    else if (tipoModal === 'mediano') {
        console.log("modal mediano");
        claseModal = "#ModalMediano";
    }

    link = link.replace("varTipo", accion).replace("varControlador", controlador);
    $.ajax({
        cache: false,
        dataType: 'text',
        type: tipoConsulta,
        url: link,
        data: dataPost,
        beforeSend: callbacks.beforeSend(),
        success: function (response) {
            let tieneLayoutModal = response.search("id=\"ModalDinamico\"");
            if (tieneLayoutModal == -1) {
                $(claseModal + ' #editModalContent').html(response); // Datos de la vista
                $(claseModal + ' .modal-title').html('<h4 class="modal-title"></h4> ' + titulo);
                $(claseModal).modal('show'); //Modal que contiene el contenido de la vista

                callbacks.afterDraw();

                if (callbacks.hasOwnProperty("afterShow")) {

                    $(claseModal).on('shown', function () {
                        callbacks.afterShow();
                    });
                }
            } else {

                Html.modalDinamico({
                    html: response,
                    afterDraw: function () {
                        $('#ModalDinamico .modal-title').html('<h4 class="modal-title"></h4> ' + titulo);

                        callbacks.afterDraw();

                        if (callbacks.hasOwnProperty("afterShow")) {
                            $('#ModalDinamico').on('shown', function () {
                                callbacks.afterShow();
                            });
                        }
                    }
                });
            }
        },

        complete: callbacks.complete()
    });

}

function Modal_muestraPDF(url, titulo) {
    var html = '<embed src="' + url + '" frameborder="0" width="100%" height="600px">';
    claseModal = "#ModalPdf";
    $(claseModal + ' #editModalContent').html(html); // Datos de la vista
    $(claseModal + ' .modal-title').html('<h4 class="modal-title"></h4> ' + titulo);
    $(claseModal).modal('show'); //Modal que contiene el contenido de la vista

}




