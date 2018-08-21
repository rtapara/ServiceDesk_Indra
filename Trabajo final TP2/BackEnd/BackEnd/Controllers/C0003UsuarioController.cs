using BusinessEntities;
using BussinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class C0003UsuarioController : ApiController
    {
        [HttpPost]
        [Route("C0003G0001")]
        public HttpResponseMessage P0002SHPR_USUA_LIST(BESHMC_USUA oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                var oBr = new BRSHMC_USUA();
                var oList = oBr.P0002SHPR_USUA_LIST(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        private void ResulsetMapper()
        {
 
        }

        [HttpPost]
        [Route("C0003S0002")]
        public HttpResponseMessage P0005SHPR_USUA(BESHMC_USUA oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                if (oBe.COD_AGEN == 0)
                    throw new ArgumentException("Seleccione un colaborador.");
                if (string.IsNullOrEmpty(oBe.COD_USUA))
                    throw new ArgumentException("Especifique un nombre de usuario.");
                if (string.IsNullOrEmpty(oBe.ALF_PASS))
                    throw new ArgumentException("La contraseña no puede ser un datos en blanco.");
                if (!oBe.ALF_PASS.Equals(oBe.ALF_PASS_REPE))
                    throw new ArgumentException("Las contraseñas no coinciden.");
                if (oBe.COD_TIPO_USUA == 0)
                    throw new ArgumentException("Seleccione un tipo de usuario.");

                var oBr = new BRSHMC_USUA();
                oBe.COD_USUA_CREA = (string)HttpContext.Current.Session["username"];
                oBe.COD_USUA_MODI = (string)HttpContext.Current.Session["username"];
                oBr.P0005SHPR_USUA(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, "Operación concretada con exito.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
