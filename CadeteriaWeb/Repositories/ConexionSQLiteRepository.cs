using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Repositories;
using System.Data.SQLite;
using AutoMapper;
using CadeteriaWeb.Mapper;


namespace CadeteriaWeb.Repositories
{
    public interface IConexion
    {
        SQLiteConnection GetConexion();
    }
    public class ConexionSQLiteRepository: IConexion
    {
        public SQLiteConnection GetConexion()
        {
            var cadenaDeConexion = @"Data Source = DB\Pedidos_DB.db; Version = 3;";
            var connection = new SQLiteConnection(cadenaDeConexion);

            return connection;
        }       
    }
}