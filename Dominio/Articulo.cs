using System;
using System.Collections.Generic;
using System.ComponentModel;


namespace Dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        [DisplayName("Código")]
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        [DisplayName("Descripción")]
        public string Descripcion { get; set;}
        // Marca
        public Marca Marca { get; set; }
        // Categoria
        [DisplayName("Categoría")]
        public Categoria Categoria { get; set; }
        public List<string> Imagenes { get; set; }
        [DisplayName("Precio")]
        public float Precio { get; set; }
        

        public Articulo() { 
            Id = -1;
        }
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
