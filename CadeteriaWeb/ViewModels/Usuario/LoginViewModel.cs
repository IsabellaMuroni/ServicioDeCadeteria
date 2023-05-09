using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace CadeteriaWeb.ViewModels.Usuario
{
    public class LoginViewModel
    {
        public int Id { get; set; }
        
        [Display(Name = "Nombre de usuario")]
        [Required(ErrorMessage = "Ingrese su nombre de usuario")]
        public string User { get; set; }

        [Display(Name = "Contraseña")]
        [Required(ErrorMessage = "Ingrese su contraseña")]
        public string Contrasena { get; set; }
    }
}