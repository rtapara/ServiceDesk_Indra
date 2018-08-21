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
    public class C0006ResponsibleController : ApiController
    {
        [HttpPost]
        [Route("C0006G0001")]
        public HttpResponseMessage ListarResponsible(UsuarioResponsableEntity oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                var oBr = new ResponsibleRule();
                var oList = oBr.ListarResponsible(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}