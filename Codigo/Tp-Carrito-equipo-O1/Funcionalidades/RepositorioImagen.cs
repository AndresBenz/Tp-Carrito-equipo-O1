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
    }
}

