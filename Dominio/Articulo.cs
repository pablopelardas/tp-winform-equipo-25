using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set;}
        public List<string> Imagenes { get; set; }
        public float Precio { get; set; }

        // Marca
        public Marca Marca { get; set; }
        // Categoria
        public Categoria Categoria { get; set; }


        public Articulo(int id, string nombre, string descripcion, float precio, Marca marca, Categoria categoria)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            Precio = precio;
            Marca = marca;
            Categoria = categoria;
        }

    }
}
