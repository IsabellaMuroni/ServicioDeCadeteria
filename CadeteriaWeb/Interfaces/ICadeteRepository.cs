using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models;
using CadeteriaWeb.ViewModels;
using System.Data.SQLite;
using AutoMapper;
using CadeteriaWeb.Mapper;

namespace CadeteriaWeb.Interfaces
{
    public interface ICadeteRepository
    {
        Cadete GetCadete(int idCadete);
        List<Cadete> GetCadetes();
        void Insert (Cadete cadete);
        void Update (Cadete cadete);
        void Delete (int idCadete);
    }
}