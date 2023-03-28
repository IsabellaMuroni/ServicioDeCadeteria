using System.ComponentModel.DataAnnotations;

namespace CadeteriaWeb.ViewModels
{
    public class AltaCadeteViewModel
    {
        [Required][StringLength(100)][Display (Name = "Nombre del Cadete")]
        public string nombre { get; set; }
       
        [Required][StringLength(120)][Display (Name = "Dirección")]
        public string direccion { get; set; }

        [Required][Phone]
        public int telefono { get; set; }
    }
}