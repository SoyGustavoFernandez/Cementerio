$(document).ready(function () {
    buscarDifuntos();
    buscarPabellones();
});

function buscarDifuntos() {
    $.ajax({
        type: "POST",
        url: "Dashboard/BuscarDifuntos",
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (data) {
            if (!es_vacio(data.response)) {
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
            }
        },
        error: function (error) {
            mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
        }
    });
}

function buscarPabellones() {
    $.ajax({
        type: "POST",
        url: "Dashboard/BuscarPabellones",
        dataType: 'json',
        contentType: false,
        processData: false,
        success: function (data) {
            if (!es_vacio(data.response)) {
                if (data.response.estado) {
                    $("#lblTotalPabellones").html("Total Pabellones: " + data.response.adicionalInt);
                    let _label = data.resultado.labels;
                    let _dataLibre = data.resultado.dataLibre;
                    let _dataOcupado = data.resultado.dataOcupado;
                    var ctx = document.getElementById('chartPabellones').getContext('2d');
                    var myChart = new Chart(ctx, {
                        type: 'bar',
                        data: {
                            labels: _label,
                            datasets: [{
                                label: 'Nichos Libres',
                                data: _dataLibre,
                                backgroundColor: [ '#923eb9' ],
                                borderColor: [ '#923eb9' ],
                                borderWidth: 0
                            },
                            {
                                label: 'Nichos Ocupados',
                                data: _dataOcupado,
                                backgroundColor: ['rgb(146 62 185 / 32%)'],
                                borderColor: ['rgb(146 62 185 / 32%)'],
                                borderWidth: 0
                            }]
                        },
                        options: {
                            maintainAspectRatio: false,
                            barPercentage: 0.3,
                            //categoryPercentage: 0.5,
                            plugins: {
                                legend: {
                                    display: false,
                                }
                            },
                            scales: {
                                x: {
                                    stacked: true,
                                    beginAtZero: true
                                },
                                y: {
                                    stacked: true,
                                    beginAtZero: true
                                }
                            }
                        }
                    });




                    //new Chart(document.getElementById('chartPabellones').getContext('2d'),
                    //    {
                    //        type: 'doughnut',
                    //        data: {
                    //            labels: _label,
                    //            datasets: [{
                    //                data: _data,
                    //                backgroundColor: ['#923eb9',
                    //                    '#f73757',
                    //                    '#18bb6b',
                    //                    '#32bfff',
                    //                    '#ffab4d',
                    //                    '#0a58ca'],
                    //                borderWidth: 1
                    //            }]
                    //        },
                    //        options: {
                    //            maintainAspectRatio: false,
                    //            cutout: 125,
                    //            plugins: {
                    //                legend: {
                    //                    display: false,
                    //                }
                    //            }

                    //        }
                    //    });
                } else {
                    mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
                }
            }
        },
        error: function (error) {
            mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
        }
    });
}