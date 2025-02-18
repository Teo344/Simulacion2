function get(idControl) {
    return document.getElementById(idControl).value;
}

function set(idControl, valor) {
    document.getElementById(idControl).value = valor;
}

async function fetchget(url, tiporespuesta, callback) {
    try {

        let raiz = document.getElementById("hdfoculto").value;

        //http://local host....

        let urlCompleta = window.location.protocol + "//" + window.location.host + "/" + url;
        console.log(urlCompleta);

        let res = await fetch(urlCompleta);

        if (tiporespuesta == "json")
            res = await res.json();
        else if (tiporespuesta == "text")
            res = await res.text();

        //JSON objeto
        callback(res);

    } catch (e) {
        console.error("Error en fetchget:", e);
        alert("Ocurrió un problema");
    }

}



function pintar(objConfiguracion, tabla) {
    fetchget(objConfiguracion.url, "json", function (res) {
        let contenido = "";


        contenido += "<div id='divContenedor'>";
        contenido += generarTabla(res, objConfiguracion);

        contenido += "</div>";

        document.getElementById(tabla).innerHTML = contenido;

    })
}




function generarTabla(res, objConfiguracion) {
    let contenido = "";
    let objConfiguracionGlobal = objConfiguracion;

    let cabeceras = objConfiguracionGlobal.cabeceras; //obtengo las cabeceras de la tabla
    let nombrepropiedades = objConfiguracionGlobal.propiedades; //obtengo las propiedades


    contenido += "<table class='table'>";
    contenido += "<thead>";

    contenido += "<tr>";


    for (let i = 0; i < cabeceras.length; i++) {
        contenido += "<td>" + cabeceras[i] + "</td>";
    }

    //contenido += "<td>ID tipo medicamento</td>";
    // contenido += "<td>Nombre</td>";
    // contenido += "<td>Descripcion</td>";



    contenido += "</tr>";

    contenido += "</thead>";

    let nroRegistros = res.length;
    let obj;
    let propiedadActual;

    contenido += "<tbody>";

    for (let i = 0; i < nroRegistros; i++) {
        obj = res[i];
        contenido += "<tr>";

        for (let j = 0; j < nombrepropiedades.length; j++) {
            propiedadActual = nombrepropiedades[j];
                contenido += "<td>" + obj[propiedadActual] + "</td>";
            

        }

        //contenido += "<td>" + obj.idTipoMedicamento + "</td>";
        //contenido += "<td>" + obj.nombre + "</td>";
        //contenido += "<td>" + obj.descripcion + "</td>";



        contenido += "</tr>";
    }

    contenido += "</tbody>";
    contenido += "</table>";
    return contenido;
}