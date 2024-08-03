using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Copayment_prueba.Models
{
    public class Bitacora_empleado
    {
        public int Id_registro {  get; set; }
        public int Id_empleado { get; set; }
        public DateTime Entrada { get; set; }
        public DateTime Salida { get; set; }

        public Bitacora_empleado() { }
        public Bitacora_empleado(int id_reg,int id_emp,DateTime entrada, DateTime salida) { 
            this.Id_registro = id_reg;
            this.Id_empleado = id_emp;
            this.Entrada = entrada;
            this.Salida = salida;
        }
    }
}
