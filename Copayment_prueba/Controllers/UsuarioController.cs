using System;
using System.Collections.Generic;
using System.Web.Http;
using Copayment_prueba.DAL;
using Copayment_prueba.Models;
using Copayment_prueba.Dtos;
using Copayment_prueba.Utils;
using System.Web.UI.WebControls;

namespace Copayment_prueba.Controllers
{
    public class UsuarioController : ApiController
    {
        private UsuarioDAL _usuarioDAL = new UsuarioDAL();
        #region Crear usuario
        [HttpPost]
        [Route("api/usuario/crearUsuario")]
        public string crearUsuario(Usuario parametro)
        {            
            return _usuarioDAL.crearUsuario(parametro);
        }
        #endregion
        #region Iniciar sesión 
        [HttpPost]
        [Route("api/usuario/iniciarSesion")]
        public IHttpActionResult iniciarSesion(Dtos.Login parametro)
        {
            Usuario user = _usuarioDAL.obtenerUsuario(parametro.Nombre_usuario);
            bool valido = Utils.Utils.validarPassword(user.Password, parametro.Password);
            if(valido)
            {
                string token = Utils.Utils.generarToken(user.Nombre_usuario);
                return Ok(new { token });
            }
            else
                return Unauthorized();
        }
        #endregion
        #region Eliminar usuario
        [HttpPost]
        [Route("api/usuario/eliminarUsuario/{nombre_usuario}")]
        public string eliminarUsuario(string nombre_usuario)
        {
            return _usuarioDAL.eliminarUsuario(nombre_usuario);
        }
        #endregion
    }
}
