using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace CadeteriaWeb.ViewModels.Cliente
{
    public class EliminarClienteViewModel
    {
        public int Id { get; set; }
        
        public string Nombre { get; set; }
    }
}