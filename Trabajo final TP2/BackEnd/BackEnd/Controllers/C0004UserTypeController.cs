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
    public class C0004UserTypeController : ApiController
    {
        [HttpPost]
        [Route("C0004G0001")]
        public HttpResponseMessage P0004SHPR_TIPO_USUA_LIST(BESHMC_TIPO_USUA oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                var oBr = new BRSHMC_TIPO_USUA();
                var oList = oBr.P0004SHPR_TIPO_USUA_LIST(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
