var ano = new Date().getFullYear();
var mes = (new Date().getMonth() + 1).toString();
var dia = new Date().getDate().toString();
var diaSemana = new Date().getDay().toString();
if (mes.length === 1) { mes = '0' + mes; }
if (dia.length === 1) { dia = '0' + dia; }
var hora = new Date().getHours();
var minuto = new Date().getMinutes();
var segundo = new Date().getSeconds();
var $ContenedorCargando = $('<div style="width: 100%;height:100%;z-index:4500;position:fixed;opacity: 0.5;background:black;"></div>');
var $MensajeCargando;
var ajaxState = true;
var cal_locale = {
    format: 'DD/MM/YYYY',
    "applyLabel": "Aplicar",
    "cancelLabel": "Cancelar",
    "fromLabel": "Desde",
    "toLabel": "Hasta",
    "customRangeLabel": "Personalizado",
    "daysOfWeek": [
        "Do",
        "Lu",
        "Ma",
        "Mi",
        "Ju",
        "Vi",
        "Sa"
    ],
    "monthNames": [
        "Enero",
        "Febrero",
        "Marzo",
        "Abril",
        "Mayo",
        "Junio",
        "Julio",
        "Agusto",
        "Septiembre",
        "Octubre",
        "Noviembre",
        "Diciembre"
    ],
}

var locale = {
    format: 'DD/MM/YYYY',
    "applyLabel": "Aplicar",
    "cancelLabel": "Cancelar",
    "fromLabel": "Desde",
    "toLabel": "Hasta",
    "customRangeLabel": "Personalizado",
    "daysOfWeek": [
        "Do",
        "Lu",
        "Ma",
        "Mi",
        "Ju",
        "Vi",
        "Sa"
    ],
    "monthNames": [
        "Enero",
        "Febrero",
        "Marzo",
        "Abril",
        "Mayo",
        "Junio",
        "Julio",
        "Agosto",
        "Septiembre",
        "Octubre",
        "Noviembre",
        "Diciembre"
    ],
};

var listaMes = [
    { NUMERO: 1, NOMBRE: "Enero" },
    { NUMERO: 2, NOMBRE: "Febrero" },
    { NUMERO: 3, NOMBRE: "Marzo" },
    { NUMERO: 4, NOMBRE: "Abril" },
    { NUMERO: 5, NOMBRE: "Mayo" },
    { NUMERO: 6, NOMBRE: "Junio" },
    { NUMERO: 7, NOMBRE: "Julio" },
    { NUMERO: 8, NOMBRE: "Agosto" },
    { NUMERO: 9, NOMBRE: "Septiembre" },
    { NUMERO: 10, NOMBRE: "Octubre" },
    { NUMERO: 11, NOMBRE: "Noviembre" },
    { NUMERO: 12, NOMBRE: "Diciembre" }];

var listaDiaSemana = [
    { NUMERO: "1", NOMBRE: "Lunes", SIGLA: "Lu" },
    { NUMERO: "2", NOMBRE: "Martes", SIGLA: "Ma" },
    { NUMERO: "3", NOMBRE: "Miércoles", SIGLA: "Mi" },
    { NUMERO: "4", NOMBRE: "Jueves", SIGLA: "Ju" },
    { NUMERO: "5", NOMBRE: "Viernes", SIGLA: "Vi" },
    { NUMERO: "6", NOMBRE: "Sabado", SIGLA: "Sa" },
    { NUMERO: "7", NOMBRE: "Domingo", SIGLA: "Do" }];

var listaBoolean = [{ value: 0, label: 'No' }, { value: 1, label: 'Si' }];

$(document).ready(function () {
    $('#divBody').append($ContenedorCargando);
    $MensajeCargando = $('<div style="z-index: 4510; position: fixed; left: 50% !important; top: 50% !important;"><div class="swal2-actions swal2-loading" style="display: flex;"><button type="button" class="swal2-confirm swal2-styled" aria-label="" disabled="" style="display: flex;border-left-color: rgb(48, 133, 214);border-right-color: rgb(48, 133, 214);">OK</button></div></div>');
    $('body').append($MensajeCargando);
    $ContenedorCargando.hide();
    $MensajeCargando.hide();
    validarSoloNumero($(this));
    validarSoloFloat($(this));
}).ajaxStart(function () {
    if (ajaxState) {
        $ContenedorCargando.show();
        $MensajeCargando.show();
    }
}).ajaxStop(function () {
    if (ajaxState) {
        $ContenedorCargando.hide();
        $MensajeCargando.hide();
    }
});

