using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;

namespace Negocio
{
    public class MarcaNegocio
    {

        public List<Marca> ListarMarcas()
        {
            List<Marca> marcas = new List<Marca>();
            Database datos = new Database();

            try
            {
                datos.SetQuery("SELECT Id, Descripcion FROM [dbo].[MARCAS]");
                datos.ReadData();

                while (datos.Reader.Read())
                {
                    Marca marca = new Marca();
                    marca.Id = (int)datos.Reader["Id"];
                    marca.Nombre = (string)datos.Reader["Descripcion"];

                    marcas.Add(marca);
                }

                return marcas;
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

        public void Agregar(Marca marca)
        {
            // Agregar marca en BDD
            Database datos = new Database();
            try
            {
                datos.SetQuery("insert into MARCAS (Descripcion) values (@Descripcion);");
                datos.SetParameter("@Descripcion", marca.Nombre);
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

        public void Modificar(Marca marca)
        {
            // Modificar marca en BDD
            Database datos = new Database();
            try
            {
                datos.SetQuery("update MARCAS set Descripcion = @Descripcion where Id = @Id");
                datos.SetParameter("@Descripcion", marca.Nombre);
                datos.SetParameter("@Id", marca.Id);
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
            // Eliminar marca de BDD
            Database datos = new Database();
            try
            {
                datos.SetQuery("delete from MARCAS where Id = @Id");
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
