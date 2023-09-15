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

    }
}