//Parsear JWT a JSON
function parseJwt(token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(atob(base64).split('').map(function (c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
}

function nombre_mes(_numero) {
    var resultado = "";
    for (var i = 0; i < listaMes.length; i++) {
        if (listaMes[i].NUMERO === _numero) {
            resultado = listaMes[i].NOMBRE;
            break;
        }
    }
    return resultado;
}

function nombre_dia_semana(_numero) {
    var resultado = "";
    for (var i = 0; i < listaDiaSemana.length; i++) {
        if (listaDiaSemana[i].NUMERO === _numero) {
            resultado = listaDiaSemana[i].NOMBRE;
            break;
        }
    }
    return resultado;
}

function nombre_bool(_numero) {
    var resultado = "";
    for (var i = 0; i < listaBoolean.length; i++) {
        if (listaBoolean[i].value == _numero) {
            resultado = listaBoolean[i].label;
            break;
        }
    }
    return resultado;
}

function sigla_dia_semana(_numero) {
    var resultado = "";
    for (var i = 0; i < listaDiaSemana.length; i++) {
        if (listaDiaSemana[i].NUMERO === _numero) {
            resultado = listaDiaSemana[i].SIGLA;
            break;
        }
    }
    return resultado;
}

var translateDatatable =
{
    "sProcessing": "Procesando...",
    "sLengthMenu": "Mostrar _MENU_ registros",
    "sZeroRecords": "No se encontraron resultados",
    "sEmptyTable": "Ningún dato disponible en esta tabla.",
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
    },
    "buttons": {
        "copy": "Copiar",
        "colvis": "Visibilidad"
    }
};

function es_vacio(_valor) {
    if (_valor === null || jQuery.trim(_valor) === "" || _valor === undefined) {
        return true;
    }
    return false;
}

function rep_vacio(_valor, _valorN) {
    return es_vacio(_valor) ? _valorN : _valor;
}

function validarSoloNumero(_objeto) {
    _objeto.find(".soloNumero").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 || (e.keyCode === 65 && e.ctrlKey === true) || (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });
}

function validarSoloFloat(_objeto) {
    _objeto.find(".soloFloat").keydown(function (e) {
        if ($.inArray(e.keyCode, [46, 8, 9, 27, 13, 110, 190]) !== -1 || (e.keyCode === 65 && e.ctrlKey === true) || (e.keyCode >= 35 && e.keyCode <= 39)) {
            return;
        }
        if ((e.keyCode !== 46 || $(this).val().indexOf('.') !== -1) && (e.shiftKey || (e.keyCode < 48 || e.keyCode > 57)) && (e.keyCode < 96 || e.keyCode > 105)) {
            e.preventDefault();
        }
    });
}

function mostrarMensaje(_title, _mensaje, _tipo = 1, _button = true, _timer = 0) {
    switch (_tipo) {
        case -1: _tipo = "warning"; break;
        case 0: _tipo = "info"; break;
        case 1: _tipo = "success"; break;
        case 2: _tipo = "error"; break;
    }
    if (_timer > 0) { _timer *= 1000; }
    swal.fire({
        title: _title,
        text: _mensaje,
        type: _tipo,
        showConfirmButton: _button,
        timer: _timer
    });
}

function StringToDate(string) {
    var ano = new Date(string).getFullYear().toString();
    var mes = (new Date(string).getMonth() + 1).toString();
    var dia = new Date(string).getDate().toString();
    if (mes.length === 1) { mes = '0' + mes; }
    if (dia.length === 1) { dia = '0' + dia; }
    var diaHoy = dia + '/' + mes + '/' + ano;
    return diaHoy;
}

function formato_moneda(_number, _tipo = 1, _decimales = 2) {
    switch (_tipo) {
        case 1:
            //soles
            return (new Intl.NumberFormat('es-PE', {
                style: 'currency',
                currency: 'PEN',
                maximumFractionDigits: _decimales,
            })).format(_number);
            break;
        case 2:
            //dolares
            return (new Intl.NumberFormat('en-US', {
                style: 'currency',
                currency: 'USD',
                maximumFractionDigits: _decimales,
            })).format(_number);
            break;
        case 3:
            //otros
            break;
    }
}

function formato_numero(_number, _tipo = 1, _decimales = 2) {
    switch (_tipo) {
        case 1:
            //punto
            return parseFloat(_number).toLocaleString('en-EU', { maximumFractionDigits: _decimales, minimumFractionDigits: _decimales });
            break;
        case 2:
            //coma
            return parseFloat(_number).toLocaleString(undefined, { maximumFractionDigits: _decimales, minimumFractionDigits: _decimales });
            break;
        case 3:
            //otros
            break;
    }
}

Array.prototype.unique = function (a) {
    return function () {
        return this.filter(a);
    };
}(function (a, b, c) {
    return c.indexOf(a, b + 1) < 0;
});

Number.prototype.padLeft = function (base, chr) {
    var len = (String(base || 10).length - String(this).length) + 1;
    return len > 0 ? new Array(len).join(chr || '0') + this : this;
};

function generarAleatorio(length, type) {
    switch (type) {
        case 'num':
            characters = "0123456789";
            break;
        case 'alf':
            characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
            break;
        case 'rand':
            //FOR ↓
            break;
        default:
            characters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            break;
    }
    var random = "";
    for (i = 0; i < length; i++) {
        if (type === 'rand') {
            random += String.fromCharCode((Math.floor((Math.random() * 100)) % 94) + 33);
        } else {
            random += characters.charAt(Math.floor(Math.random() * characters.length));
        }
    }
    return random;
}

function colorAleatorio() {
    var makingColorCode = '0123456789ABCDEF';
    var finalCode = '#';
    for (var counter = 0; counter < 6; counter++) {
        finalCode = finalCode + makingColorCode[Math.floor(Math.random() * 16)];
    }
    return finalCode;
}

var obtener_hora = () => hora + ':' + minuto;

//var obtener_dia = () => dia + '/' + mes + '/' + ano;

function obtener_dia(format) {

    format = es_vacio(format) ? 1 : format;
    switch (format) {
        case 1: // dd/mm/yyyy
            return moment().format('DD/MM/YYYY');
            break;
        case 2: // yyyy/mm/dd
            return moment().format('YYYY/MM/DD');
            break;
        case 3: // mm/dd/yyyy
            return moment().format('L');
            break;
        case 4: // wednesday, 15 de julio de 2020 12:40 PM
            return moment().format('LLLL');
            break;
        case 5: // Miércoles, 15 de Julio de 2020 nombre_dia_semana(diaSemana) + ', ' +
            return dia + ' de ' + nombre_mes(mes) + ' de ' + ano;
            break;
    }
}

function mostrarFechaHora(_div = "reloj") {
    $("#" + _div).html(obtener_dia() + " " + moment().format('HH:mm:ss'));
    //setTimeout(mostrarFechaHora, 1000);
}

Date.prototype.addDays = function (days) {
    var date = new Date(this.valueOf());
    date.setDate(date.getDate() + days);
    return date;
}

//yyyy-MM-dd
function addDays(_fecha, _dias, _formato = 0) {
    //var newdate = new Date(_fecha + ' 00:00:00');
    switch (_formato) {
        case 0:
            return new Date(_fecha).addDays(_dias).toISOString().substring(0, 10); //yyyy-MM-dd
            break;
        case 1:
            return new Date(_fecha).addDays(_dias).toLocaleDateString('es-PE', { year: 'numeric', month: '2-digit', day: '2-digit' }); //dd/MM/yyyy
            break;
        case 2:
            return new Date(_fecha).addDays(_dias);
            break;
        default:
            return null;
            break;
    }
}

function formatTextMax(_val, _length, _aux = '') {
    if (!es_vacio(_val)) {
        if (_val.length > _length) {
            return _val.substr(0, _length) + _aux;
        }
        else {
            return _val.substr(0, _length);
        }
    }
    else {
        return _val;
    }
}

var numeroALetras = (function () {
    function Unidades(num) {
        switch (num) {
            case 1:
                return 'UN';
            case 2:
                return 'DOS';
            case 3:
                return 'TRES';
            case 4:
                return 'CUATRO';
            case 5:
                return 'CINCO';
            case 6:
                return 'SEIS';
            case 7:
                return 'SIETE';
            case 8:
                return 'OCHO';
            case 9:
                return 'NUEVE';
        }
        return '';
    } //Unidades()

    function Decenas(num) {
        let decena = Math.floor(num / 10);
        let unidad = num - (decena * 10);
        switch (decena) {
            case 1:
                switch (unidad) {
                    case 0:
                        return 'DIEZ';
                    case 1:
                        return 'ONCE';
                    case 2:
                        return 'DOCE';
                    case 3:
                        return 'TRECE';
                    case 4:
                        return 'CATORCE';
                    case 5:
                        return 'QUINCE';
                    default:
                        return 'DIECI' + Unidades(unidad);
                }
            case 2:
                switch (unidad) {
                    case 0:
                        return 'VEINTE';
                    default:
                        return 'VEINTI' + Unidades(unidad);
                }
            case 3:
                return DecenasY('TREINTA', unidad);
            case 4:
                return DecenasY('CUARENTA', unidad);
            case 5:
                return DecenasY('CINCUENTA', unidad);
            case 6:
                return DecenasY('SESENTA', unidad);
            case 7:
                return DecenasY('SETENTA', unidad);
            case 8:
                return DecenasY('OCHENTA', unidad);
            case 9:
                return DecenasY('NOVENTA', unidad);
            case 0:
                return Unidades(unidad);
        }
    } //Unidades()

    function DecenasY(strSin, numUnidades) {
        if (numUnidades > 0)
            return strSin + ' Y ' + Unidades(numUnidades);
        return strSin;
    } //DecenasY()

    function Centenas(num) {
        let centenas = Math.floor(num / 100);
        let decenas = num - (centenas * 100);
        switch (centenas) {
            case 1:
                if (decenas > 0)
                    return 'CIENTO ' + Decenas(decenas);
                return 'CIEN';
            case 2:
                return 'DOSCIENTOS ' + Decenas(decenas);
            case 3:
                return 'TRESCIENTOS ' + Decenas(decenas);
            case 4:
                return 'CUATROCIENTOS ' + Decenas(decenas);
            case 5:
                return 'QUINIENTOS ' + Decenas(decenas);
            case 6:
                return 'SEISCIENTOS ' + Decenas(decenas);
            case 7:
                return 'SETECIENTOS ' + Decenas(decenas);
            case 8:
                return 'OCHOCIENTOS ' + Decenas(decenas);
            case 9:
                return 'NOVECIENTOS ' + Decenas(decenas);
        }

        return Decenas(decenas);
    } //Centenas()

    function Seccion(num, divisor, strSingular, strPlural) {
        let cientos = Math.floor(num / divisor);
        let resto = num - (cientos * divisor);
        let letras = '';
        if (cientos > 0)
            if (cientos > 1)
                letras = Centenas(cientos) + ' ' + strPlural;
            else
                letras = strSingular;

        if (resto > 0)
            letras += '';

        return letras;
    } //Seccion()

    function Miles(num) {
        let divisor = 1000;
        let cientos = Math.floor(num / divisor);
        let resto = num - (cientos * divisor);

        let strMiles = Seccion(num, divisor, 'UN MIL', 'MIL');
        let strCentenas = Centenas(resto);

        if (strMiles === '')
            return strCentenas;

        return strMiles + ' ' + strCentenas;
    } //Miles()

    function Millones(num) {
        let divisor = 1000000;
        let cientos = Math.floor(num / divisor)
        let resto = num - (cientos * divisor)

        let strMillones = Seccion(num, divisor, 'UN MILLON DE', 'MILLONES DE');
        let strMiles = Miles(resto);

        if (strMillones === '')
            return strMiles;

        return strMillones + ' ' + strMiles;
    } //Millones()

    return function NumeroALetras(num, currency) {
        currency = currency || {};
        let data = {
            numero: num,
            enteros: Math.floor(num),
            centavos: (((Math.round(num * 100)) - (Math.floor(num) * 100))),
            letrasCentavos: '',
            letrasMonedaPlural: currency.plural || 'SOLES', //'PESOS', 'Dólares', 'Bolívares', 'etcs'
            letrasMonedaSingular: currency.singular || 'SOL', //'PESO', 'Dólar', 'Bolivar', 'etc'
            letrasMonedaCentavoPlural: currency.centPlural || 'CENTIMOS',
            letrasMonedaCentavoSingular: currency.centSingular || 'CENTIMOS'
        };

        if (data.centavos > 0) {
            data.letrasCentavos = 'CON ' + (function () {
                if (data.centavos === 1)
                    return Millones(data.centavos) + ' ' + data.letrasMonedaCentavoSingular;
                else
                    return Millones(data.centavos) + ' ' + data.letrasMonedaCentavoPlural;
            })();
        }

        if (data.enteros === 0)
            return 'CERO ' + data.letrasMonedaPlural + ' ' + data.letrasCentavos;
        if (data.enteros === 1)
            return Millones(data.enteros) + ' ' + data.letrasMonedaSingular + ' ' + data.letrasCentavos;
        else
            return Millones(data.enteros) + ' ' + data.letrasMonedaPlural + ' ' + data.letrasCentavos;
    };
})();

function orderJSON(_json, _colum, _orden = 'asc') {
    return _json.sort(function (a, b) {
        var x = a[_colum],
            y = b[_colum];
        if (_orden === 'asc') {
            return ((x < y) ? -1 : ((x > y) ? 1 : 0));
        }
        if (_orden === 'desc') {
            return ((x > y) ? -1 : ((x < y) ? 1 : 0));
        }
    });
}

function eliminarVaciosJSON(jsonx) {
    for (var clave in jsonx) {
        if (typeof jsonx[clave] === 'string') {
            if (jsonx[clave] === 'Vacío' || jsonx[clave] === '') {
                delete jsonx[clave];
            }
        } else if (typeof jsonx[clave] === 'object') {
            eliminarVaciosJSON(jsonx[clave]);
        }
    }
}

function diferencia_horas(hora_inicio) {
    var hora_final = new Date().getHours();
    var formatohora = /^([01]?[0-9]|2[0-3]):[0-5][0-9]$/;
    if (!hora_inicio.match(formatohora)) return;
    var minutos_inicio = hora_inicio.split(':').reduce((p, c) => parseInt(p) * 60 + parseInt(c));
    var minutos_final = hora_final.split(':').reduce((p, c) => parseInt(p) * 60 + parseInt(c));
    if (minutos_final < minutos_inicio) return;
    var diferencia = minutos_final - minutos_inicio;
    var horas = Math.floor(diferencia / 60);
    var minutos = diferencia % 60;
    return horas + ':' + (minutos < 10 ? '0' : '') + minutos;
}

function getParameterByName(_param) {
    _param = _param.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + _param + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}

function getParamDetalle(idParam, idSelect) {
    $.ajax({
        type: "GET",
        url: urlServicios + "ParametroDetalle/SelectByParametro",
        data: { idParametro: idParam },
        dataType: "json",
        async: false,
        success: function (data) {
            $.each(data, function (key, registro) {
                if (registro.padN_VAL !== 0) {
                    $("#" + idSelect).append('<option value=' + registro.padN_VAL + '>' + registro.padC_VAL_TXT + '</option>');
                }
            });
        },
        error: function (error) {
            mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 3, true);
        }
    });
}

