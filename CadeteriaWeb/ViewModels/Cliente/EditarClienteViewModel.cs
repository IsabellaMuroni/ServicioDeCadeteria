using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CadeteriaWeb.ViewModels.Cliente
{
    public class EditarClienteViewModel
    {
        [Required]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Direccion { get; set; }
        public int Telefono { get; set; }
        public string DatosReferenciaDireccion { get; set; }
    }
}