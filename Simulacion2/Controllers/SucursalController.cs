using CapaDatos;
using CapaEntidad;
using Microsoft.AspNetCore.Mvc;

namespace Simulacion2.Controllers
{
    public class SucursalController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public List<SucursalCLS> listarSucursal()
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.listarSucursal();
        }

        public List<SucursalCLS> filtrarSucursal(string nombre)
        {
            SucursalDAL obj = new SucursalDAL();
            return obj.filtrarSucursal(nombre);
        }

    }
}
