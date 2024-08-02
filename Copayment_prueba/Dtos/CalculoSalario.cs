using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Copayment_prueba.Dtos
{
    public class CalculoSalario
    {
        public int Id_empleado { get; set; }
        public string Nombre { get; set; }
        public string App {  get; set; }
        public string Apm { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Salida { get; set; }
        public double Salario_diario { get; set; }
        public double Horas_trabajadas { get; set; }
        public CalculoSalario() { }
        public CalculoSalario(int id_emp, string nom, string app, string apm, DateTime entrada, DateTime salida, double salario, double horas) { 
            this.Id_empleado = id_emp;
            this.Nombre = nom;
            this.App= app;
            this.Apm= apm;
            this.Entrada = entrada;
            this.Salida = salida;
            this.Salario_diario = salario;
            this.Horas_trabajadas = horas;
        }
    }
}