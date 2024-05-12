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
    public class RepositorioCategoria
    {
        public List<Categoria> Listar()
        {
            List<Categoria> listaCategoria = new List<Categoria>();
            Conexion_Comandos AccesoDatos = new Conexion_Comandos();
            try
            {
                AccesoDatos.setearConsulta("select Id, Descripcion from CATEGORIAS");
                AccesoDatos.ejecutarLectura();
                while (AccesoDatos.Lector.Read())
                {
                    Categoria aux = new Categoria();
                    aux.Id = (int)AccesoDatos.Lector["Id"];
                    aux.Descripcion = (string)AccesoDatos.Lector["Descripcion"];
                    listaCategoria.Add(aux);
                }



                return listaCategoria;
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally { AccesoDatos.cerrarConexion(); }

        }

        public void Agregar(Categoria nuevaCat)
        {
            Conexion_Comandos Accesodatos = new Conexion_Comandos();
            try
            {

                Accesodatos.setearConsulta("insert into CATEGORIAS(Descripcion) values (@descripcion)");
               
                Accesodatos.setearParametros("@Descripcion", nuevaCat.Descripcion);
              
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

        public void BajaFisica(Categoria cate)
        {
            Conexion_Comandos datos = new Conexion_Comandos();

            try
            {
                datos.setearConsulta("delete from Categorias where id = @id");
                datos.setearParametros("@id", cate.Id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

