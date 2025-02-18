using CapaDatos;
using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaNegocio
{
    public class LaboratorioBL
    {
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
