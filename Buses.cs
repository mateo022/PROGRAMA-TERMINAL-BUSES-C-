using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace proyecto
{
     public class Buses
    {
        public string placa { get; set; }
        public string tipoBus { get; set; }
        public int cantidadAsientos { get; set; }
        public Cliente [,] distribucion { get; set; }               
    }

    
}
