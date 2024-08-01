using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Copayment_prueba.Controllers
{
    public class UsuarioController : ApiController
    {
        [HttpGet]
        [Route("api/usuario/default")]
        public IHttpActionResult GetDefault()
        {
            return Ok("Default endpoint para el controlador Usuario");
        }
    }
}
