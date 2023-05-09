using System.ComponentModel.DataAnnotations;

namespace CadeteriaWeb.ViewModels
{
    public class EditarCadeteViewModel
    {
        [Required]
        public int id { get; set; }
        
        [Required][StringLength(100)][Display (Name = "Nombre del Cadete")]
        public string nombre { get; set; }
       
        [Required][StringLength(120)][Display (Name = "Dirección")]
        public string direccion { get; set; }

        [Required][Phone]
        public int telefono { get; set; }
    }
}
/* Los ViewModels deben tener los nombres 
    de los atributos en modo público. No requieren constructores
*/