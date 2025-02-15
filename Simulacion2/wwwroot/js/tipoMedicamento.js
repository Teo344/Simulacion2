window.onload = function () {
    listarTipoMedicamento()
};

let objTipoMedicamento;



async function listarTipoMedicamento() {
    objTipoMedicamento = {
        url: "TipoMedicamento/listarTipoMedicamento",
        cabeceras: ["IdTipoMedicamento", "Nombre", "Descripcion"],
        propiedades: ["idTipoMedicamento", "nombre", "descripcion"]
    }

    pintar(objTipoMedicamento , "divTabla")
}

function buscar() {

    let nombreTipoMedicamento = document.getElementById("txtFiltrarTipoMedicamento").value;

    objTipoMedicamento.url = "TipoMedicamento/filtrarTipoMedicamento/?nombre=" + nombreTipoMedicamento;
    pintar(objTipoMedicamento,"divTabla")


}

function limpiar() {
    listarTipoMedicamento();
    document.getElementById("txtFiltrarTipoMedicamento").value = "";
}

