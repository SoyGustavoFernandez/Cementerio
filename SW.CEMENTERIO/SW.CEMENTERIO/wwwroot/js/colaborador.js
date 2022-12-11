$(document).ready(function () {
    buscar();
});

function buscar() {
    $('#tableColaborador').DataTable({
        destroy: true,
        ajax: {
            url: 'Colaborador/Buscar',
            type: "POST",
            dataSrc: 'datos'
        },
        columns: [
            { "name": "colS_NOMBRES", "data": "colS_NOMBRES", "class": "text-center" },
            { "name": "colS_APEPATERNO", "data": "colS_APEPATERNO", "class": "text-center" },
            { "name": "colS_APEMATERNO", "data": "colS_APEMATERNO", "class": "text-center" },
            { "name": "colS_CORREO", "data": "colS_CORREO", "class": "text-center" }
        ],
        columnDefs: [
            {
                targets: 4,
                data: 'colN_IDCOLABORADOR',
                orderable: false,
                width: "20%",
                render: function (data) {
                    if (data === 1)
                        return ``;
                    else
                        return `<button class="btn btn-sm btn-clean btn-icon btn-icon-md" type="button" onclick="verColaborador(` + data + `)"><i class="fadeIn animated bx bx-pencil"></i></button>
                            <button class="btn btn-sm btn-clean btn-icon btn-icon-md" type="button" onclick="eliminarColaborador(` + data + `)"><i class="fadeIn animated bx bx-trash-alt"></i></button>
                            <button class="btn btn-sm btn-clean btn-icon btn-icon-md" type="button" onclick="reenviarCorreo(` + data + `)"><i class="fadeIn animated bx bx-mail-send"></i></button>`;
                }
            }
        ],
        language: translateDatatable,
        initComplete: function (settings, oResponse) {
            $("#totalColaborador").html(oResponse.datos.length)
        }
    });
}

function addColaborador() {
    let _id = $("#idColaborador").val();
    let _nombre = $("#nombreColaborador").val();
    let _paterno = $("#paternoColaborador").val();
    let _materno = $("#maternoColaborador").val();
    let _correo = $("#correoColaborador").val();
    if (!$("#nombreColaborador").get(0).checkValidity() || !$("#paternoColaborador").get(0).checkValidity() ||
        !$("#maternoColaborador").get(0).checkValidity() || !$("#correoColaborador").get(0).checkValidity()) {
        $("#formColaborador").addClass('was-validated');
    } else {
        let objColaborador = {
            COLN_IDCOLABORADOR: _id,
            COLN_IDCEMENTERIO: 1,
            COLS_NOMBRES: _nombre,
            COLS_APEPATERNO: _paterno,
            COLS_APEMATERNO: _materno,
            COLS_CORREO: _correo
        }
        $.ajax({
            type: "POST",
            url: "Colaborador/Guardar",
            data: objColaborador,
            dataType: "json",
            success: function (data) {
                if (data.estado) {
                    buscar();
                    $("#formColaborador").removeClass('was-validated');
                }
                    mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
            },
            error: function (error) {
                mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
            }
        });
    $("#modalColaborador").modal("hide");
    }
}

function eliminarColaborador(id) {
    swal.fire({
        title: 'DAR DE BAJA A COLABORADOR',
        text: "¿Está seguro que quiere darde baja al Colaborador actual?",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: '¡Eliminar!',
        cancelButtonText: '¡Cancelar!',
        reverseButtons: true
    }).then(function (result) {
        if (result.value) {
            $.ajax({
                type: "DELETE",
                url: "Colaborador/Eliminar",
                data: { idColaborador: id },
                dataType: 'json',
                success: function (data) {
                    if (data.estado) {
                        buscar();
                    } else {
                        mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
                    }
                },
                error: function (error) {
                    mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
                }
            });
        }
    });
}

function verColaborador(id) {
    limpiarDatos();
    if (es_vacio(id)) {
        $("#lblModalColaborador").html("DAR DE ALTA COLABORADOR");
        $("#idColaborador").val("");
        $("#btnAddColaborador").html("Registrar");
        $("#classModalColaborador").removeClass("modal-lg");
    }
    else {
        $("#btnAddColaborador").html("Actualizar");
        $.ajax({
            type: "POST",
            url: "Colaborador/Buscar",
            data: { idColaborador: id },
            dataType: 'json',
            success: function (data) {
                if (data.estado) {
                    $("#idColaborador").val(data.datos[0].colN_IDCOLABORADOR);
                    $("#nombreColaborador").val(data.datos[0].colS_NOMBRES);
                    $("#paternoColaborador").val(data.datos[0].colS_APEPATERNO);
                    $("#maternoColaborador").val(data.datos[0].colS_APEMATERNO);
                    $("#correoColaborador").val(data.datos[0].colS_CORREO);
                    $("#lblModalColaborador").html(data.datos[0].colS_NOMBRES);
                } else {
                    mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
                }
            },
            error: function (error) {
                mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
            }
        });
    }
    $("#modalColaborador").modal("show");
}

function reenviarCorreo(id) {
    $.ajax({
        type: "POST",
        url: "Colaborador/EnvioClave",
        data: { idColaborador: id, asunto: null, isReset: true, envioCorreo: false },
        dataType: 'json',
        success: function (data) {
            mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
        },
        error: function (error) {
            mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
        }

    });
}