function searchElementInJSON(_array, _search) {
    for (let p = 0; p < _array.length; p++) {
        if (_array[p]._nombres === _search) {
            return false;
        }
    }
    return true;
}

function deleteElementInArray(_array, _item) {
    if (_array.indexOf(_item) !== -1) _array.splice(_array.indexOf(_item), 1);
}

function fillEmpresa(_id) {
    $.ajax({
        type: "GET",
        url: urlServicios + "Empresa/SelectAll",
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, registro) {
                $("#" + _id).append('<option value=' + registro.empN_ID_EMPRESA + '>' + registro.empC_RAZON_SOCIAL + '</option>');
            });
        },
        error: function (error) {
            mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 3, true);
        }
    });
}

function fillHorario(_id, _idempresa = null) {
    $("#" + _id).empty();
    $.ajax({
        type: "GET",
        url: urlServicios + "TipoHorario/SelectByEmpresa",
        data: { idEmpresa: es_vacio(_idempresa) ? empresaID : parseInt(_idempresa) },
        dataType: "json",
        success: function (data) {
            $.each(data, function (key, registro) {
                $("#" + _id).append('<option value=' + registro.tiphorN_ID_TIPO_HORARIO + '>' + registro.tiphorC_NOMBRE + '</option>');
            });
            $("#" + _id).append('<option value=-1>Otros</option>');
        },
        error: function (error) {
            mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 3, true);
        }
    });
}

