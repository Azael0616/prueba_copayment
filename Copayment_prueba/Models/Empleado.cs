using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Copayment_prueba.Models
{
    public class Empleado
    {
        public int Id_empleado {  get; set; }
        public string Nombre { get; set; }
        public string App { get; set; }
        public string Apm {  get; set; }

        public DateTime Fecha_nacimiento { get; set; }
        public string Sexo { get; set; }
        public int Departamento { get; set; }
        public string Telefono_contacto { get; set; }
        public string Correo_contacto { get; set; }
        public string Activo { get; set; }
        public Empleado() { }
        public Empleado (int id_emp, string nom, string app, string apm, DateTime nacimiento,string sex, int dep, string telefono, string correo, string act)
        {
            this.Id_empleado = id_emp;
            this.Nombre = nom;
            this.App = app;
            this.Apm= apm;
            this.Fecha_nacimiento= nacimiento;
            this.Sexo = sex;
            this.Departamento = dep;
            this.Telefono_contacto = telefono;
            this.Correo_contacto = correo;
            this.Activo = act;

        }
    }
}