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
    public class morosoController : ApiController
    {
        [HttpPost]
        [Route("Morosos")]
        public HttpResponseMessage P0005SHPR_USUA(BESHMC_MORO oBe)
        {
            var oBr = new BRSHMC_MORO();
            try
            {
                var oList = oBr.P0007SHPR_MORO_LIST(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
