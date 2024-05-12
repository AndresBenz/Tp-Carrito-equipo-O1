using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Clases;
using Funcionalidades;

namespace Funcionalidades
{
    public class RepositorioMarca
    {
        public List<Marca> Listar() {
            List<Marca> listaMarca = new List<Marca>();
            Conexion_Comandos AccesoDatos = new Conexion_Comandos();
            try
			{
                AccesoDatos.setearConsulta("select Id, Descripcion from MARCAS");
                AccesoDatos.ejecutarLectura();
                while (AccesoDatos.Lector.Read())
                {
                    Marca aux = new Marca();
                    aux.Id = (int)AccesoDatos.Lector["Id"];
                    aux.Descripcion = (string)AccesoDatos.Lector["Descripcion"];
                    listaMarca.Add(aux);
                }



				return listaMarca;
			}
			catch (Exception ex)
			{

				throw ex;
			}
            finally { AccesoDatos.cerrarConexion(); }
            
        }

        public void Agregar(Marca nuevaMarca)
        {
            Conexion_Comandos Accesodatos = new Conexion_Comandos();
            try
            {

                Accesodatos.setearConsulta("insert into MARCAS(Descripcion) values (@descripcion)");

                Accesodatos.setearParametros("@Descripcion", nuevaMarca.Descripcion);

                Accesodatos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                Accesodatos.cerrarConexion();

            }
        }

        public void BajaFisica(Marca marca)
        {
            Conexion_Comandos datos = new Conexion_Comandos();

            try
            {
                datos.setearConsulta("delete from MARCAS where id = @id");
                datos.setearParametros("@id", marca.Id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
