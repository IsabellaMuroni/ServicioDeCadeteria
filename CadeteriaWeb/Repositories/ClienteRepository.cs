using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models;
using CadeteriaWeb.ViewModels.Cliente;
using System.Data.SQLite;
using AutoMapper;
using CadeteriaWeb.Mapper;
using CadeteriaWeb.Interfaces;

namespace CadeteriaWeb.Repositories
{
    public class ClienteRepository: IClienteRepository
    {
        private readonly string _cadenaDeConexion;
        private readonly ILogger<ClienteRepository> _logger;

        public ClienteRepository(ICadenaDeConexionRepository cadenaDeConexion, ILogger<ClienteRepository> logger)
        {
            this._cadenaDeConexion = cadenaDeConexion.GetCadena();
            this._logger = logger;
        }

        private SQLiteConnection GetConnection()
        {
            var connection = new SQLiteConnection(_cadenaDeConexion);
            connection.Open();

            return connection;
        }
        public Cliente GetCliente (int idCliente)
        {
            /*var cadenaDeConexion = @"Data Source = DB\Pedidos_DB.db; Version = 3;";
            var connection = new SQLiteConnection(cadenaDeConexion);*/
            var connection = GetConnection();

            //Consulta
            var queryString = $"select * from Cliente where id_cadete = {idCliente};";
            var comando = new SQLiteCommand(queryString, connection);

            var nuevoCliente = new Cliente ();

            using (var reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    nuevoCliente.Id = Convert.ToInt32(reader[0]);
                    nuevoCliente.Nombre = reader[1].ToString();
                    nuevoCliente.Direccion = reader[2].ToString();
                    nuevoCliente.Telefono = Convert.ToInt32(reader[3]);
                    nuevoCliente.DatosReferenciaDireccion = reader[4].ToString();
                }   
            }

            connection.Close();

            return nuevoCliente;
        }
    }
}