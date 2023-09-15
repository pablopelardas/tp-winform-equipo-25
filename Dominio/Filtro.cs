using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Filtro
    {
        public string Id { get; set; }
        public string Campo { get; set; }
        public string Criterio { get; set; }
        public string Valor { get; set; }
        public Filtro() { }

    }
}
