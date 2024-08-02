using System.Collections.Generic;
using System.Web.Http;
using Copayment_prueba.Models;
using Copayment_prueba.DAL;
using System;
using Copayment_prueba.Dtos;

namespace Copayment_prueba.Controllers
{
    public class DepartamentoController : ApiController
    {
        private DepartamentoDAL _departamentoDAL = new DepartamentoDAL();
        #region Obtener departamento
        [HttpPost]
        [Route("api/departamento/obtenerDepartamento/{id}")]
        public Departamento obtenerDepartamento(int id)
        {
            Departamento departamento = _departamentoDAL.obtenerDepartamento(id);
            return departamento;
        }
        [HttpPost]
        [Route("api/departamento/obtenerDepartamentos")]
        public List<Departamento> obtenerDepartamentos()
        {
            List<Departamento> departamentos = _departamentoDAL.obtenerDepartamentos();
            return departamentos;
        }
        #endregion
        #region Actualizar departamento
        [HttpPost]
        [Route("api/departamento/actualizarDepartamento")]
        public string actualizarDepartamento(Departamento parametro)
        {
            return _departamentoDAL.actualizarDepartamento(parametro);
        }
        [HttpPost]
        [Route("api/departamento/actualizarPagoHora")]
        public string actualizarPagoHora(Departamento parametro)
        {
            return _departamentoDAL.actualizarPagoHora(parametro);
        }
        #endregion
        #region Eliminar departamento
        [HttpPost]
        [Route("api/departamento/eliminarDepartamento/{id}")]
        public string eliminarDepartamento(int id)
        {
            return _departamentoDAL.eliminarDepartamento(id);
        }
        #endregion
    }
}
