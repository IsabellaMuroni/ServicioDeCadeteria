using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Repositories;
using System.Data.SQLite;
using AutoMapper;
using CadeteriaWeb.Mapper;
using CadeteriaWeb.Interfaces;


namespace CadeteriaWeb.Repositories
{
    public class ConexionSQLiteRepository: ICadenaDeConexionRepository
    {
        //Para que lea el jason de la cadena
        private readonly IConfiguration _configuration;

        public ConexionSQLiteRepository (IConfiguration configuration)
        {
            this._configuration = configuration;
        }   

        public string GetCadena()
        {
            return _configuration.GetConnectionString("SQLite");
        }    
    }
}