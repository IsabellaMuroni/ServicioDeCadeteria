using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaWeb.Models
{
    public class Usuario
    {
        private int id;
        private string nombre;
        private string user;
        private string rol;

    
        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string User { get => user; set => user = value; }
        public string Rol { get => rol; set => rol = value; }

        public Usuario(){}

        public Usuario(int id, string nombre, string user, string rol)
        {
            this.id = Id;
            this.nombre = Nombre;
            this.user = User;
            this.rol = Rol;
        }
    }
}