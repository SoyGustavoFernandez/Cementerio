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
                $("#imgPabellon").attr('src', data.datos[0].pabS_UBICACION)
            } else {
                mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
            }
        },
        error: function (error) {
            mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
        }
    });
}