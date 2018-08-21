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
    public class visitaController : ApiController
    {
        [HttpPost]
        [Route("Visitas")]
        public HttpResponseMessage P0005SHPR_USUA(BESHMC_VISI oBe)
        {
            var oBr = new BRSHMC_VISI();
            try
            {
                oBr.P0008SHPR_VISI(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, oBe);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
