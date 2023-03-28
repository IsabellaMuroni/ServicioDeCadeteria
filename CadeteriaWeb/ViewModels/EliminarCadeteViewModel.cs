using System.ComponentModel.DataAnnotations;

namespace CadeteriaWeb.ViewModels
{
    public class EliminarCadeteViewModel
    {
        [Required]
        public int id { get; set; }
        
        public string nombre { get; set; }
    }
}