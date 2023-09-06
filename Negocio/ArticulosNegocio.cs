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

        public List<Articulo> Listar()
        {
            List<Articulo> lista = new List<Articulo>();
            // llenar lista con datos BDD

            // Mock
            lista.Add(new Articulo(1, "Articulo 1", "Descripcion 1", 100, new Marca(1, "Marca1"), new Categoria(1, "Cat1")));
            lista.Add(new Articulo(2, "Articulo 2", "Descripcion 2", 200, new Marca(2, "Marca2"), new Categoria(2, "Cat2")));
            lista.Add(new Articulo(3, "Articulo 3", "Descripcion 3", 300, new Marca(3, "Marca3"), new Categoria(3, "Cat3")));
            lista.Add(new Articulo(4, "Articulo 4", "Descripcion 4", 400, new Marca(4, "Marca4"), new Categoria(4, "Cat4")));
            lista.Add(new Articulo(5, "Articulo 5", "Descripcion 5", 500, new Marca(5, "Marca5"), new Categoria(5, "Cat5")));

            // retornar lista
            return lista;
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
    }
}
