using CapaDatos;
using CapaEntidad;
using Microsoft.AspNetCore.Mvc;

namespace Simulacion2.Controllers
{
    public class TipoMedicamentoController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<TipoMedicamentoCLS> listarTipoMedicamento()
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.listarTipoMedicamento();
        }

        public List<TipoMedicamentoCLS> filtrarTipoMedicamento(string nombre)
        {
            TipoMedicamentoDAL obj = new TipoMedicamentoDAL();
            return obj.filtrarTipoMedicamento(nombre);
        }

    }
}
