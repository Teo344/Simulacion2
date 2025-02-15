using CapaEntidad;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class SucursalDAL:ConexionSQL

    {


 

        public List<SucursalCLS> listarSucursal()
        {
            List<SucursalCLS> lista = null;
            string cadenaDato = Conexion();
            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarSucursal", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr != null)
                        {
                            SucursalCLS osucursalCLS;
                            lista = new List<SucursalCLS>();
                            while (dr.Read())
                            {
                                osucursalCLS = new SucursalCLS();
                                osucursalCLS.idSucursal = dr.GetInt32(0);
                                osucursalCLS.nombre = dr.GetString(1);
                                osucursalCLS.direccion = dr.GetString(2);

                                lista.Add(osucursalCLS);

                            }

                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                    lista = null;
                    throw;

                }
            }
            return lista;
        }

        public List<SucursalCLS> filtrarSucursal(string nombre)
        {
            List<SucursalCLS> lista = null;

            string cadenaDato = Conexion();


            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarSucursal", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombresucursal", nombre == null ? "" : nombre);
                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr != null)
                        {
                            SucursalCLS otipoMedicamentoCLS;
                            lista = new List<SucursalCLS>();
                            while (dr.Read())
                            {
                                otipoMedicamentoCLS = new SucursalCLS();
                                otipoMedicamentoCLS.idSucursal = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                otipoMedicamentoCLS.nombre = dr.IsDBNull(1) ? " " : dr.GetString(1);
                                otipoMedicamentoCLS.direccion = dr.IsDBNull(2) ? " " : dr.GetString(2);

                                lista.Add(otipoMedicamentoCLS);

                            }

                        }
                    }
                }
                catch (Exception)
                {
                    cn.Close();
                    lista = null;
                    throw;

                }
            }
            return lista;
        }








    }
}
