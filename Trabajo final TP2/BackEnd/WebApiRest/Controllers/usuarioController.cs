using BusinessEntities;
using BussinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApiRest.Controllers
{
    public class usuarioController : ApiController
    {
        [HttpPost]
        [Route("Usuarios")]
        public HttpResponseMessage P0005SHPR_USUA(BESHMC_USUA oBe)
        {
            var oBr = new BRSHMC_USUA();
            try
            {
                oBr.P0006SHPR_USUA(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, oBe);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotAcceptable, ex.Message);
            }
        }
    }
}
