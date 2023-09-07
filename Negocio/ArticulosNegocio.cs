using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using AccesoDatos;



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
            List<Articulo> articulos = new List<Articulo>();
            Database datos = new Database();

            //Descomentar cuando tengamos la db
            /*
            try
            {
                datos.setQuery("select ..."); //FALTA QUERY
                datos.readData();

                while (datos.Reader.Read())
                {
                    Articulo art = new Articulo();
                    art.Id = (int)datos.Reader["Id"];
                    art.Nombre = (string)datos.Reader["Nombre"];
                    art.Descripcion = (string)datos.Reader["Descripcion"];
                    
                    art.Precio = (float)datos.Reader["Precio"];

                    art.Marca = new Marca();
                    art.Marca.Id = (int)datos.Reader["IdMarca"];
                    art.Marca.Nombre = (string)datos.Reader["Marca"];

                    art.Categoria = new Categoria();
                    art.Categoria.Id = (int)datos.Reader["IdCategoria"];
                    art.Categoria.Nombre = (string)datos.Reader["Categoria"];

                    art.Imagenes = (string)datos.Reader["URL"]; //REVISAR SI VIENE EN OTRA TABLA O VIENE COMO STRING SEPARADO POR COMAS

                    articulos.Add(art);
                }

                return articulos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            */

            // Mock
            articulos.Add(new Articulo(1, "Articulo 1", "Descripcion 1", 100, new Marca(1, "Marca1"), new Categoria(1, "Cat1")));
            articulos.Add(new Articulo(2, "Articulo 2", "Descripcion 2", 200, new Marca(2, "Marca2"), new Categoria(2, "Cat2")));
            articulos.Add(new Articulo(3, "Articulo 3", "Descripcion 3", 300, new Marca(3, "Marca3"), new Categoria(3, "Cat3")));
            articulos.Add(new Articulo(4, "Articulo 4", "Descripcion 4", 400, new Marca(4, "Marca4"), new Categoria(4, "Cat4")));
            articulos.Add(new Articulo(5, "Articulo 5", "Descripcion 5", 500, new Marca(5, "Marca5"), new Categoria(5, "Cat5")));

            // retornar articulos
            return articulos;
        }

        public void Agregar(Articulo articulo)
        {
            // agregar articulo a BDD
        }

        public void Modificar(Articulo articulo)
        {
            // modificar articulo en BDD
        }

        public void Eliminar(int id)
        {
            // eliminar articulo de BDD
        }

        public List<Marca> ListarMarcas()
        {
            List<Marca> marcas = new List<Marca>();
            Database datos = new Database();

            //Descomentar cuando tengamos la db
            /*
            try
            {
                datos.setQuery("select ..."); //FALTA QUERY
                datos.readData();

                while (datos.Reader.Read())
                {
                    Marca marca = new Marca();
                    marca.Id = (int)datos.Reader["IdMarca"];
                    marca.Nombre = (string)datos.Reader["Marca"];

                    marcas.Add(marca);
                }

                return marcas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            */

            marcas.Add(new Marca(1, "Marca 1"));
            marcas.Add(new Marca(2, "Marca 2"));
            marcas.Add(new Marca(3, "Marca 3"));

            return marcas;
        }


}
}
