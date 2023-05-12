using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CadeteriaWeb.ViewModels.Cliente
{
    public class MostrarClientesViewModel
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public string Direccion { get; set; }
        [Required]
        public int Telefono { get; set; }
        [Required]
        public string DatosReferenciaDireccion { get; set; }

    }
}