function nemuAdmin() {
    var menuAdmin = $("#menuadmin");
    var html = "";

    if (tipoUser === 4) {
        html += '<li class="kt-menu__item kt-menu__item--open" aria-haspopup="true"><a href="/Home" class="kt-menu__link "><i class="kt-menu__link-icon flaticon2-protection"></i><span class="kt-menu__link-text">Inicio</span></a></li>';
    }

    if (tipoUser === 0 || tipoUser === 3) {
        html += '<li class="kt-menu__item  kt-menu__item--submenu kt-menu__item--open" aria-haspopup="true" data-ktmenu-submenu-toggle="hover">';
        html += '   <a href="javascript:void(0);" class="kt-menu__link kt-menu__toggle"><i class="kt-menu__link-icon flaticon2-gear"></i><span class="kt-menu__link-text">Mantenimiento</span><i class="kt-menu__ver-arrow la la-angle-right"></i></a>';
        html += '   <div class="kt-menu__submenu ">';
        html += '       <span class="kt-menu__arrow"></span>';
        html += '       <ul class="kt-menu__subnav">';

        html += '       <li class="kt-menu__item " aria-haspopup="true"><a href="/Mantenimiento/Area" class="kt-menu__link "><i class="kt-menu__link-bullet kt-menu__link-bullet--line"><span></span></i><span class="kt-menu__link-text">Áreas</span></a></li>';
        html += '       <li class="kt-menu__item " aria-haspopup="true"><a href="/Mantenimiento/Asistencia" class="kt-menu__link "><i class="kt-menu__link-bullet kt-menu__link-bullet--line"><span></span></i><span class="kt-menu__link-text">Asistencias</span></a></li>';
        html += '       <li class="kt-menu__item " aria-haspopup="true"><a href="/Mantenimiento/Cargo" class="kt-menu__link "><i class="kt-menu__link-bullet kt-menu__link-bullet--line"><span></span></i><span class="kt-menu__link-text">Cargos</span></a></li>';
        html += '       <li class="kt-menu__item " aria-haspopup="true"><a href="/Mantenimiento/Horario" class="kt-menu__link "><i class="kt-menu__link-bullet kt-menu__link-bullet--line"><span></span></i><span class="kt-menu__link-text">Días Laborables</span></a></li>';

        if (tipoUser === 0) {
            html += '       <li class="kt-menu__item " aria-haspopup="true"><a href="/Mantenimiento/Empresa" class="kt-menu__link "><i class="kt-menu__link-bullet kt-menu__link-bullet--line"><span></span></i><span class="kt-menu__link-text">Empresa</span></a></li>';
            html += '       <li class="kt-menu__item " aria-haspopup="true"><a href="/Mantenimiento/Parametro" class="kt-menu__link "><i class="kt-menu__link-bullet kt-menu__link-bullet--line"><span></span></i><span class="kt-menu__link-text">Parametro</span></a></li>';
        }

        html += '           <li class="kt-menu__item " aria-haspopup="true"><a href="/Mantenimiento/TipoHorario" class="kt-menu__link "><i class="kt-menu__link-bullet kt-menu__link-bullet--line"><span></span></i><span class="kt-menu__link-text">Tipos de Horario</span></a></li>';
        html += '           <li class="kt-menu__item " aria-haspopup="true"><a href="/Mantenimiento/Trabajador" class="kt-menu__link "><i class="kt-menu__link-bullet kt-menu__link-bullet--line"><span></span></i><span class="kt-menu__link-text">Trabajadores</span></a></li>';
        html += '       </ul>';
        html += '   </div>';
        html += '</li>';
    }

    if (tipoUser === 1 || tipoUser === 2) {
        html += '<li class="kt-menu__item kt-menu__item--open"><a href="/Home/Cuenta" class="kt-menu__link "><i class="kt-menu__link-icon flaticon2-protection"></i><span class="kt-menu__link-text">Cuenta</span></a></li>';
    }
    menuAdmin.append(html);
}

