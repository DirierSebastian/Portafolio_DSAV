using Portafolio_DSAV.Models;
using System.Data;
using System.Data.SqlClient;
namespace Portafolio_DSAV.Datos
{
    public class RepositorioDatos
    {

        public List<PerfilModel> Listar()
        {
            var oLista = new List<PerfilModel>();
            var cn = new conexion();
            using(var Conexion = new SqlConnection(cn.getRepositorioContext()))
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_Listar", Conexion);
                cmd.CommandType = CommandType.StoredProcedure;
                using(var dr  = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        oLista.Add(new PerfilModel()
                        {
                            ID = Convert.ToInt32(dr["ID"]),
                            nombre = dr["nombre"].ToString(),
                            edad = dr["edad"].ToString(),
                            lenguaje = dr["lenguaje"].ToString(),
                            Web = dr["Web"].ToString(),
                            Movil = dr["Movil"].ToString(),
                            BD = dr["BD"].ToString()
                        });
                    }
                }
            }
            return oLista;
        }
        public PerfilModel ObtenerPerfil(int ID)
        {
            var oPerfil = new PerfilModel();
            var cn = new conexion();
            using(var Conexion = new SqlConnection(cn.getRepositorioContext()))
            {
                Conexion.Open();
                SqlCommand cmd = new SqlCommand("Sp_Obtener", Conexion);
                cmd.Parameters.AddWithValue("ID", ID);
                cmd.CommandType = CommandType.StoredProcedure;
                using(var dr  = cmd.ExecuteReader())
                {
                    while(dr.Read())
                    {
                        oPerfil.ID = Convert.ToInt32(dr["ID"]);
                        oPerfil.nombre = dr["nombre"].ToString();
                        oPerfil.edad = dr["edad"].ToString();
                        oPerfil.lenguaje = dr["lenguaje"].ToString();
                    }
                }
            }
            return oPerfil;
        }
    }
}
