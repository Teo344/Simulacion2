using CapaEntidad;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos
{
    public class LaboratorioDAL: ConexionSQL
    {

        public List<LaboratorioCLS> listarLaboratorio()
        {
            List<LaboratorioCLS> lista = null;
            string cadenaDato = Conexion();
            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspListarLaboratorio", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr != null)
                        {
                            LaboratorioCLS olaboratorioCLS;
                            lista = new List<LaboratorioCLS>();
                            while (dr.Read())
                            {
                                olaboratorioCLS = new LaboratorioCLS();
                                olaboratorioCLS.idLaboratorio= dr.GetInt32(0);
                                olaboratorioCLS.nombreLaboratorio = dr.GetString(1);
                                olaboratorioCLS.direccionLaboratorio = dr.GetString(2);
                                olaboratorioCLS.personaContacto = dr.GetString(3);
                                lista.Add(olaboratorioCLS);

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

        public List<LaboratorioCLS> filtrarLaboratorio(string nombre)
        {
            List<LaboratorioCLS> lista = null;

            string cadenaDato = Conexion();


            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarLaboratorio", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombre", nombre == null ? "" : nombre);
                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr != null)
                        {
                            LaboratorioCLS oLaboratorioCLS;
                            lista = new List<LaboratorioCLS>();
                            while (dr.Read())
                            {
                                oLaboratorioCLS = new LaboratorioCLS();
                                oLaboratorioCLS.idLaboratorio = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);

                                oLaboratorioCLS.nombreLaboratorio = dr.IsDBNull(1) ? " " : dr.GetString(1);
                                oLaboratorioCLS.direccionLaboratorio = dr.IsDBNull(1) ? " " : dr.GetString(2);
                                oLaboratorioCLS.personaContacto = dr.IsDBNull(1) ? " " : dr.GetString(4);

                                lista.Add(oLaboratorioCLS);

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
