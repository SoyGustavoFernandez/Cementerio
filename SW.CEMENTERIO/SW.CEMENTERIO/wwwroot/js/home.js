var map;
var selectedLocation;

$(document).ready(function () {
    $("#divLogoCementerio").show();
});

function buscarSerQuerido() {
    $("#tablaDifunto tbody").html("");
    let _nombre = $("#nombreDifunto").val();
    let _paterno = $("#nombrePaterno").val();
    let _materno = $("#nombreMaterno").val();
    if (!$("#nombreDifunto").get(0).checkValidity() || !$("#nombrePaterno").get(0).checkValidity() ||
        !$("#nombreMaterno").get(0).checkValidity()) {
        $("#formDifunto").addClass('was-validated');
    } else {
        let objDifunto = {
            DIFS_NOMBRES: _nombre,
            DIFS_APEPATERNO: _paterno,
            DIFS_APEMATERNO: _materno
        }
        $.ajax({
            type: "GET",
            url: "Difunto/BuscarSerQuerido",
            data: objDifunto,
            dataType: "json",
            success: function (data) {
                if (data.estado) {
                    llenarTabla(data);
                    $("#tablaGeneral").show();
                    $("#divLogoCementerio").hide();
                    $("#Detalle").hide();
                    $("#formDifunto").removeClass('was-validated');
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

function llenarTabla(_data) {
    $("#tablaDifunto").DataTable().clear();
    $("#tablaDifunto").DataTable().destroy();
    var htmlDifunto = "";
    $.each(_data.datos, function (key, registro) {
        htmlDifunto += "<tr><td style=\"text-align: center\">" + registro.difS_NOMBRES + "</td><td style=\"text-align: center\">" + registro.difS_APEMATERNO + "</td><td style=\"text-align: center\">" + registro.difS_APEPATERNO + "</td><td style=\"text-align: center\">" + moment(registro.difD_FECHADEFUNCION).format('DD/MM/YYYY') + "</td><td style=\"text-align: center\"><button class=\"btn btn-sm btn-clean btn-icon btn-icon-md\" type=\"button\" onclick=\"detalleDifunto(" + registro.difN_IDDIFUNTO + ")\"><i class=\"fadeIn animated lni lni-eye\"></i></button></td></tr>"
    });
    $("#tablaDifunto tbody").html(htmlDifunto);
    $('#tablaDifunto').DataTable({ language: translateDatatable });
}

function detalleDifunto(_id) {
    $.ajax({
        type: "POST",
        url: "Difunto/Buscar",
        data: { idDifunto: _id },
        async: false,
        dataType: 'json',
        success: function (data) {
            if (data.estado) {
                $("#tablaGeneral").hide();
                $("#Detalle").show();
                $("#nombreDifuntoCard").html("<ion-icon name=\"compass-sharp\" class=\"me-2\"></ion-icon> " + data.datos[0].difS_NOMBRES + " " + data.datos[0].difS_APEPATERNO + " " + data.datos[0].difS_APEMATERNO);
                $("#fecDefuncionCard").html("<ion-icon name=\"compass-sharp\" class=\"me-2\"></ion-icon> " + moment(data.datos[0].difD_FECHADEFUNCION).format('DD/MM/YYYY'));
                $("#nombrePabellonCard").html("<ion-icon name=\"compass-sharp\" class=\"me-2\"></ion-icon> " + data.datos[0].pabS_NOMBRE);
                $("#nombreNichoCard").html("<ion-icon name=\"compass-sharp\" class=\"me-2\"></ion-icon> " + data.datos[0].nicS_CODNICHO);
                if (!es_vacio(data.datos[0].pabS_UBICACION)) {
                    var currentLocation = {
                        lat: parseFloat(data.datos[0].pabS_UBICACION.split('/')[0]),
                        lng: parseFloat(data.datos[0].pabS_UBICACION.split('/')[1])
                    };
                    mostrarCamino(currentLocation.lat, currentLocation.lng);
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

function initMap() {
    // Aquí puedes llamar a la función mostrarCamino o cualquier otra configuración adicional del mapa
    mostrarCamino(37.7749, -122.4194); // Ejemplo de llamada a la función mostrarCamino con una ubicación específica
}

























function mostrarCamino(latitud, longitud) {
    // Obtén la ubicación actual del usuario
    navigator.geolocation.getCurrentPosition(function (position) {
        var currentLocation = {
            lat: position.coords.latitude,
            lng: position.coords.longitude
        };

        // Crea el mapa centrado en la ubicación actual
        var map = new google.maps.Map(document.getElementById('map'), {
            center: currentLocation,
            zoom: 12
        });

        // Crea el servicio de direcciones de Google Maps
        var directionsService = new google.maps.DirectionsService();
        var directionsDisplay = new google.maps.DirectionsRenderer({
            map: map
        });

        // Configura la solicitud de dirección
        var request = {
            origin: currentLocation,
            destination: {
                lat: latitud,
                lng: longitud
            },
            travelMode: google.maps.TravelMode.DRIVING
        };

        // Obtiene las direcciones y muestra el camino en el mapa
        directionsService.route(request, function (result, status) {
            if (status == google.maps.DirectionsStatus.OK) {
                directionsDisplay.setDirections(result);

                // Agregar opción de inicio de recorrido
                var startButton = document.getElementById('startButton');
                startButton.addEventListener('click', function () {
                    // Obtener las coordenadas de origen y destino
                    var origin = `${currentLocation.lat},${currentLocation.lng}`;
                    var destination = `${latitud},${longitud}`;

                    // Abrir la aplicación de Google Maps con las coordenadas
                    window.open(`https://www.google.com/maps/dir/?api=1&origin=${origin}&destination=${destination}`);
                });
            }
        });
    });
}
