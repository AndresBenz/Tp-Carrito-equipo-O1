﻿using System;
using System.Collections;
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
    public class RepositorioArticulo
    {
        public List<Articulo> Listar()
        {
            List<Articulo> listaArticulo = new List<Articulo>();
            Conexion_Comandos AccesoDatos = new Conexion_Comandos();
            try
            {
                AccesoDatos.setearConsulta("select  a.Id, A.Codigo, A.Nombre,A.Descripcion,A.Precio,m.Id as IdMarca ,M.Descripcion AS DescripcionMarca, c.Id as Idcategoria,C.Descripcion AS DescripcionCate,i.Id as idimg,I.ImagenUrl from ARTICULOS A INNER join MARCAS M on M.Id = A.IdMarca INNER join CATEGORIAS C on C.Id = A.IdCategoria INNER join IMAGENES I on I.IdArticulo = A.Id");
                AccesoDatos.ejecutarLectura();

                while (AccesoDatos.Lector.Read())
                {
                    Articulo aux = new Articulo();



                    aux.id = (int)AccesoDatos.Lector["Id"];
                    aux.Codigo = (string)AccesoDatos.Lector["Codigo"];
                    aux.Nombre = (string)AccesoDatos.Lector["Nombre"];
                    aux.descripcion = (string)AccesoDatos.Lector["Descripcion"];
                    aux.Precio = (decimal)AccesoDatos.Lector["Precio"];


                    //Creamos un aux marca para poder cargar las columnas

                    aux.idMarca = new Marca();
                    aux.idMarca.Id = (int)AccesoDatos.Lector["IdMarca"];
                    aux.idMarca.Descripcion = (string)AccesoDatos.Lector["DescripcionMarca"];

                    //Creamos un aux categoria para poder cargar las columnas

                    aux.idCategoria = new Categoria();
                    if (AccesoDatos.Lector["DescripcionCate"] is DBNull && AccesoDatos.Lector["Idcategoria"] is DBNull)
                    {
                        aux.idCategoria.Descripcion = "Sin descripcion";
                        aux.idCategoria.Id = 0;
                    }
                    else
                    {

                        aux.idCategoria.Id = (int)AccesoDatos.Lector["Idcategoria"];
                        aux.idCategoria.Descripcion = (string)AccesoDatos.Lector["DescripcionCate"];
                    }


                    aux.IdImagenUrl = new Imagenes();
                    if (AccesoDatos.Lector["ImagenURL"] is DBNull || AccesoDatos.Lector["IdImg"] is DBNull)
                    {
                        aux.IdImagenUrl.id = 0;
                        aux.IdImagenUrl.ImagenURL = "https://img.freepik.com/psd-premium/error-renderizado-3d-404-x-incorrecto-acceso-denegado-aprobar-icono-rojo-aislamiento-fondo_747880-16.jpg";
                    }
                    else
                    {

                        aux.IdImagenUrl.id = (int)AccesoDatos.Lector["IdImg"];
                        aux.IdImagenUrl.ImagenURL = (string)AccesoDatos.Lector["ImagenUrl"];
                    }


                    listaArticulo.Add(aux);

                }


                AccesoDatos.cerrarConexion();
                return listaArticulo;


            }

            catch (Exception ex)
            {
                throw ex;

            }




        }

        public List<Articulo> ListarConSpImgIndividual ()
        {
            List<Articulo> lista = new List<Articulo>();
            Conexion_Comandos datos = new Conexion_Comandos();

            try
            {
                string consulta = "SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Id AS IdMarca, M.Descripcion AS DescripcionMarca, C.Id AS IdCategoria, C.Descripcion AS DescripcionCate, MIN(I.Id) AS IdImg, MIN(I.ImagenUrl) AS ImagenUrl FROM  ARTICULOS A  LEFT JOIN  MARCAS M ON M.Id = A.IdMarca LEFT JOIN  CATEGORIAS C ON C.Id = A.IdCategoria LEFT JOIN IMAGENES I ON I.IdArticulo = A.Id  WHERE  Precio > 0 GROUP BY    A.Id, A.Codigo, A.Nombre, A.Descripcion, A.Precio, M.Id, M.Descripcion, C.Id, C.Descripcion;";


                datos.setearConsulta(consulta);
                datos.ejecutarLectura();


                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.id = (int)datos.Lector["id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    // para poder cargar IdMarca
                    aux.idMarca = new Marca();
                    aux.idMarca.Id = (int)datos.Lector["IdMarca"];
                    aux.idMarca.Descripcion = (string)datos.Lector["DescripcionMarca"];
                    //Creamos un aux categoria para poder cargar las columnas
                    aux.idCategoria = new Categoria();
                    if (datos.Lector["DescripcionCate"] is DBNull && datos.Lector["Idcategoria"] is DBNull)
                    {
                        aux.idCategoria.Descripcion = "Sin descripcion";
                        aux.idCategoria.Id = 0;
                    }
                    else
                    {

                        aux.idCategoria.Id = (int)datos.Lector["Idcategoria"];
                        aux.idCategoria.Descripcion = (string)datos.Lector["DescripcionCate"];
                    }
                    // me aseguro que no sea nulo
                    aux.IdImagenUrl = new Imagenes();
                    if (datos.Lector["ImagenURL"] is DBNull || datos.Lector["IdImg"] is DBNull)
                    {
                        aux.IdImagenUrl.id = 0;
                        aux.IdImagenUrl.ImagenURL = "https://img.freepik.com/psd-premium/error-renderizado-3d-404-x-incorrecto-acceso-denegado-aprobar-icono-rojo-aislamiento-fondo_747880-16.jpg";
                    }
                    else
                    {

                        aux.IdImagenUrl.id = (int)datos.Lector["IdImg"];
                        aux.IdImagenUrl.ImagenURL = (string)datos.Lector["ImagenUrl"];
                    }
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public List<Articulo> ListarConSp()
        {
            List<Articulo> lista = new List<Articulo>();
            Conexion_Comandos datos = new Conexion_Comandos();

            try
            {
                string consulta = "select  a.Id, A.Codigo, A.Nombre,A.Descripcion,A.Precio,m.Id as IdMarca ,M.Descripcion AS DescripcionMarca, c.Id as Idcategoria,C.Descripcion AS DescripcionCate,i.Id as idimg,I.ImagenUrl from ARTICULOS A left join MARCAS M on M.Id = A.IdMarca left join CATEGORIAS C on C.Id = A.IdCategoria left join IMAGENES I on I.IdArticulo = A.Id where Precio > 0 ";


                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                

                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    
                    aux.id = (int)datos.Lector["id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];
                    // para poder cargar IdMarca
                    aux.idMarca = new Marca();
                    aux.idMarca.Id = (int)datos.Lector["IdMarca"];
                    aux.idMarca.Descripcion = (string)datos.Lector["DescripcionMarca"];
                    //Creamos un aux categoria para poder cargar las columnas
                    aux.idCategoria = new Categoria();
                    if (datos.Lector["DescripcionCate"] is DBNull && datos.Lector["Idcategoria"] is DBNull)
                    {
                        aux.idCategoria.Descripcion = "Sin descripcion";
                        aux.idCategoria.Id = 0;
                    }
                    else
                    {

                        aux.idCategoria.Id = (int)datos.Lector["Idcategoria"];
                        aux.idCategoria.Descripcion = (string)datos.Lector["DescripcionCate"];
                    }
                    // me aseguro que no sea nulo
                    aux.IdImagenUrl = new Imagenes();
                    if (datos.Lector["ImagenURL"] is DBNull || datos.Lector["IdImg"] is DBNull)
                    {
                        aux.IdImagenUrl.id = 0;
                        aux.IdImagenUrl.ImagenURL = "https://img.freepik.com/psd-premium/error-renderizado-3d-404-x-incorrecto-acceso-denegado-aprobar-icono-rojo-aislamiento-fondo_747880-16.jpg";
                    }
                    else
                    {

                        aux.IdImagenUrl.id = (int)datos.Lector["IdImg"];
                        aux.IdImagenUrl.ImagenURL = (string)datos.Lector["ImagenUrl"];
                    }
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Agregar(Articulo nuevoarticulo)
        {
            Conexion_Comandos Accesodatos = new Conexion_Comandos();
            try
            {

                Accesodatos.setearConsulta("Insert into ARTICULOS(Codigo,Nombre,Descripcion,IdMarca,IdCategoria,Precio) values (@Codigo,@Nombre,@Descripcion,@IdMarca,@IdCategoria,@Precio)");
                Accesodatos.setearParametros("@Codigo", nuevoarticulo.Codigo);
                Accesodatos.setearParametros("@Nombre", nuevoarticulo.Nombre);
                Accesodatos.setearParametros("@Descripcion", nuevoarticulo.descripcion);
                Accesodatos.setearParametros("@IdMarca", nuevoarticulo.idMarca.Id);
                Accesodatos.setearParametros("@IdCategoria", nuevoarticulo.idCategoria.Id);
                Accesodatos.setearParametros("@Precio", nuevoarticulo.Precio);
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
        public void Modificar(Articulo nuevoarticulo)
        {
            Conexion_Comandos Accesodatos = new Conexion_Comandos();
            try
            {

                Accesodatos.setearConsulta("Update ARTICULOS set Codigo = @Codigo,Nombre=@Nombre,Descripcion=@Descripcion,IdMarca=@IdMarca,IdCategoria=@IdCategoria,Precio=@Precio where Id = @Id");
                Accesodatos.setearParametros("@Id", nuevoarticulo.id);
                Accesodatos.setearParametros("@Codigo", nuevoarticulo.Codigo);
                Accesodatos.setearParametros("@Nombre", nuevoarticulo.Nombre);
                Accesodatos.setearParametros("@Descripcion", nuevoarticulo.descripcion);
                Accesodatos.setearParametros("@IdMarca", nuevoarticulo.idMarca.Id);
                Accesodatos.setearParametros("@IdCategoria", nuevoarticulo.idCategoria.Id);
                Accesodatos.setearParametros("@Precio", nuevoarticulo.Precio);
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
        public void BajaLogica(Articulo nuevoarticulo)
        {
            Conexion_Comandos Accesodatos = new Conexion_Comandos();
            try
            {

                Accesodatos.setearConsulta("Update ARTICULOS set Precio= -1 where Id = @Id");
                Accesodatos.setearParametros("@Id", nuevoarticulo.id);
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

        public List<Articulo> FiltrarArticulos(string campo, string criterio, string filtro)
        {
            List<Articulo> lista = new List<Articulo>();
            Conexion_Comandos datos = new Conexion_Comandos();

            try
            {
                string consulta = "select  a.Id, A.Codigo, A.Nombre,A.Descripcion,A.Precio,m.Id as IdMarca ,M.Descripcion AS DescripcionMarca, c.Id as Idcategoria,C.Descripcion AS DescripcionCate,i.Id as idimg,I.ImagenUrl from ARTICULOS A left join MARCAS M on M.Id = A.IdMarca left join CATEGORIAS C on C.Id = A.IdCategoria left join IMAGENES I on I.IdArticulo = A.Id where Precio > 0 and ";
                if (campo == "Precio.")
                {
                    switch (criterio)
                    {
                        case "Mayor a..":
                            consulta += "Precio > @Precio";
                            break;
                        case "Menor a..":
                            consulta += "Precio < @Precio";
                            break;
                        default:
                            consulta += "Precio = @Precio";
                            break;
                    }
                    datos.setearParametros("@Precio", Convert.ToDecimal(filtro));
                }
                else if (campo == "Nombre.")
                {
                    switch (criterio)
                    {
                        case "comienza con..":
                            consulta += "Nombre like @Filtro + '%'";
                            break;
                        case "Termina con..":
                            consulta += "Nombre like '%' + @Filtro";
                            break;
                        default:
                            consulta += "Nombre like '%' + @Filtro + '%'";
                            break;
                    }
                    datos.setearParametros("@Filtro", filtro);
                }

                datos.setearConsulta(consulta);
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();

                    aux.id = (int)datos.Lector["id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.descripcion = (string)datos.Lector["Descripcion"];

                    // para poder cargar IdMarca

                    aux.idMarca = new Marca();
                    aux.idMarca.Id = (int)datos.Lector["IdMarca"];
                    aux.idMarca.Descripcion = (string)datos.Lector["DescripcionMarca"];

                    //Creamos un aux categoria para poder cargar las columnas

                    aux.idCategoria = new Categoria();
                    if (datos.Lector["DescripcionCate"] is DBNull && datos.Lector["Idcategoria"] is DBNull)
                    {
                        aux.idCategoria.Descripcion = "Sin descripcion";
                        aux.idCategoria.Id = 0;
                    }
                    else
                    {

                        aux.idCategoria.Id = (int)datos.Lector["Idcategoria"];
                        aux.idCategoria.Descripcion = (string)datos.Lector["DescripcionCate"];
                    }


                    // me aseguro que no sea nulo
                    aux.IdImagenUrl = new Imagenes();
                    if (datos.Lector["ImagenURL"] is DBNull && datos.Lector["IdImg"] is DBNull)
                    {
                        aux.IdImagenUrl.id = 0;
                        aux.IdImagenUrl.ImagenURL = "";
                    }
                    else
                    {

                        aux.IdImagenUrl.id = (int)datos.Lector["IdImg"];
                        aux.IdImagenUrl.ImagenURL = (string)datos.Lector["ImagenUrl"];
                    }



                    aux.Precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void BajaFisica(Articulo bajaFisica)
        {
            Conexion_Comandos datos = new Conexion_Comandos();

            try
            {
                datos.setearConsulta("delete from articulos where id = @id");
                datos.setearParametros("@id", bajaFisica.id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Articulo BuscarID(int id)
        {
            
            Conexion_Comandos AccesoDatos = new Conexion_Comandos();
            try
            {
                //No encuentra el id 2 en la base de datos. Arreglar.
                AccesoDatos.setearConsulta("select  a.Id, A.Codigo, A.Nombre,A.Descripcion,A.Precio,m.Id as IdMarca ,M.Descripcion AS DescripcionMarca, c.Id as Idcategoria,C.Descripcion AS DescripcionCate,i.Id as idimg,I.ImagenUrl from ARTICULOS A INNER join MARCAS M on M.Id = A.IdMarca INNER join CATEGORIAS C on C.Id = A.IdCategoria INNER join IMAGENES I on I.IdArticulo = A.Id where IdArticulo = @id");
                AccesoDatos.setearParametros("@id",id);
                AccesoDatos.ejecutarLectura();
                Articulo aux = new Articulo();
                while (AccesoDatos.Lector.Read())
                {
                    aux.id = (int)AccesoDatos.Lector["Id"];
                    aux.Codigo = (string)AccesoDatos.Lector["Codigo"];
                    aux.Nombre = (string)AccesoDatos.Lector["Nombre"];
                    aux.descripcion = (string)AccesoDatos.Lector["Descripcion"];
                    aux.Precio = (decimal)AccesoDatos.Lector["Precio"];


                    //Creamos un aux marca para poder cargar las columnas

                    aux.idMarca = new Marca();
                    aux.idMarca.Id = (int)AccesoDatos.Lector["IdMarca"];
                    aux.idMarca.Descripcion = (string)AccesoDatos.Lector["DescripcionMarca"];

                    //Creamos un aux categoria para poder cargar las columnas

                    aux.idCategoria = new Categoria();
                    if (AccesoDatos.Lector["DescripcionCate"] is DBNull && AccesoDatos.Lector["Idcategoria"] is DBNull)
                    {
                        aux.idCategoria.Descripcion = "Sin descripcion";
                        aux.idCategoria.Id = 0;
                    }
                    else
                    {

                        aux.idCategoria.Id = (int)AccesoDatos.Lector["Idcategoria"];
                        aux.idCategoria.Descripcion = (string)AccesoDatos.Lector["DescripcionCate"];
                    }


                    aux.IdImagenUrl = new Imagenes();
                    if (AccesoDatos.Lector["ImagenURL"] is DBNull || AccesoDatos.Lector["IdImg"] is DBNull)
                    {
                        aux.IdImagenUrl.id = 0;
                        aux.IdImagenUrl.ImagenURL = "https://img.freepik.com/psd-premium/error-renderizado-3d-404-x-incorrecto-acceso-denegado-aprobar-icono-rojo-aislamiento-fondo_747880-16.jpg";
                    }
                    else
                    {

                        aux.IdImagenUrl.id = (int)AccesoDatos.Lector["IdImg"];
                        aux.IdImagenUrl.ImagenURL = (string)AccesoDatos.Lector["ImagenUrl"];
                    }

                    
                }


                AccesoDatos.cerrarConexion();
                return aux;
            }

            catch (Exception ex)
            {
                throw ex;

            }




        }

        public int ValidarDuplicado(int id)
        {
            Conexion_Comandos AccesoDatos = new Conexion_Comandos();
            try
            {
                AccesoDatos.setearConsulta("select COUNT(a.id) as Cont from ARTICULOS A  left join IMAGENES I  on I.IdArticulo = A.Id  where a.id = @id");
                AccesoDatos.setearParametros("@id",id);
                AccesoDatos.ejecutarLectura();
                int cont=0;
                while (AccesoDatos.Lector.Read())
                {

                    cont = (int)AccesoDatos.Lector["Cont"];
                }
                return cont;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }


}
