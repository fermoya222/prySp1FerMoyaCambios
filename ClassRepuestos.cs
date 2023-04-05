using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace prySp1FerMoya
{
    internal class ClassRepuestos
    {
        // propiedades
        public int codigo { get; set; }
        public string nombre { get; set; }
        public string marca { get; set; }
        public int precio { get; set; }

        public bool origen { get; set; }
        

        //metodosd
        public string ObtenerDatos()
        {
            return codigo + " " + nombre + " " + marca + " " + precio + " ";
        }

    }
}
