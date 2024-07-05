// For an introduction to the Blank template, see the following documentation:
// http://go.microsoft.com/fwlink/?LinkID=397704
// To debug code on page load in cordova-simulate or on Android devices/emulators: launch your app, set breakpoints,
// and then run "window.location.reload()" in the JavaScript Console.
(function () {
    "use strict";

    document.addEventListener("deviceready", onDeviceReady.bind(this), false);

    function onDeviceReady() {
        // Handle the Cordova pause and resume events
        document.addEventListener("pause", onPause.bind(this), false);
        document.addEventListener("resume", onResume.bind(this), false);

        // TODO: Cordova has been loaded. Perform any initialization that requires Cordova here.
        document.getElementById("btnBuscar").addEventListener("click", BuscarUsuario, false);
        document.getElementById("btncargar").addEventListener("click", CargarLista, false);
    }

    function onPause() {
        // TODO: This application has been suspended. Save application state here.
    }

    function onResume() {
        // TODO: This application has been reactivated. Restore application state here.
    }
    function BuscarUsuario() {
        var usuario = document.getElementById("txtNombre").value;
        if (usuario == "") {
            document.getElementById("divResultado").innerHTML + "Ingrese usuario";
        } else {
            // Agregando evento Ajax
            $.ajax({
                type: "GET",
                url: "http://localhost/webapp/getdata.aspx?usuario=" + usuario,
                crossDomain: true,
                cache: false,
                success: function (result) {
                    document.getElementById("divResultado").innerHTML = "Bienvenido: " + result[0].fullname;
                },
                error: function (result) {
                    alert("Ocurrio un problema Porfavor comuniquese con el administrador del sistema")
                }
            })
        }
    }

    function CargarLista() {
        var cadena = "<table border=0 cellpadding=2 cellspacing=0><tr><th>Nombre</th><th>Direccion</th><th>Telefono</th></tr>";
        //agregando evento Ajax
        $.ajax({
            type: "GET",
            url: "http://localhost/webapp/getLista.aspx",
            crossDomain: true,
            cache: false,
            contentType: "application/json; charset=utf-8",
            async: false,
            dataType: "json",
            success: function (result) {
                $.each(result, function (i, field) {
                    cadena = cadena + "<tr>" + "<td>" + field.Nombre + "</td><td>" + field.Direccion + "</td><td>" + field.Telefono;
                });
                cadena = cadena + "</table>";
                $("#divLista").append(cadena);
            },
            error: function (result) {
                alert("Ocurrió un problema. Por favor Comuníquese con el administrador del sistema. Gracias.");
            }
        });
    }
})();