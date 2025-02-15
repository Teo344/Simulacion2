using CapaEntidad;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace CapaDatos
{
    public class TipoMedicamentoDAL : ConexionSQL
    {
        public List<TipoMedicamentoCLS> filtrarTipoMedicamento(string nombre)
        {
            List<TipoMedicamentoCLS> lista = null;

            string cadenaDato = Conexion();


            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("uspFiltrarTipoMedicamento", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.StoredProcedure;
                        cmd.Parameters.AddWithValue("@nombretipomedicamento", nombre == null ? "" : nombre);
                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr != null)
                        {
                            TipoMedicamentoCLS otipoMedicamentoCLS;
                            lista = new List<TipoMedicamentoCLS>();
                            while (dr.Read())
                            {
                                otipoMedicamentoCLS = new TipoMedicamentoCLS();
                                otipoMedicamentoCLS.idTipoMedicamento = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                otipoMedicamentoCLS.nombre = dr.IsDBNull(1) ? " " : dr.GetString(1);
                                otipoMedicamentoCLS.descripcion = dr.IsDBNull(2) ? " " : dr.GetString(2);

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





        public List<TipoMedicamentoCLS> listarTipoMedicamento()
        {
            List<TipoMedicamentoCLS> lista = null;

            string cadenaDato = Conexion();


            using (SqlConnection cn = new SqlConnection(cadenaDato))
            {
                try
                {
                    cn.Open();
                    using (SqlCommand cmd = new SqlCommand("SELECT IIDTIPOMEDICAMENTO, NOMBRE , DESCRIPCION FROM TipoMedicamento WHERE BHABILITADO=1", cn))
                    {
                        cmd.CommandType = System.Data.CommandType.Text;

                        SqlDataReader dr = cmd.ExecuteReader();


                        if (dr != null)
                        {
                            TipoMedicamentoCLS otipoMedicamentoCLS;
                            lista = new List<TipoMedicamentoCLS>();
                            while (dr.Read())
                            {
                                otipoMedicamentoCLS = new TipoMedicamentoCLS();
                                otipoMedicamentoCLS.idTipoMedicamento = dr.IsDBNull(0) ? 0 : dr.GetInt32(0);
                                otipoMedicamentoCLS.nombre = dr.IsDBNull(1) ? " " : dr.GetString(1);
                                otipoMedicamentoCLS.descripcion = dr.IsDBNull(2) ? " " : dr.GetString(2);

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
