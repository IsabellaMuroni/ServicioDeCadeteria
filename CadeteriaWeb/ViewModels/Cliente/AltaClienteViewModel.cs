using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaWeb.ViewModels.Cliente
{
    public class AltaClienteViewModel
    {
        public string Nombre { get; set; }
        //public string Apellido { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string DatosReferenciaDireccion { get; set; }

    }
}