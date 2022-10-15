$(document).ready(function () {
    buscar();
    $('#fecDefuncion').bootstrapMaterialDatePicker({
        format: 'DD/MM/YYYY',
        time: false,
        lang: 'es',
        cancelText: 'CERRAR'
    });
});

function buscar() {
    $('#tableDifunto').DataTable({
        destroy: true,
        ajax: {
            url: 'Difunto/Buscar',
            type: "POST",
            dataSrc: 'datos'
        },
        columns: [
            { "name": "difS_APEPATERNO", "data": "difS_APEPATERNO", "class": "text-center" },
            { "name": "difS_APEMATERNO", "data": "difS_APEMATERNO", "class": "text-center" },
            { "name": "difS_NOMBRES", "data": "difS_NOMBRES", "class": "text-center" },
            { "name": "difD_FECHADEFUNCION", "data": "difD_FECHADEFUNCION", "class": "text-center" },
            { "name": "pabS_NOMBRE", "data": "pabS_NOMBRE", "class": "text-center" },
            { "name": "nicS_CODNICHO", "data": "nicS_CODNICHO", "class": "text-center" }
        ],
        columnDefs: [
            {
                targets: 3,
                data: 'difD_FECHADEFUNCION',
                render: function (data) {
                    return moment(data).format('DD/MM/YYYY')
                }
            },
            {
                targets: 6,
                data: 'nicdifN_IDNICHODIFUNTO',
                orderable: false,
                width: "20%",
                render: function (data) {
                    return `<button class="btn btn-sm btn-clean btn-icon btn-icon-md" type="button" onclick="verDifunto(` + data + `)"><i class="fadeIn animated bx bx-pencil"></i></button>
                            <button class="btn btn-sm btn-clean btn-icon btn-icon-md" type="button" onclick="eliminarDifunto(` + data + `)"><i class="fadeIn animated bx bx-trash-alt"></i></button>`;
                }
            }
        ],
        language: translateDatatable,
        initComplete: function (settings, oResponse) {
            $("#totalDifunto").html(oResponse.datos.length)
        }
    });
}

function addDifunto() {
    let _idNichoDifunto = $("#idNichoDifunto").val();
    let _idDifunto = $("#idDifunto").val();
    let _nombre = $("#nombreDifunto").val();
    let _apePaterno = $("#apePaterno").val();
    let _apeMaterno = $("#apeMaterno").val();
    let _fecDefuncion = $("#fecDefuncion").val();
    let _selectPabellon = $("#selectPabellon").val();
    let _selectNicho = $("#selectNicho").val();
    if (!$("#nombreDifunto").get(0).checkValidity() || !$("#apePaterno").get(0).checkValidity() || !$("#fecDefuncion").get(0).checkValidity() || !$("#selectPabellon").get(0).checkValidity() || !$("#selectNicho").get(0).checkValidity()) {
        $("#formDifunto").addClass('was-validated');
    } else {
        let objDifunto = {
            NICDIFN_IDNICHODIFUNTO: _idNichoDifunto,
            DIFN_IDDIFUNTO: _idDifunto,
            DIFS_NOMBRES: _nombre,
            DIFS_APEPATERNO: _apePaterno,
            DIFS_APEMATERNO: _apeMaterno,
            DIFD_FECHADEFUNCION: _fecDefuncion,
            NICN_IDNICHO: _selectNicho,
            PABN_IDPABELLON: _selectPabellon,
            DIFN_IDCEMENTERIO: 1
        }
        $.ajax({
            type: "POST",
            url: "Difunto/Guardar",
            data: objDifunto,
            dataType: "json",
            success: function (data) {
                if (data.estado) {
                    buscar();
                    $("#formDifunto").removeClass('was-validated');
                    mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
                } else {
                    mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
                }
            },
            error: function (error) {
                mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
            }
        });
    $("#modalDifunto").modal("hide");
    }
}

function eliminarDifunto(id) {
    swal.fire({
        title: 'ELIMINAR DIFUNTO',
        text: "¿Está seguro que quiere eliminar el Difunto actual?",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: '¡Eliminar!',
        cancelButtonText: '¡Cancelar!',
        reverseButtons: true
    }).then(function (result) {
        if (result.value) {
            $.ajax({
                type: "DELETE",
                url: "Difunto/Eliminar",
                data: { idDifunto: id },
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

function verDifunto(id) {
    limpiarDatos();
    cargarPabellon();
    if (es_vacio(id)) {
        $("#lblModalDifunto").html("AÑADIR NUEVO DIFUNTO");
        $("#idNichoDifunto").val("");
        $("#btnAddDifunto").html("Registrar");
    }
    else {
        $("#btnAddDifunto").html("Actualizar");
        $.ajax({
            type: "POST",
            url: "Difunto/Buscar",
            data: { idDifunto: id },
            async: false,
            dataType: 'json',
            success: function (data) {
                if (data.estado) {
                    $("#idNichoDifunto").val(data.datos[0].nicdifN_IDNICHODIFUNTO);
                    $("#idDifunto").val(data.datos[0].difN_IDDIFUNTO);
                    $("#apePaterno").val(data.datos[0].difS_APEPATERNO);
                    $("#apeMaterno").val(data.datos[0].difS_APEMATERNO);
                    $("#nombreDifunto").val(data.datos[0].difS_NOMBRES);
                    $("#fecDefuncion").val(moment(data.datos[0].difD_FECHADEFUNCION).format('DD/MM/YYYY'));
                    $("#selectPabellon").val(data.datos[0].pabN_IDPABELLON);
                    cargarNicho(data.datos[0].pabN_IDPABELLON);
                    $("#selectNicho").val(data.datos[0].nicN_IDNICHO);
                    $("#lblModalDifunto").html(data.datos[0].difS_NOMBRES);
                } else {
                    mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
                }
            },
            error: function (error) {
                mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
            }
        });
    }
    $("#modalDifunto").modal("show");
}