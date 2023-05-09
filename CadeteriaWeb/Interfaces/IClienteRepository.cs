using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models;
using CadeteriaWeb.ViewModels.Cliente;
using System.Data.SQLite;
using AutoMapper;
using CadeteriaWeb.Mapper;

namespace CadeteriaWeb.Interfaces
{
    public interface IClienteRepository
    {
        Cliente GetCliente (int idCliente);
        //List<Cliente> GetClientes();
        //void Insert (Cliente cliente);
        //void Update (Cliente cliente);
        //void Delete (int idCliente);
    }
}