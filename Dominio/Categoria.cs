using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {
        public Categoria() { }
        public Categoria(int id, string nombre)
        {
            idCategoria = id;
            Nombre = nombre;
        }
        public string Nombre { get; set; }
        public int idCategoria { get; set; }


    }
}
