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
    public class RepositorioImagen
    {

        public void Agregar(Imagenes nuevaImagen)
        {
			Conexion_Comandos AccesoDatos = new Conexion_Comandos();
			
			try
			{
				AccesoDatos.setearConsulta("insert into IMAGENES(IdArticulo,ImagenUrl) values (@IdArticulo,@ImagenUrl)");
				AccesoDatos.setearParametros("@IdArticulo",nuevaImagen.idArticulo);
				AccesoDatos.setearParametros("@ImagenUrl",nuevaImagen.ImagenURL);
				AccesoDatos.ejecutarAccion();
			}
			catch (Exception ex)
			{

				throw ex;
			}
			finally
			{
				AccesoDatos.cerrarConexion();
			}

            }
        public void Modificar(Imagenes nuevaImagen)
        {
            Conexion_Comandos AccesoDatos = new Conexion_Comandos();

            try
            {
                AccesoDatos.setearConsulta("update IMAGENES set ImagenUrl = @ImagenUrl where IdArticulo = @IdArticulo");
                AccesoDatos.setearParametros("@IdArticulo", nuevaImagen.idArticulo);
                AccesoDatos.setearParametros("@ImagenUrl", nuevaImagen.ImagenURL);
                AccesoDatos.ejecutarAccion();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            {
                AccesoDatos.cerrarConexion();
            }
        }

        //Crear lista de imagenes para obtener varias ImagenURL
         public List<Imagenes> Listar()
        {
            List<Imagenes> listaCategoria = new List<Imagenes>();
            Conexion_Comandos AccesoDatos = new Conexion_Comandos();
            try
            {
                AccesoDatos.setearConsulta("select id , IdArticulo,ImagenUrl from IMAGENES");
                AccesoDatos.ejecutarLectura();
                while (AccesoDatos.Lector.Read())
                {
                    Imagenes aux = new Imagenes();
                    aux.id = (int)AccesoDatos.Lector["Id"];
                    aux.idArticulo = (int)AccesoDatos.Lector["IdArticulo"];
                    aux.ImagenURL= (string)AccesoDatos.Lector["ImagenUrl"];
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

        public List<Imagenes> ObtenerImg(int idarticulo )
        {
            List<Imagenes>  Listafiltrada = new List<Imagenes>();

             Conexion_Comandos AccesoDatos = new Conexion_Comandos();
            AccesoDatos.setearConsulta("select ImagenUrl from IMAGENES where IdArticulo = @id");
            AccesoDatos.setearParametros("@id", idarticulo);
            AccesoDatos.ejecutarLectura();

            while (AccesoDatos.Lector.Read() )
            {
               Imagenes aux= new Imagenes();
                if (AccesoDatos.Lector["ImagenURL"] is DBNull || AccesoDatos.Lector["IdImg"] is DBNull)
                {
                    aux.id= 0;
                    aux.ImagenURL= "https://img.freepik.com/psd-premium/error-renderizado-3d-404-x-incorrecto-acceso-denegado-aprobar-icono-rojo-aislamiento-fondo_747880-16.jpg";
                }
                else
                {

                    aux.id = (int)AccesoDatos.Lector["IdImg"];
                    aux.ImagenURL = (string)AccesoDatos.Lector["ImagenUrl"];
                }

            }

            return Listafiltrada;
          
        }


    }
}

