using CapaDatos;
using CapaEntidad;
using Microsoft.AspNetCore.Mvc;

namespace Simulacion2.Controllers
{
    public class LaboratorioController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


        public List<LaboratorioCLS> listarLaboratorio()
        {
            LaboratorioDAL obj = new LaboratorioDAL();
            return obj.listarLaboratorio();
        }

        public List<LaboratorioCLS> filtrarLaboratorio(string nombre)
        {
            LaboratorioDAL obj = new LaboratorioDAL();
            return obj.filtrarLaboratorio(nombre);
        }



    }
}
