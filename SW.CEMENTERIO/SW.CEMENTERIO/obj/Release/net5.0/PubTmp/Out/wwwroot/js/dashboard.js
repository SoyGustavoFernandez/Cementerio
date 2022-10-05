$(document).ready(function () {
    buscar();
});

function buscar() {
    $.ajax({
        type: "POST",
        url: "Dashboard/BuscarDifuntos",
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (data) {
            if (data.response.estado) {
                //$("#lblTotalDifuntos").html(data.response.datos.sum('cantidaD_DIFUNTOS'));
                new Chart(document.getElementById('chartDifuntos').getContext('2d'),
                    {
                        type: 'doughnut',
                        data: {
                            labels: [data.resultado.labels],
                            datasets: [{
                                data: [data.resultado.data],
                                backgroundColor: [
                                    '#923eb9',
                                    '#f73757',
                                    '#18bb6b'
                                ],
                                borderWidth: 1
                            }]
                        },
                        options: {
                            maintainAspectRatio: false,
                            cutout: 125,
                            plugins: {
                                legend: {
                                    display: false,
                                }
                            }

                        }
                    });
            } else {
                mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
            }
        },
        error: function (error) {
            mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
        }
    });
}