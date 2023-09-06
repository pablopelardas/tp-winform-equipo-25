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
            categoria = str;
        }
        public string categoria { get; set; }
        public int idCategoria { get; set; }

    }
}
