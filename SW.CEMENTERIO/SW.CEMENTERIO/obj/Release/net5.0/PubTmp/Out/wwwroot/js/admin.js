if (getParameterByName('EXIT') === "1") sessionStorage.clear(); 

$("#btnLogin").click(function () {
    Login();
});

function Login() {
    var Usuario = $("#inputEmail").val();
    var Clave = $("#inputPassword").val();
    var oUsuario = {
        LOGS_USUARIO: Usuario,
        LOGS_CLAVE: Clave
    };
    $.ajax({
        type: "POST",
        url: "../Admin/AutenticarLogin",
        data: oUsuario,
        dataType: "json",
        success: function (data) {
            if (data.estado) {
                sessionStorage.setItem("nombreUsuario", data.adicionalTxt);
                window.location.href = "../Dashboard";
            } else {
                mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
                return false;
            }
        },
        error: function (error) {
            mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
        }
    });
}

$("#btnEnviar").click(function () {
    EnviarPwd();
});

function EnviarPwd() {
    var Usuario = $("#inputEmailRecuperacion").val();
    $.ajax({
        type: "POST",
        url: "../Colaborador/EnvioClave",
        data: { idColaborador: Usuario, asunto: "Recuperación de Contraseña", isReset: true },
        dataType: 'json',
        success: function (data) {
            mostrarMensaje(data.titulo, data.mensaje, data.tipo, true);
        },
        error: function (error) {
            mostrarMensaje("Error", "Codigo: " + error.status + " - " + error.responseText, 2, true);
        }
    });
}