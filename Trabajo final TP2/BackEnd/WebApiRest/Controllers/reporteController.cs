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
    public class reporteController : ApiController
    {
        [HttpPost]
        [Route("Reportes")]
        public HttpResponseMessage P0009SHPR_REPO(BESHMC_REPO oBe)
        {
            var oBr = new BRSHMC_REPO();
            try
            {
                oBr.P0009SHPR_REPO(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, oBe);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
