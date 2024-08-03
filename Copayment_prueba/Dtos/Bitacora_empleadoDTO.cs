using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Copayment_prueba.Dtos
{
    public class Bitacora_empleadoDTO
    {
        public DateTime? Fecha { get; set; }
        public int? Id_empleado { get; set; }
        public DateTime? Fecha_entrada { get; set; }
        public DateTime? Fecha_salida { get; set; }
    }
}
