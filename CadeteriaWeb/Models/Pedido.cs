using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CadeteriaWeb.Models;

namespace CadeteriaWeb.Models
{
    public class Pedido
    {
        private int ID;
        private string OBS;
        private Cliente Cliente;
        private bool Estado;

        //Getters & setters
        public int id { get; set; }
        public string obs { get; set; }
        public Cliente cliente { get; set; }
        public bool estado { get; set; }

        //Constructores
        public Pedido()
        {
            this.Cliente = new Cliente();
            this.Estado = false;
        }

        public Pedido (string obs_,
                       string nombre,
                       string dir,
                       int tel,
                       string datosRefDir)
        {
            this.OBS = obs_;
            this.Estado = false;
            this.Cliente = new Cliente (nombre,dir, tel, datosRefDir);
        }
    }
}