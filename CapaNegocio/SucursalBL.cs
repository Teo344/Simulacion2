using CapaDatos;
using CapaEntidad; // Si usas clases de la capa de entidades

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class SucursalBL
    {
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
