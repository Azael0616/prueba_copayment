using System.Collections.Generic;
using System.Web.Http;
using Copayment_prueba.Models;
using Copayment_prueba.DAL;
using System;
using Copayment_prueba.Dtos;

namespace Copayment_prueba.Controllers
{
    public class BitacoraEmpleadoController : ApiController
    {
        private Bitacora_empleadoDAL _bitacoraEmpleadoDAL = new Bitacora_empleadoDAL();
        #region Obtener Bitacora_empleado
        [HttpPost]
        [Route("api/bitacoraempleado/obtenerBitacoraEmpleado")]
        public List<Bitacora_empleado> obtenerBitacoraEmpleado(Bitacora_empleadoDTO parametro)
        {
                List<Bitacora_empleado> bt_empleados = _bitacoraEmpleadoDAL.obtenerBitacoraEmpleado(parametro);
                return bt_empleados;        
        }
        [HttpPost]
        [Route("api/bitacoraempleado/obtenerBitacorasEmpleados")]
        public List<Bitacora_empleado> obtenerBitacorasEmpleados(Bitacora_empleadoDTO parametro)
        {
            if (parametro.Fecha==null)
                parametro.Fecha = DateTime.Today;
            List<Bitacora_empleado> bt_empleados = _bitacoraEmpleadoDAL.obtenerBitacorasEmpleados(parametro);
            return bt_empleados;
        }
        #endregion

        #region Registrar Entrada/Salida
        [HttpPost]
        [Route("api/bitacoraempleado/registrarEntrada")]
        public string registrarEntrada(Bitacora_empleadoDTO parametro)
        {
            if (parametro.Id_empleado != 0 && parametro.Id_empleado != null)
            {
                parametro.Fecha_entrada = DateTime.Now;
                return _bitacoraEmpleadoDAL.registrarEntrada(parametro);
            }
            else
                return "Debe ingresar el Id del empleado";
        }
        [HttpPost]
        [Route("api/bitacoraempleado/registrarSalida")]
        public string registrarSalida(Bitacora_empleadoDTO parametro)
        {
            if (parametro.Id_empleado != 0 && parametro.Id_empleado != null)
            {
                parametro.Fecha_salida = DateTime.Now;
                parametro.Fecha_entrada = DateTime.Today;
                return _bitacoraEmpleadoDAL.registrarSalida(parametro);
            }
            else
                return "Debe ingresar el Id del empleado";
        }
        #endregion

        #region Calcular Salario Diario
        [HttpPost]
        [Route("api/bitacoraempleado/calcularSalarioDiarioIndividual")]
        public List<CalculoSalario> calcularSalarioDiarioIndividual(Bitacora_empleadoDTO parametro)
        {
            if (parametro.Fecha == null)
                parametro.Fecha = DateTime.Today;
            List<CalculoSalario> bt_empleados = _bitacoraEmpleadoDAL.calcularSalarioDiarioIndividual(parametro);
            return bt_empleados;
        }
        [HttpPost]
        [Route("api/bitacoraempleado/calcularTodoSalarioDiario")]
        public List<CalculoSalario> calcularTodoSalarioDiario(Bitacora_empleadoDTO parametro)
        {
            if (parametro.Fecha == null)
                parametro.Fecha = DateTime.Today;
            List<CalculoSalario> bt_empleados = _bitacoraEmpleadoDAL.calcularTodoSalarioDiario(parametro);
            return bt_empleados;
        }
        #endregion
    }
}
