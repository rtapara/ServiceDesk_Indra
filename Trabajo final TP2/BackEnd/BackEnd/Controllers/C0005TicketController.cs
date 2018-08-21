using BusinessEntities;
using BussinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Net.Mail;

namespace BackEnd.Controllers
{
    public class C0005TicketController : ApiController
    {
        [HttpPost]
        [Route("T0005G0001")]
        public HttpResponseMessage P0005SHPR_TICKET_LIST(TicketEntity oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                if (oBe.TIC_StatDate > oBe.TIC_EndDate)
                {
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "La fecha de inicio no puede mayor a la fecha final.");

                }

                var oBr = new TicketRule();
                var oList = oBr.SHPR_TICKET_LIST(oBe);

                //if (oList.Count == 0)
                //{
                //    Request.CreateErrorResponse(HttpStatusCode.Conflict, "No se encontraron coincidencias para la búsqueda realizada.");

                //}

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("AbrirTicket")]
        public HttpResponseMessage P0005SHPR_TICKET_OPEN_LIST(TicketEntity oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                var oBr = new TicketRule();
                var oList = oBr.SHPR_TICKET_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("TicketHistorical")]
        public HttpResponseMessage SHPR_TICKET_HISTORICAL_LIST(TicketHistoryEntity oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                var oBr = new TicketRule();
                var oList = oBr.SHPR_TICKET_HISTORICAL_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Enterprise")]
        public HttpResponseMessage P0005SHPR_ENTERPRISE_LIST(TicketEntity oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                var oBr = new TicketRule();
                var oList = oBr.SHPR_ENTERPRISE_LIST(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("UserClient")]
        public HttpResponseMessage P0005SHPR_USER_LIST(TicketEntity oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                var oBr = new TicketRule();
                var oList = oBr.SHPR_USER_LIST(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Service")]
        public HttpResponseMessage SHPR_SERVICE_LIST(ServiceEntity oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                var oBr = new TicketRule();
                var oList = oBr.SHPR_SERVICE_LIST(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Status")]
        public HttpResponseMessage SHPR_STATUS_LIST(StatusEntity oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                var oBr = new TicketRule();
                var oList = oBr.SHPR_STATUS_LIST(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("ProblemType")]
        public HttpResponseMessage SHPR_PROBLEM_TYPE_LIST(ProblemTypeEntity oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                var oBr = new TicketRule();
                var oList = oBr.SHPR_PROBLEM_TYPE_LIST(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("Priority")]
        public HttpResponseMessage SHPR_PRIORITY_LIST(PriorityEntity oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                var oBr = new TicketRule();
                var oList = oBr.SHPR_PRIORITY_LIST(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateTicket")]
        public HttpResponseMessage SHPR_CREATE_TICKET(TicketEntity oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                if (oBe.TIC_PRI_Id == 0)
                    throw new ArgumentException("Seleccione una prioridad.");
                if (string.IsNullOrEmpty(oBe.TIC_Descripcion))
                    throw new ArgumentException("Especifique la descripción del ticket.");
                if (oBe.TIC_PRO_Id == 0)
                    throw new ArgumentException("Seleccione un tipo de problema.");
                //if (oBe.TIC_SOL_Id == 0)
                //    throw new ArgumentException("Seleccione un tipo de solución.");
                if (oBe.TIC_SER_Id == 0)
                    throw new ArgumentException("Seleccione un servicio.");
                if (oBe.TIC_EMP_Id == 0)
                    throw new ArgumentException("Seleccione una empresa.");
                if (oBe.TIC_USU_Id == 0)
                    throw new ArgumentException("Seleccione un usuario.");

                var oBr = new TicketRule();
                //oBe.COD_USUA_CREA = (string)HttpContext.Current.Session["username"];
                //oBe.COD_USUA_MODI = (string)HttpContext.Current.Session["username"];
                oBr.SHPR_CREATE_TICKET(oBe);

                //MailMessage mail = new MailMessage("a580@hotmail.com", "sebas.pujalt16@gmail.com");
                //SmtpClient client = new SmtpClient();
                //client.Port = 25;
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.EnableSsl = false; 
                //client.UseDefaultCredentials = false;
                //client.Host = "smtp.gmail.com";
                //mail.Subject = "INDRA TICKET.";
                //mail.Body = "SE ENVIA EL TICKET NUMERO 1";
                //client.Send(mail);


                return Request.CreateResponse(HttpStatusCode.OK, "Operación concretada con éxito.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }


        //ROLY
        //[HttpPost]
        //[Route("T0005G0002")]
        //public HttpResponseMessage P0005SHPR_PRI_LIST(PriorityEntity oBe)
        //{
        //    try
        //    {
        //        if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
        //            return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

        //        var oBr = new TicketRule();
        //        var oList = oBr.SHPR_TICKET_PRI_LIST(oBe);
        //        return Request.CreateResponse(HttpStatusCode.OK, oList);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
        //    }
        //}
        [HttpPost]
        [Route("T0005G0003")]
        public HttpResponseMessage P0005SHPR_PRO_LIST(ProblemTypeEntity oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                var oBr = new TicketRule();
                var oList = oBr.SHPR_TICKET_PRO_LIST(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("T0005G0004")]
        public HttpResponseMessage P0005SHPR_PRO_SOL_LIST(TipoSolucionEntity oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                var oBr = new TicketRule();
                var oList = oBr.SHPR_TICKET_PRO_SOL_LIST(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("T0005G0005")]
        public HttpResponseMessage SHPR_TICKET_EDIT(TicketEntity oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                if (oBe.TIC_CodigoEstado != 2)
                {
                    if (oBe.TIC_SER_Id == 0)
                        throw new ArgumentException("Seleccione un servicio.");
                    if (oBe.TIC_PRO_Id == 0)
                        throw new ArgumentException("Seleccione un problema.");
                    if (oBe.TIC_PRI_Id == 0)
                        throw new ArgumentException("Seleccione una prioridad.");
                    if (string.IsNullOrEmpty(oBe.TIC_Descripcion))
                        throw new ArgumentException("Especifique una descripción.");
                    /*if (string.IsNullOrEmpty(oBe.TIC_USU_RESP_Description))
                        throw new ArgumentException("Especifique un responsable del ticket.");
                      */
                }

                var oBr = new TicketRule();
                /*oBe.COD_USUA_CREA = (string)HttpContext.Current.Session["username"];
                oBe.COD_USUA_MODI = (string)HttpContext.Current.Session["username"];*/
                oBr.SHPR_TICKET_EDIT(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, "Operación concretada con exito.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
        [HttpPost]
        [Route("T0005G0006")]
        public HttpResponseMessage SHPR_TICKET_ATT_INSERT(AttendEntity oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                
                    if (oBe.ATE_FEC_INI == null)
                        throw new ArgumentException("Seleccione una fecha incial.");
                    if (oBe.ATE_FEC_FIN == null)
                        throw new ArgumentException("Seleccione una fecha final.");
                    if (oBe.ATE_DET_TRA.Trim() == "")
                        throw new ArgumentException("Ingrese el procedimiento del trabajo realizado.");
                

                var oBr = new TicketRule();
                oBr.SHPR_TICKET_ATT_INSERT(oBe);
                return Request.CreateResponse(HttpStatusCode.OK, "Operación concretada con exito.");
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        [Route("ConsultarAtencion")]
        public HttpResponseMessage SHPR_TICKET_ATT_LIST(AttendEntity oBe)
        {
            try
            {
                if (string.IsNullOrWhiteSpace((string)HttpContext.Current.Session["username"]))
                    return Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Acceso no autorizado.");

                var oBr = new TicketRule();
                var oList = oBr.SHPR_TICKET_ATT_LIST(oBe);

                return Request.CreateResponse(HttpStatusCode.OK, oList);
            }
            catch (Exception ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        //

    }
}