using System.Collections.Generic;
using System.Web.Http;
using Copayment_prueba.Models;
using Copayment_prueba.DAL;
namespace Copayment_prueba.Controllers
{
    public class EmpleadoController : ApiController
    {
        private EmpleadosDAL _empleadosDAL = new EmpleadosDAL();
        #region Obtener empleado
        [HttpPost]
        [Route("api/empleado/obtenerEmpleado/{id}")]
        public Empleado obtenerEmpleado(int id)
        {
                Empleado empleado = _empleadosDAL.obtenerEmpleado(id);
                return empleado;            
        }
        [HttpPost]
        [Route("api/empleado/obtenerEmpleados")]
        public List<Empleado> obtenerEmpleados()
        {
            List<Empleado> empleados = _empleadosDAL.obtenerEmpleados();
            return empleados;
        }
        #endregion

        #region Crear empleado
        [HttpPost]
        [Route("api/empleado/crearEmpleado")]
        public string crearEmpleado(Empleado parametro)
        {
            return _empleadosDAL.crearEmpleado(parametro);
        }
        #endregion

        #region Actualizar empleado
        [HttpPost]
        [Route("api/empleado/actualizarEmpleado")]
        public string actualizarEmpleado(Empleado parametro)
        {
            return _empleadosDAL.actualizarEmpleado(parametro);
        }
        #endregion
        #region Eliminar empleado
        [HttpPost]
        [Route("api/empleado/eliminarEmpleado/{id}")]
        public string eliminarEmpleado(int id)
        {
            return _empleadosDAL.eliminarEmpleado(id);
        }
        #endregion

    }
}
