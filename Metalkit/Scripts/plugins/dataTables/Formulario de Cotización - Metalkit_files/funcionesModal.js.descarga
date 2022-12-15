function openModal(accion, controlador, url, tituloModal, metodo, datos, tipoModal, eventos) {
    var link = "";
    var dataPost = null;
    var titulo = "";
    var icono = "";
    var tipoConsulta = "get";
    eventos = eventos || {};
    console.log("tipoModal =) -> "+tipoModal);
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
        cache:false,
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
    var html = '<embed src="' + url+'" frameborder="0" width="100%" height="600px">';
    claseModal = "#ModalPdf";
    $(claseModal + ' #editModalContent').html(html); // Datos de la vista
    $(claseModal + ' .modal-title').html('<h4 class="modal-title"></h4> ' + titulo);
    $(claseModal).modal('show'); //Modal que contiene el contenido de la vista

}




