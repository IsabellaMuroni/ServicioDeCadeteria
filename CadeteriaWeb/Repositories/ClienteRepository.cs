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
            var connection = GetConnection();

            //Consulta
            var queryString = $"select * from Cliente where id_cliente = {idCliente};";
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

        public List<Cliente> GetClientes()
        {
            try
            {
                List<Cliente> clientes = new List<Cliente>();
                
                var connection = GetConnection();

                //Consulta
                var queryString = "select * from Cliente;";
                SQLiteCommand comando = new SQLiteCommand(queryString, connection);

                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var id = Convert.ToInt32(reader[0]);
                        var nombre = reader[1].ToString();
                        var direccion = reader[2].ToString();
                        var telefono = Convert.ToInt32(reader[3]);
                        var referencias = reader[4].ToString();
                        clientes.Add(new Cliente (id, nombre, direccion, telefono, referencias));
                    }
                }

                connection.Close();
                return clientes;
            }
            catch(SQLiteException exDB)
            {
                _logger.LogDebug("ERROR: No se pudo obtener el listado de clientes. Excepción: " + exDB.ToString());
                throw new Exception("ERROR: No se pudo obtener el listado de clientes", exDB);
            }
            catch(Exception ex)
            {
                _logger.LogDebug("ERROR: No se pudo obtener el listado de clientes. Excepción: " + ex.ToString());
                throw;
            }
        }

        public void Insert (Cliente cliente)
        {
            var nombre_ = cliente.Nombre;
            var telefono_ = cliente.Direccion;
            var direccion_ = cliente.Telefono;
            var datosRef = cliente.DatosReferenciaDireccion;

            var connection = GetConnection();

            //Consulta
            var queryString = $"insert into Cliente (nombre, direccion, telefono, observaciones) values ('{nombre_}','{direccion_}','{telefono_}', '{datosRef}');";
            var comando = new SQLiteCommand(queryString, connection);

            comando.ExecuteNonQuery();

            connection.Close();
        }

        public void Update (Cliente cliente)
        {
            try
            {
                var connection = GetConnection();

                var _id = cliente.Id;
                var nombre = cliente.Nombre;
                var direccion = cliente.Direccion;
                var telefono = cliente.Telefono;
                var _datosRef = cliente.DatosReferenciaDireccion;
            
                //Consulta
                var queryString = $"update Cliente set nombre = '{nombre}', direccion = '{direccion}', telefono = '{telefono}', observaciones = '{_datosRef}' where id_cliente = {_id};";
                var comando = new SQLiteCommand(queryString, connection);
                
                comando.ExecuteNonQuery();
            
                connection.Close();

                _logger.LogInformation($"Se modificó correctamente el Cliente - ID: {cliente.Id}");
            }
            catch (Exception ex)
            {
                _logger.LogDebug($"ERROR: no se pudo eliminar el cliente: ID - {cliente.Id}. Excepción: " + ex.ToString());                
                throw;
            }
        }

        public void Delete (int id)
        {
            try
            {
                var connection = GetConnection();

                //Consulta
                var queryString = $"delete from Cliente where id_cliente = '{id}';";
                var comando = new SQLiteCommand(queryString, connection);
                
                comando.ExecuteNonQuery();
            
                connection.Close();

                _logger.LogInformation($"Se eliminó el cliente - ID: {id}");
            }
            catch (SQLiteException exDB)
            {
                _logger.LogDebug($"ERROR: no se pudo eliminar el cliente: ID - {id}. Excepción: " + exDB.ToString());
            }
            catch(Exception ex)
            {
                _logger.LogDebug($"ERROR: no se pudo eliminar el cliente: ID - {id}. Excepción: " + ex.ToString());
            }
        }
    }
}