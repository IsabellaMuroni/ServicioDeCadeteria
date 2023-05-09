using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models;

namespace CadeteriaWeb.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario GetUsuario(string usuario, string contrasena);
    }
}