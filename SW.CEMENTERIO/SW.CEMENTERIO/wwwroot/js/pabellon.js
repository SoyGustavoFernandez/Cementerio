var bus_det = true;
var map;
var selectedLocation;

$(document).ready(function () {
    buscar();
});

function buscar() {
    $('#tablePabellon').DataTable({
        destroy: true,
        ajax: {
            url: 'Pabellon/Buscar',
            type: "POST",
            dataSrc: 'datos'
        },
        columns: [
            { "name": "pabS_NOMBRE", "data": "pabS_NOMBRE", "class": "text-center" },
            { "name": "pabS_TIPO", "data": "pabS_TIPO", "class": "text-center" },
            { "name": "pabS_UBICACION", "data": "pabS_UBICACION", "class": "text-center" },
            { "name": "pabN_IDPABELLON", "data": "pabN_IDPABELLON", "class": "text-center" }
        ],
        columnDefs: [
            {
                targets: 1,
                data: 'pabS_TIPO',
                className: "text-center",
                render: function (data) {
                    return (data === 1) ? "PABELLÓN" : "MAUSOLEO";
                }
            },
            {
                targets: 3,
                data: 'pabN_IDPABELLON',
                orderable: false,
                width: "20%",
                render: function (data) {
                    return `
                    <button class="btn btn-sm btn-clean btn-icon btn-icon-md" type="button" onclick="verMapa(` + data + `)"><i class="fadeIn animated bx bx-map"></i></button>
                    <button class="btn btn-sm btn-clean btn-icon btn-icon-md" type="button" onclick="verPabellon(` + data + `)"><i class="fadeIn animated bx bx-pencil"></i></button>
                    <button class="btn btn-sm btn-clean btn-icon btn-icon-md" type="button" onclick="eliminarPabellon(` + data + `)"><i class="fadeIn animated bx bx-trash-alt"></i></button>`;
                }
            }
        ],
        language: translateDatatable,
        initComplete: function (settings, oResponse) {
            $("#totalPabellon").html(oResponse.datos.length)
        }
    });
}

function addPabellon() {
    let _id = $("#idPabellon").val();
    let _nombre = $("#nombrePabellon").val();
    let _tipo = $('input[name="rbPabellon"]:checked').attr("valor");
    if (!$("#nombrePabellon").get(0).checkValidity() || !$('[name="rbPabellon"]').get(0).checkValidity()) {
        $("#formPabellon").addClass('was-validated');
    } else {
        var formData = new FormData();
        formData.append("PABN_IDPABELLON", _id);
        formData.append("PABN_IDCEMENTERIO", 1);
        formData.append("PABS_NOMBRE", _nombre);
        formData.append("PABS_TIPO", _tipo);
        formData.append("PABS_UBICACION", "");
    $.ajax({
        type: "POST",
        url: "Pabellon/Guardar",
        datatype: "json",
        contentType: false,
        processData: false,
        data: formData,
        success: function (data) {
            if (data.estado) {
                buscar();
                if (bus_det) {
                    $("#tablaAdicional").show();
                    $("#idPabellon").val(data.adicionalInt);
                    buscar_detalle(data.adicionalInt);
                }
                $("#formPabellon").removeClass('was-validated');
            } else {
                mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
            }
        },
        error: function (error) {
            mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
        }
    });
    }
}

function eliminarPabellon(id) {
    swal.fire({
        title: 'ELIMINAR PABELLON',
        text: "¿Está seguro que quiere eliminar el Pabellón actual?",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: '¡Eliminar!',
        cancelButtonText: '¡Cancelar!',
        reverseButtons: true
    }).then(function (result) {
        if (result.value) {
            $.ajax({
                type: "DELETE",
                url: "Pabellon/Eliminar",
                data: { idPabellon: id },
                dataType: 'json',
                success: function (data) {
                    if (data.estado)
                        buscar();
                    mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
                },
                error: function (error) {
                    mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
                }
            });
        }
    });
}

