using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Copayment_prueba.Models
{
    public class Usuario
    {
        public int Id_usuario { get; set; }
        public string Nombre_usuario { get; set; }
        public string Password { get; set; }
        public string Activo { get; set; }
        public Usuario() { }
        public Usuario(int id_us,string nombre, string pass, string act) {
            this.Id_usuario = id_us;
            this.Nombre_usuario = nombre;
            this.Password = pass;
            this.Activo = act;
        }

    }
}