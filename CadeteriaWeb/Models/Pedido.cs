using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models;

namespace CadeteriaWeb.Models
{
    public class Pedido
    {
        private int id;
        private string obs;
        
        private bool estado;
        private int idCliente;
        private int idCadete;

        //Getters & setters
        public int Id { get => id; set => id = value; }
        public string Obs { get => obs; set => obs = value; }
        public bool Estado { get => estado; set => estado = value; }
        public int IdCliente { get => idCliente; set => idCliente = value; }
        public int IdCadete { get => idCadete; set => idCadete = value; }

        //Constructores
        public Pedido(){ }

        public Pedido (int _id, string _obs, bool _estado, int _idCliente, int _idCadete)
        {
            this.id = _id;
            this.obs = _obs;
            this.estado = _estado;
            this.idCliente = _idCliente;
            this.idCadete = _idCadete;
        }
    }
}