function verPabellon(id) {
    limpiarDatos();
    if (es_vacio(id)) {
        $("#lblModalPabellon").html("AÑADIR NUEVO PABELLÓN");
        $("#idPabellon").val("");
        $("#btnAddPabellon").html("Registrar");
        $("#classModalPabellon").removeClass("modal-lg");
    }
    else {
        $("#btnAddPabellon").html("Actualizar");
        $.ajax({
            type: "POST",
            url: "Pabellon/Buscar",
            data: { idPabellon: id },
            dataType: 'json',
            success: function (data) {
                if (data.estado) {
                    $("#idPabellon").val(data.datos[0].pabN_IDPABELLON);
                    $("#nombrePabellon").val(data.datos[0].pabS_NOMBRE);
                    if (data.datos[0].pabS_TIPO === 1) {
                        $("#rbnPabellon").prop("checked", true);
                    } else if(data.datos[0].pabS_TIPO === 2) {
                        $("#rbnMausoleo").prop("checked", true);
                    }
                    $("#lblModalPabellon").html(data.datos[0].pabS_NOMBRE);
                    if (bus_det) {
                        $("#tablaAdicional").show();
                        buscar_detalle(data.datos[0].pabN_IDPABELLON);
                    }
                } else {
                    mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
                }
            },
            error: function (error) {
                mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
            }
        });
    }
    $("#modalPabellon").modal("show");
}

function buscar_detalle(_id, _async = true) {
    $("#classModalPabellon").addClass("modal-lg");
    $('#tableNicho').DataTable({
        destroy: true,
        autoWidth: false,
        ajax: {
            url: 'Nicho/BuscarPorPabellon',
            type: "POST",
            data: { idPabellon: _id },
            dataSrc: 'datos'
        },
        columns: [
            { "name": "nicS_CODNICHO", "data": "nicS_CODNICHO", "class": "text-center" },
            { "name": "nicB_ESTADONICHO", "data": "nicB_ESTADONICHO", "class": "text-center" },
            { "name": "nicB_NUMDIFTOTAL", "data": "nicB_NUMDIFTOTAL", "class": "text-center" },
            { "name": "nicB_NUMDIFACTUAL", "data": "nicB_NUMDIFACTUAL", "class": "text-center" }
        ],
        columnDefs: [
            {
                targets: 1,
                data: 'nicB_ESTADONICHO',
                render: function (data) {
                    let _estado = "";
                    switch (data) {
                        case 1:
                            _estado = "LIBRE";
                            break;
                        case 2:
                            _estado = "ESPACIOS DISPONIBLES";
                            break;
                        case 3:
                            _estado = "OCUPADO";
                            break;
                    }
                    return _estado;
                }
            },
            {
                targets: 4,
                data: 'nicN_IDNICHO',
                orderable: false,
                width: "20%",
                render: function (data) {
                    return `<button class="btn btn-sm btn-clean btn-icon btn-icon-md" type="button" onclick="verNicho(` + data + `)"><i class="fadeIn animated bx bx-pencil"></i></button>
                            <button class="btn btn-sm btn-clean btn-icon btn-icon-md" type="button" onclick="eliminarNicho(` + data + `)"><i class="fadeIn animated bx bx-trash-alt"></i></button>`;
                }
            }
        ],
        language: translateDatatable
    });
}

function verNicho(id)  {
    limpiarDatosDetalle();
    if (es_vacio(id)) {
        $("#lblmodalNicho").html("AÑADIR NUEVO NICHO");
        $("#idNicho").val("");
        $("#btnAddNicho").html("Registrar");
    }
    else {
        $("#btnAddNicho").html("Actualizar");
        $.ajax({
            type: "POST",
            url: "Nicho/Buscar",
            data: { idNicho: id },
            dataType: 'json',
            success: function (data) {
                if (data.estado) {
                    $("#idNicho").val(data.datos[0].nicN_IDNICHO);
                    $("#codigoNicho").val(data.datos[0].nicS_CODNICHO);
                    $("#numDifNicho").val(data.datos[0].nicB_NUMDIFTOTAL);
                    $("#lblmodalNicho").html(data.datos[0].nicS_CODNICHO);
                } else {
                    mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
                }
            },
            error: function (error) {
                mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
            }
        });
    }
    $("#modalNicho").modal("show");
}

function addNicho() {
    let _id = $("#idNicho").val();
    let _idPabellon = $("#idPabellon").val();
    let _codigo = $("#codigoNicho").val();
    let _numDif = $("#numDifNicho").val();
    let objNicho = {
        NICN_IDNICHO: _id,
        NICS_CODNICHO: _codigo,
        NICN_IDPABELLON: _idPabellon,
        NICB_NUMDIFTOTAL: _numDif
    }
    if (!$("#codigoNicho").get(0).checkValidity() || !$("#numDifNicho").get(0).checkValidity()) {
        $("#formNicho").addClass('was-validated');
    } else {
        $.ajax({
            type: "POST",
            url: "Nicho/Guardar",
            data: objNicho,
            dataType: "json",
            success: function (data) {
                if (data.estado) {
                    buscar_detalle(_idPabellon);
                    $("#formNicho").removeClass('was-validated');
                }
                else {
                    mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
                }
            },
                error: function (error) {
                    mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
                }
            });
        $("#modalNicho").modal("hide");
    }
}

