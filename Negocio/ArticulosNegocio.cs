using System;
using System.Collections.Generic;
using System.Text;
using Dominio;
using AccesoDatos;
using System.IO;
using System.Configuration;

namespace Negocio
{
    public class ArticulosNegocio
    {
        // declarar DataAccessObject

        public ArticulosNegocio()
        {
            // inicializar DAO
        }

        public List<Articulo> ListarArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            Database datos = new Database();

            try
            {
                datos.SetQuery("select a.Id, Codigo, Nombre, a.Descripcion as Descripcion,m.Id as IdMarca, m.Descripcion as Marca, c.Id as IdCategoria , c.Descripcion as Categoria, Precio from ARTICULOS a\r\nleft join MARCAS m on a.IdMarca = m.Id\r\nleft join CATEGORIAS c on a.IdCategoria = c.Id\r\n");
                datos.ReadData();

                while (datos.Reader.Read())
                {
                    Articulo art = new Articulo();

                    art.Id = (int)datos.Reader["Id"];
                    art.Nombre = (string)datos.Reader["Nombre"];
                    art.Codigo = (string)datos.Reader["Codigo"];
                    art.Descripcion = (string)datos.Reader["Descripcion"];
                    art.Precio = (float)(decimal)datos.Reader["Precio"];
                    art.Marca = new Marca();
                    art.Marca.Nombre = !(datos.Reader["Marca"] is DBNull) ? (string)datos.Reader["Marca"] : "";
                    art.Marca.Id = !(datos.Reader["IdMarca"] is DBNull) ? (int)datos.Reader["IdMarca"] : -1;
                    art.Categoria = new Categoria();
                    art.Categoria.Nombre = !(datos.Reader["Categoria"] is DBNull) ? (string)datos.Reader["Categoria"] : "";
                    art.Categoria.Id = !(datos.Reader["IdCategoria"] is DBNull) ? (int)datos.Reader["IdCategoria"] : -1;
                    art.Imagenes = new List<string>();
                    Database datosImagenes = new Database();
                    try
                    {
                        datosImagenes.SetQuery("select ImagenUrl from IMAGENES where IdArticulo = " + art.Id);
                        datosImagenes.ReadData();
                        while (datosImagenes.Reader.Read())
                        {
                            art.Imagenes.Add((string)datosImagenes.Reader["ImagenUrl"]);
                        }
                    }
                    catch (Exception)
                    {

                        throw new Exception("Error al leer las imagenes");
                    }
                    finally
                    {
                        datosImagenes.CloseConnection();
                    }
                    lista.Add(art);
                }
                return lista;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CloseConnection();
            }

        }

        public void Agregar(Articulo articulo)
        {
            Database dataAccess = new Database();
            try
            {
                dataAccess.SetQuery("insert into ARTICULOS (Codigo, Nombre, Descripcion, Precio) values (@Codigo, @Nombre, @Descripcion, @Precio) SELECT CAST(scope_identity() AS int);");
                dataAccess.SetParameter("@Codigo", articulo.Codigo);
                dataAccess.SetParameter("@Nombre", articulo.Nombre);
                dataAccess.SetParameter("@Descripcion", articulo.Descripcion);
                dataAccess.SetParameter("@Precio", articulo.Precio);
                articulo.Id = dataAccess.ExecuteScalar();
                dataAccess.SetParameter("@IdArticulo", articulo.Id);

                ActualizarMarcaCategoria(articulo, dataAccess);
                InsertarImagenes(articulo.Imagenes, dataAccess);
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                dataAccess.CloseConnection();
            }
        }

        public void Modificar(Articulo articulo)
        {
            // modificar articulo en BDD
            Database dataAccess = new Database();
            try
            {
                dataAccess.SetQuery("update ARTICULOS set Codigo = @Codigo, Nombre = @Nombre, Descripcion = @Descripcion, Precio = @Precio where Id = @IdArticulo");
                dataAccess.SetParameter("@Codigo", articulo.Codigo);
                dataAccess.SetParameter("@Nombre", articulo.Nombre);
                dataAccess.SetParameter("@Descripcion", articulo.Descripcion);
                dataAccess.SetParameter("@Precio", articulo.Precio);
                dataAccess.SetParameter("@IdArticulo", articulo.Id);
                dataAccess.ExecuteNonQuery();

                ActualizarMarcaCategoria(articulo, dataAccess);

                dataAccess.SetQuery("delete from IMAGENES where IdArticulo = @IdArticulo");
                dataAccess.ExecuteNonQuery();
                InsertarImagenes(articulo.Imagenes, dataAccess);
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                dataAccess.CloseConnection();
            }

        }

        public void Eliminar(int id)
        {
            // eliminar articulo de BDD
            Database datos = new Database();
            try
            {
                datos.SetQuery("delete from ARTICULOS where Id = @Id");
                datos.SetParameter("@Id", id);
                datos.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CloseConnection();
            }
        }
     

        private void InsertarImagenes(List<string> imagenes, Database dataAccess)
        {
            imagenes.RemoveAll(x => x == "");

            if (imagenes.Count > 0)
            {
                StringBuilder queryBuilder = new StringBuilder();
                queryBuilder.Append("insert into IMAGENES (IdArticulo, ImagenUrl) values ");
                for (int i = 0; i < imagenes.Count; i++)
                {
                    queryBuilder.Append($"(@IdArticulo, @ImagenUrl{i})");
                    if (i != imagenes.Count - 1)
                    {
                        queryBuilder.Append(", ");
                    }
                    dataAccess.SetParameter($"@ImagenUrl{i}", imagenes[i]);
                }
                Console.WriteLine(queryBuilder.ToString());
                dataAccess.SetQuery(queryBuilder.ToString());
                dataAccess.ExecuteNonQuery();
            }
        }
        private void ActualizarMarcaCategoria (Articulo articulo, Database dataAccess)
        {
            dataAccess.SetQuery("update ARTICULOS set IdCategoria = CASE WHEN @IdCategoria = -1 THEN NULL ELSE @IdCategoria END, IdMarca = CASE WHEN @IdMarca = -1 THEN NULL ELSE @IdMarca END where Id = @IdArticulo");
            dataAccess.SetParameter("@IdCategoria", articulo.Categoria.Id);
            dataAccess.SetParameter("@IdMarca", articulo.Marca.Id);
            dataAccess.ExecuteNonQuery();
        }

        public void SincronizarImagenes()
        {
            if (!Directory.Exists(ConfigurationManager.AppSettings["localImagesPath"]))
            {
                Directory.CreateDirectory(ConfigurationManager.AppSettings["localImagesPath"]);
            }
            Console.WriteLine("Sincronizando imágenes");
            List<Articulo> lista = ListarArticulos();
            List<string> enUso = new List<string>();
            foreach (Articulo articulo in lista)
            {
                enUso.AddRange(articulo.Imagenes);
            }
            string[] enLocal = Directory.GetFiles(ConfigurationManager.AppSettings["localImagesPath"]);
            foreach (string imagen in enLocal)
            {
                if (!enUso.Contains(imagen))
                {
                    try
                    {
                        File.Delete(imagen);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
        }

    }
}
