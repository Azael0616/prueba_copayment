using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Copayment_prueba.Dtos
{
    public class Login
    {
        public string Nombre_usuario { get; set; }
        public string Password { get; set; }
        public Login() { }
        public Login(string nombre,string pass) {
            this.Nombre_usuario = nombre;
            this.Password = pass;
        }
    }
}