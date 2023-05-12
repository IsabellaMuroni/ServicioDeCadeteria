using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models;
using CadeteriaWeb.ViewModels;
using CadeteriaWeb.ViewModels.Cliente;
using CadeteriaWeb.ViewModels.Usuario;
using AutoMapper;

namespace CadeteriaWeb.Mapper
{
    public class PerfilDeMapeo : Profile
    {
        public PerfilDeMapeo ()
        {
            //Cadetes: Alta, Baja, Modificación
            CreateMap<Cadete, AltaCadeteViewModel>().ReverseMap();
            CreateMap<Cadete, MostrarCadetesViewModel>().ReverseMap();
            CreateMap<Cadete, EditarCadeteViewModel>().ReverseMap();
            CreateMap<Cadete, EliminarCadeteViewModel>().ReverseMap();
            //Clientes: alta, baja, modificación
            CreateMap<Cliente, AltaClienteViewModel>().ReverseMap();
            CreateMap<Cliente, MostrarClientesViewModel>().ReverseMap();
            CreateMap<Cliente, EditarClienteViewModel>().ReverseMap();
            CreateMap<Cliente, EliminarClienteViewModel>().ReverseMap();
            CreateMap<Usuario, LoginViewModel>().ReverseMap();
        }
        
    }
}