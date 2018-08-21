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
    public class C0001ColaboratorController : ApiController
    {
        [HttpPost]
        [Route("C0001G0001")]
        public HttpResponseMessage P0003SHPR_AGEN_LIST(BESHMC_AGEN oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                var oBr = new BRSHMC_AGEN();
                var oList = oBr.P0003SHPR_AGEN_LIST(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