function SubirArchivo(_file) {
    var fileUpload = $("#" + _file).get(0);
    var files = fileUpload.files;
    var ImagenFile = new FormData();
    for (var i = 0; i < files.length; i++) {
        ImagenFile.append("x_archivo", files[i]);
    }
    var cUrlFile = '';
    if (files.length) {
        $.ajax({
            url: UrlArchivos + "?x_contenedor=Soltech.Asistencia",
            type: "POST",
            contentType: false,
            async: false,
            processData: false,
            data: ImagenFile,
            success: function (result) {
                cUrlFile = result.message;
            },
            error: function (err) {
                console.log(err.statusText);
            }
        });
    }
    else {
        cUrlFile = $("#" + _file).attr('data-default-file');
    }
    return cUrlFile;
}

function separaCaracteres(_cadena, _caracter, _position) {
    return _cadena.split(_caracter)[_position];
}

function resetTree(_val) {
    empresaSelected = parseInt(_val);
    $('.kt_tree_6').jstree().destroy();
    KTTreeview.init();
}

function dateToInt(_date) {
    var fecha = moment(_date).format("YYYY-MM-DD");
    var fechaResponse = fecha.replace(/-/g, "");
    return parseInt(fechaResponse);
}

function CerrarSesion() {
    $.ajax({
        type: "POST",
        url: "/Login/LogOut",
        datatype: "JSON",
        contentType: false,
        processData: false,
        success: function (data) {
            location.reload();
        },
        error: function (error) {
            mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 3, true);
        }
    });
}



