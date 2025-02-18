
window.onload = function () {
    listarLaboratorio()
};

let objLaboratorio;

function filtrarLaboratiorio() {
    let nombre = get("txtFiltrarLaboratorio");
    if (nombre == "") {
        listarLaboratorio();
    } else {
        objLaboratorio.url = "Laboratorio/filtrarLaboratorio/?nombre=" + nombre;
        pintar(objLaboratorio, "divTablaLaboratorios")
    }
}


async function listarLaboratorio() {
    objLaboratorio = {
        url: "Laboratorio/listarLaboratorio",
        cabeceras: ["IdLaboraotio", "Nombre", "Direccion" , "Persona contaco"],
        propiedades: ["idLaboratorio", "nombreLaboratorio", "direccionLaboratorio", "personaContacto"]
    }

    pintar(objLaboratorio, "divTablaLaboratorios")
}


function buscar() {

    let nombreLaboratorio = get("txtFiltrarLaboratorio");//document.getElementById("txtFiltrarTipoMedicamento").value;

    objLaboratorio.url = "Laboratorio/filtrarLaboratorio/?nombre=" + nombreLaboratorio;
    pintar(objLaboratorio, "divTablaLaboratorios");


}

function limpiar() {
    listarLaboratorio();
    set("txtFiltrarLaboratorio", "");//document.getElementById("txtFiltrarTipoMedicamento").value = "";
}

