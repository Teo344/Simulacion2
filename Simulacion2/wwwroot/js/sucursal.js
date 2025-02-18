
window.onload = function () {
    listarSucursal()
};

let objSucursal;

function filtrarSucursal() {
    let nombre = get("txtFiltrarTipoMedicamento");
    if (nombre == "") {
        listarSucursal();
    } else {
        objSucursal.url = "Sucursal/filtrarSucursal/?nombre=" + nombre;
        pintar(objSucursal, "divTabla2")
    }
}


async function listarSucursal() {
    objSucursal = {
        url: "Sucursal/listarSucursal",
        cabeceras: ["IdSucursal", "Nombre", "Direccion"],
        propiedades: ["idSucursal", "nombre", "direccion"]
    }

    pintar(objSucursal, "divTabla2")
}

function buscar() {

    let nombreTipoMedicamento = get("txtFiltrarTipoMedicamento");//document.getElementById("txtFiltrarTipoMedicamento").value;

    objSucursal.url = "Sucursal/filtrarSucursal/?nombre=" + nombreTipoMedicamento;
    pintar(objSucursal, "divTabla2");


}

function limpiar() {
    listarSucursal();
    set("txtFiltrarTipoMedicamento", "");//document.getElementById("txtFiltrarTipoMedicamento").value = "";
}