//NUEVAS FUNCIONES//

function cargarPabellon() {
    $.ajax({
        type: "POST",
        url: "Pabellon/Buscar",
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.estado) {
                $("#selectPabellon").empty();
                $.each(data.datos, function (key, registro) {
                    $("#selectPabellon").append('<option value=' + registro.pabN_IDPABELLON + '>' + registro.pabS_NOMBRE + '</option>');
                });
                cargarNicho($("#selectPabellon").val());
            } else {
                mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
            }
        },
        error: function (error) {
            mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
        }
    });
}

function cargarNicho(_idPabellon) {
    $.ajax({
        type: "POST",
        url: "Nicho/BuscarPorPabellon",
        data: { idPabellon: _idPabellon, valCantidad: true },
        dataType: 'json',
        async: false,
        success: function (data) {
            if (data.estado) {
                $("#selectNicho").empty();
                $.each(data.datos, function (key, registro) {
                    $("#selectNicho").append('<option value=' + registro.nicN_IDNICHO + '>' + registro.nicS_CODNICHO + '</option>');
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

function limpiarDatos() {
    $('input').val('');
    $('input[class="form-control"]').val('');
    $('input[class="form-control soloNumero"]').val('');
    $('input[class="form-check-input"]').prop("checked", false);
    $("#tablaAdicional").hide();
}

function limpiarDatosDetalle() {
    $('input[class="form-control detalle"]').val('');
    $('input[class="form-control detalle soloNumero"]').val('');
}

function getParameterByName(_param) {
    _param = _param.replace(/[\[]/, "\\[").replace(/[\]]/, "\\]");
    var regex = new RegExp("[\\?&]" + _param + "=([^&#]*)"),
        results = regex.exec(location.search);
    return results === null ? "" : decodeURIComponent(results[1].replace(/\+/g, " "));
}