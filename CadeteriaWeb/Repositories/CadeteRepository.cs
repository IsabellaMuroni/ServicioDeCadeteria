using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models;
using CadeteriaWeb.ViewModels;
using System.Data.SQLite;
using AutoMapper;
using CadeteriaWeb.Mapper;

namespace CadeteriaWeb.Repositories
{
    public interface ICadeteRepository
    {
        Cadete GetCadete(int idCadete);
        List<Cadete> GetCadetes();
        void Insert (Cadete cadete);
        void Update (Cadete cadete);
        void Delete (int idCadete);
    } 

    public class CadeteRepository : ICadeteRepository
    {
        public Cadete GetCadete(int idCadete)
        {
            var cadenaDeConexion = @"Data Source = DB\Pedidos_DB.db; Version = 3;";
            var connection = new SQLiteConnection(cadenaDeConexion);

            connection.Open();

            //Consulta
            var queryString = $"select * from Cadete where id_cadete = {idCadete};";
            var comando = new SQLiteCommand(queryString, connection);

            var nuevoCadete = new Cadete ();

            using (var reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    nuevoCadete.id = Convert.ToInt32(reader[0]);
                    nuevoCadete.nombre = reader[1].ToString();
                    nuevoCadete.telefono = Convert.ToInt32(reader[2]);
                    nuevoCadete.direccion = reader[3].ToString();
                }   
            }

            connection.Close();

            return nuevoCadete;
        }

        public void Insert (Cadete cadete)
        {
            var nombre_ = cadete.nombre;
            var telefono_ = cadete.telefono;
            var direccion_ = cadete.direccion;

            var cadenaDeConexion = @"Data Source = DB\Pedidos_DB.db; Version = 3;";
            var connection = new SQLiteConnection(cadenaDeConexion);

            connection.Open();

            //Consulta
            var queryString = "insert into Cadete (nombre, telefono, direccion)" + " values ('"+nombre_+"','"+telefono_+"','"+direccion_+"');";
            var comando = new SQLiteCommand(queryString, connection);
            
            comando.ExecuteNonQuery();
           
            connection.Close();
        }

        public void Update (Cadete cadete)
        {
            var cadenaDeConexion = @"Data Source = DB\Pedidos_DB.db; Version = 3;";
            var connection = new SQLiteConnection(cadenaDeConexion);

            connection.Open();

            var id = cadete.id;
            var _nombre = cadete.nombre;
            var _telefono = cadete.telefono;
            var _direccion = cadete.direccion;
           
            //Consulta
            var queryString = $"update Cadete set nombre = '{_nombre}', telefono = '{_telefono}', direccion = '{_direccion}' where id_cadete = '{id}';";
            var comando = new SQLiteCommand(queryString, connection);
            
            comando.ExecuteNonQuery();
           
            connection.Close();
        }

        public void Delete (int id)
        {
            var cadenaDeConexion = @"Data Source = DB\Pedidos_DB.db; Version = 3;";
            var connection = new SQLiteConnection(cadenaDeConexion);

            connection.Open();

            //Consulta
            var queryString = $"delete from Cadete where id_cadete = '{id}';";
            var comando = new SQLiteCommand(queryString, connection);
            
            comando.ExecuteNonQuery();
           
            connection.Close();
        }

        public List<Cadete> GetCadetes()
        {
            List<Cadete> cadetes = new List<Cadete>();
            //List<MostrarCadetesViewModel> cadetes = new List<MostrarCadetesViewModel>();

            var cadenaDeConexion = @"Data Source = DB\Pedidos_DB.db; Version = 3;";
            var connection = new SQLiteConnection(cadenaDeConexion);

            connection.Open();

            var queryString = "select * from Cadete;";//Consulta
            var comando = new SQLiteCommand(queryString, connection);
            //List<string> cadetes = new List<string>();

            using (var reader = comando.ExecuteReader())
            {
                while (reader.Read())
                {
                    var _id = Convert.ToInt32(reader[0]);
                    var nombre = reader[1].ToString();
                    var telefono = Convert.ToInt32(reader[2]);
                    var direccion = reader[3].ToString();
                    cadetes.Add(new Cadete (_id, nombre,  direccion, telefono));
                }
            }

             connection.Close();

            return cadetes;
        }
    }
}