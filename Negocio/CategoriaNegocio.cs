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


    }
}
