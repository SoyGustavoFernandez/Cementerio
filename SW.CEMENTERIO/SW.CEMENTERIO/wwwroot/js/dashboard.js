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
                $("#lblTotalDifuntos").html(data.response.adicionalInt);
                let _label = data.resultado.labels;
                let _data = data.resultado.data;
                new Chart(document.getElementById('chartDifuntos').getContext('2d'),
                    {
                        type: 'doughnut',
                        data: {
                            labels: _label,
                            datasets: [{
                                data: _data,
                                backgroundColor: ['#923eb9',
                                    '#f73757',
                                    '#18bb6b',
                                    '#32bfff',
                                    '#ffab4d',
                                    '#0a58ca'],
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