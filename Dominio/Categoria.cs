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
        public Categoria(string str)
        {
            Nombre = str;
        }
        public string Nombre { get; set; }
        public int idCategoria { get; set; }

    }
}
