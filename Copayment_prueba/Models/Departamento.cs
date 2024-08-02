using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Copayment_prueba.Models
{
    public class Departamento
    {
        public int Id_departamento { get; set; }
        public string Nombre { get; set; }
        public double Pago_hora { get; set; }
        public Departamento() { }
        public Departamento(int Id_dep, string nom, double pago)
        {
            this.Id_departamento = Id_dep;
            this.Nombre=nom;
            this.Pago_hora = pago;
        }

    }
}