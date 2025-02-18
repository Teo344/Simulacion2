window.onload = function () {
    listarTipoMedicamento()
};

let objTipoMedicamento;
function filtrarTipoMedicamento() {
    let nombre = get("txtFiltrarTipoMedicamento");
    if (nombre == "") {
        listarTipoMedicamento();
    } else {
        objTipoMedicamento.url = "TipoMedicamento/filtrarTipoMedicamento/?nombre=" + nombre;
        pintar(objTipoMedicamento, "divTabla")
    }
}





async function listarTipoMedicamento() {
    objTipoMedicamento = {
        url: "TipoMedicamento/listarTipoMedicamento",
        cabeceras: ["IdTipoMedicamento", "Nombre", "Descripcion"],
        propiedades: ["idTipoMedicamento", "nombre", "descripcion"]
    }

    pintar(objTipoMedicamento , "divTabla")
}

function buscar() {

    let nombreTipoMedicamento = get("txtFiltrarTipoMedicamento"); // document.getElementById("txtFiltrarTipoMedicamento").value;

    objTipoMedicamento.url = "TipoMedicamento/filtrarTipoMedicamento/?nombre=" + nombreTipoMedicamento;
    pintar(objTipoMedicamento,"divTabla")


}

function limpiar() {
    listarTipoMedicamento();
    set("txtFiltrarTipoMedicamento" , "")
}