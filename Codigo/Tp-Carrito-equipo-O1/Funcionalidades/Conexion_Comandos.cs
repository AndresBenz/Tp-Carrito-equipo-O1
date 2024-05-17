using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;


namespace Funcionalidades
{
    public class Conexion_Comandos
    {

        private SqlConnection conexion;
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector
        {
            get { return lector; }
        }

        public Conexion_Comandos()
        {
            //conexion = new SqlConnection("server= DESKTOP-A3HCDG7\\SQLEXPRESS; database=CATALOGO_P3_DB; Integrated Security = True");
            //conexion = new SqlConnection("server= FACUHP; database=CATALOGO_P3_DB; Integrated Security = True");
            //conexion = new SqlConnection("server= DESKTOP-DLD9B46; database=CATALOGO_P3_DB; Integrated Security = True");
           conexion = new SqlConnection("server= FACU; database=CATALOGO_P3_DB; Integrated Security = True");

            comando = new SqlCommand();
           
        }

        public void setearConsulta(string consulta)
        {
            comando.CommandType = System.Data.CommandType.Text;
            comando.CommandText = consulta;
        }

        public void ejecutarLectura()
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void cerrarConexion()
        {
            if (lector != null)
                lector.Close();
            conexion.Close();
        }
        public void setearParametros(string nombre, object valor)
        {

            comando.Parameters.AddWithValue(nombre, valor);
        }
        
        public void ejecutarAccion()
        {
            comando.Connection = conexion;
            try
            {

                conexion.Open();
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }












    }
}