function eliminarNicho(id) {
    swal.fire({
        title: 'ELIMINAR NICHO',
        text: "¿Está seguro que quiere eliminar el Nicho actual?",
        type: 'warning',
        showCancelButton: true,
        confirmButtonText: '¡Eliminar!',
        cancelButtonText: '¡Cancelar!',
        reverseButtons: true
    }).then(function (result) {
        if (result.value) {
            $.ajax({
                type: "DELETE",
                url: "Nicho/Eliminar",
                data: { idNicho: id },
                dataType: 'json',
                success: function (data) {
                    if (data.estado) {
                        mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
                        buscar_detalle($("#idPabellon").val());
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

function CargaMasivaPabellon() {
    var _archivo = $("#pabellonFile").get(0).files[0];
    var formData = new FormData();
    formData.append("file", _archivo);
    $.ajax({
        url: "Pabellon/CargaMasiva",
        type: "POST",
        datatype: "json",
        contentType: false,
        processData: false,
        data: formData,
        success: function (data) {
            if (data.estado) {
                buscar();
            }
            mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
        },
        error: function (error) {
            mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
        }
    });
    $("#modalCargaMasiva").modal("hide");
}















function placeMarker(location) {
    // Elimina el marcador anterior (si existe)
    if (selectedLocation) {
        selectedLocation.setMap(null);
    }

    // Crea un nuevo marcador en el punto seleccionado
    selectedLocation = new google.maps.Marker({
        position: location,
        map: map
    });
}

function verMapa(id) {
    limpiarDatos();
    if (es_vacio(id)) {
        $("#lblmodalMapa").html("Seleccionar Ubicación");
        $("#idMapa").val("");
        $("#btnMapa").html("Registrar");
        // Obtén la ubicación actual del usuario
        navigator.geolocation.getCurrentPosition(function (position) {
            var currentLocation = {
                lat: position.coords.latitude,
                lng: position.coords.longitude
            };

            // Crea el mapa centrado en la ubicación actual
            crearMapa(currentLocation);
        });
    } else {
        $("#btnMapa").html("Actualizar");
        $.ajax({
            type: "POST",
            url: "Pabellon/Buscar",
            data: { idPabellon: id },
            dataType: 'json',
            success: function (data) {
                if (data.estado) {
                    $("#idMapa").val(data.datos[0].pabN_IDPABELLON);
                    $("#lblmodalMapa").html(data.datos[0].pabS_NOMBRE);
                    if (!es_vacio(data.datos[0].pabS_UBICACION)) {
                        var currentLocation = {
                            lat: parseFloat(data.datos[0].pabS_UBICACION.split('/')[0]),
                            lng: parseFloat(data.datos[0].pabS_UBICACION.split('/')[1])
                        };

                        // Crea el mapa centrado en la ubicación actual
                        crearMapa(currentLocation);
                    }
                } else {
                    mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
                }
            },
            error: function (error) {
                mostrarMensaje("Error", "Código: " + error.status + " - " + error.responseText, 2, true);
            }
        });
    }
    $("#modalMapa").modal("show");
}

function initMap() {
    // Obtén la ubicación actual del usuario
    navigator.geolocation.getCurrentPosition(function (position) {
        var currentLocation = {
            lat: position.coords.latitude,
            lng: position.coords.longitude
        };
        // Crea el mapa centrado en la ubicación actual
        crearMapa(currentLocation);
    });
}

function crearMapa(currentLocation) {
    return new Promise(function (resolve, reject) {
        map = new google.maps.Map(document.getElementById('map'), {
            center: currentLocation,
            zoom: 18
        });

        map.addListener('click', function (event) {
            placeMarker(event.latLng);
        });

        // Añadir marcador en la ubicación actual
        var marker = new google.maps.Marker({
            position: currentLocation,
            map: map
        });

        resolve();
    });
}

function guardarUbicacion() {
    var id = $("#idMapa").val();
    var selectedLatLng = selectedLocation.getPosition();
    var latitude = selectedLatLng.lat();
    var longitude = selectedLatLng.lng();
    var coordenadas = latitude + "/" + longitude;

    var formData = new FormData();
    formData.append("PABN_IDPABELLON", id);
    formData.append("PABS_UBICACION", coordenadas);

    $.ajax({
        type: "POST",
        url: "Pabellon/GuardarUbicacion",
        contentType: false,
        processData: false,
        data: formData,
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
    $('#modalMapa').modal('hide');
}