using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models;
using CadeteriaWeb.ViewModels;
using CadeteriaWeb.Mapper;
using CadeteriaWeb.Interfaces;
using AutoMapper;
using System.Data.SQLite;

namespace CadeteriaWeb.Repositories
{
    public class UsuarioRepository: IUsuarioRepository
    {
        private readonly string _cadenaDeConexion;
        private readonly ILogger<UsuarioRepository> _logger;

        public UsuarioRepository(ICadenaDeConexionRepository cadenaDeConexion, ILogger<UsuarioRepository> logger)
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

        public Usuario GetUsuario(string user, string contrasena)
        {
            var connection = GetConnection();

            //Consulta
            var queryString = $"select id_usuario, usuario, rol from Usuario where usuario = '{user}' and contrasena = '{contrasena}';";
            var comando = new SQLiteCommand(queryString, connection);

            var nuevoUsuario = new Usuario();

            using (var reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    nuevoUsuario.Id = Convert.ToInt32(reader[0]);
                    nuevoUsuario.User = reader[1].ToString();
                    nuevoUsuario.Rol = reader[2].ToString();
                }   
            }

            connection.Close();

            return nuevoUsuario;
        }
        
    }
}