using System.ComponentModel.DataAnnotations;

namespace CadeteriaWeb.ViewModels
{
    public class MostrarCadetesViewModel
    {
        public int id { get; set; }
         [Required]
        public string nombre { get; set; }
         [Required]
        public string direccion { get; set; }
         [Required][Phone]
        public int telefono { get; set; }
    }
}