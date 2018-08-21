using BusinessEntities;
using BussinessRules;
using System;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace BackEnd.Controllers
{
    public class C0002LoginController : ApiController
    {
        [HttpPost]
        [Route("C0002G0001")]
        public HttpResponseMessage P0001SHPR_USUA_LIST(BESHMC_USUA oBe)
        {
            try
            {
                var oBr = new BRSHMC_USUA();
                var oList = oBr.P0001SHPR_USUA_LIST(oBe);
                if (oList.Count == 0)
                    throw new ArgumentException("Credenciales de usuario invalidas.");
                HttpContext.Current.Session["username"] = oBe.COD_USUA;
                return Request.CreateResponse(HttpStatusCode.OK, oBe);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("C0002G0002")]
        public HttpResponseMessage GET_SESSION()
        {
            try
            {
                var user = (string)HttpContext.Current.Session["username"];
                if (string.IsNullOrWhiteSpace(user))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("C0002G0003")]
        public HttpResponseMessage DESTROY_SESSION()
        {
            try
            {
                HttpContext.Current.Session["username"] = null;

                return Request.CreateResponse(HttpStatusCode.OK, "OK");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
