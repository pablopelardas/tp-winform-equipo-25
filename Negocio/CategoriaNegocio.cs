using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class CategoriaNegocio
    {

        public List<Categoria> ListarCategorias()
        {
            // Listar categoria en BDD
            List<Categoria> categorias = new List<Categoria>();
            Database datos = new Database();

            try
            {
                datos.SetQuery("SELECT Id, Descripcion FROM [dbo].[CATEGORIAS]");
                datos.ReadData();

                while (datos.Reader.Read())
                {
                    Categoria categ = new Categoria();
                    categ.Id = (int)datos.Reader["Id"];
                    categ.Nombre = (string)datos.Reader["Descripcion"];

                    categorias.Add(categ);
                }

                return categorias;
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

        public void Agregar(Categoria categoria)
        {
            // Agregar categoria en BDD
            Database datos = new Database();
            try
            {
                datos.SetQuery("insert into CATEGORIAS (Descripcion) values (@Descripcion);");
                datos.SetParameter("@Descripcion", categoria.Nombre);
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

        public void Modificar(Categoria categoria)
        {
            // Modificar categoria en BDD
            Database datos = new Database();
            try
            {
                datos.SetQuery("update CATEGORIAS set Descripcion = @Descripcion where Id = @Id");
                datos.SetParameter("@Descripcion", categoria.Nombre);
                datos.SetParameter("@Id", categoria.Id);
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

        public void Eliminar(int id)
        {
            // Eliminar categoria de BDD
            Database datos = new Database();
            try
            {
                datos.SetQuery("delete from CATEGORIAS where Id = @Id");
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


    }
}
