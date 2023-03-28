using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CadeteriaWeb.Models
{
    public class Cliente
    {
        private int id;
        private string nombre;
        //private string apellido;
        private string direccion;
        private int telefono;
        private string datosReferenciaDireccion;

        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        //public string Apellido { get => apellido; set => apellido = value; }
        public string Direccion { get => direccion; set => direccion = value; }
        public int Telefono { get => telefono; set => telefono = value; }
        public string DatosReferenciaDireccion { get => datosReferenciaDireccion; set => datosReferenciaDireccion = value; }

        //Constructores
        public Cliente (){}

        public Cliente (string nombre, string dir, int tel, string datosRefDir)
        {
            //this.id = id;
            this.nombre = nombre;
            //this.apellido = apellido;
            this.direccion = dir;
            this.telefono = tel;
            this.datosReferenciaDireccion = datosRefDir;
        }
    }
}