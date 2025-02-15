
window.onload = function () {
    listarSucursal()
};

let objSucursal;



async function listarSucursal() {
    objSucursal = {
        url: "Sucursal/listarSucursal",
        cabeceras: ["IdSucursal", "Nombre", "Direccion"],
        propiedades: ["idSucursal", "nombre", "direccion"]
    }

    pintar(objSucursal, "divTabla2")
}

function buscar() {

    let nombreTipoMedicamento = document.getElementById("txtFiltrarTipoMedicamento").value;

    objSucursal.url = "Sucursal/filtrarSucursal/?nombre=" + nombreTipoMedicamento;
    pintar(objSucursal, "divTabla2")


}

function limpiar() {
    listarSucursal();
    document.getElementById("txtFiltrarTipoMedicamento").value = "";
}

