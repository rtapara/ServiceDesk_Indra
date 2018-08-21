using BusinessEntities;
using DataAccess;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ResultSetMappers;

namespace BussinessRules
{
    public class TicketRule
    {
        private INDRA_Ticket oDa;
        public TicketRule()
        {
            oDa = new INDRA_Ticket();
        }

        /// <summary>
        /// OBTENER LA LISTA DE TICKETS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<TicketEntity> SHPR_TICKET_LIST(TicketEntity oBe)
        {
            using (var odr = oDa.SHPR_TICKET_LIST(oBe))
            {
                var oList = new List<TicketEntity>();
                ((IList)oList).LoadFromReader<TicketEntity>(odr);
                return (oList);
            }
        }

        /// <summary>
        /// OBTENER LA LISTA DE HISTORIAL TICKETS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<TicketHistoryEntity> SHPR_TICKET_HISTORICAL_LIST(TicketHistoryEntity oBe)
        {
            using (var odr = oDa.SHPR_TICKET_HISTORY_LIST(oBe))
            {
                var oList = new List<TicketHistoryEntity>();
                ((IList)oList).LoadFromReader<TicketHistoryEntity>(odr);
                return (oList);
            }
        }

        /// <summary>
        /// OBTENER LA LISTA DE TICKETS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<TicketEntity> SHPR_ENTERPRISE_LIST(TicketEntity oBe)
        {
            using (var odr = oDa.SHPR_ENTERPRISE_LIST(oBe))
            {
                var oList = new List<TicketEntity>();
                ((IList)oList).LoadFromReader<TicketEntity>(odr);
                return (oList);
            }
        }

        /// <summary>
        /// OBTENER LA LISTA DE TICKETS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<TicketEntity> SHPR_USER_LIST(TicketEntity oBe)
        {
            using (var odr = oDa.SHPR_USER_CLIENT_LIST(oBe))
            {
                var oList = new List<TicketEntity>();
                ((IList)oList).LoadFromReader<TicketEntity>(odr);
                return (oList);
            }
        }

        /// <summary>
        /// OBTENER LA LISTA DE SERVICIOS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<ServiceEntity> SHPR_SERVICE_LIST(ServiceEntity oBe)
        {
            using (var odr = oDa.SHPR_SERVICE_LIST(oBe))
            {
                var oList = new List<ServiceEntity>();
                ((IList)oList).LoadFromReader<ServiceEntity>(odr);
                return (oList);
            }
        }

        /// <summary>
        /// OBTENER LA LISTA DE ESTADOS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<StatusEntity> SHPR_STATUS_LIST(StatusEntity oBe)
        {
            using (var odr = oDa.SHPR_STATUS_LIST(oBe))
            {
                var oList = new List<StatusEntity>();
                ((IList)oList).LoadFromReader<StatusEntity>(odr);
                return (oList);
            }
        }

        /// <summary>
        /// OBTENER LOS TIPOS DE PROBLEMA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<ProblemTypeEntity> SHPR_PROBLEM_TYPE_LIST(ProblemTypeEntity oBe)
        {
            using (var odr = oDa.SHPR_PROBLEM_TYPE_LIST(oBe))
            {
                var oList = new List<ProblemTypeEntity>();
                ((IList)oList).LoadFromReader<ProblemTypeEntity>(odr);
                return (oList);
            }
        }

        public List<ProblemTypeEntity> SHPR_TICKET_PRO_LIST(ProblemTypeEntity oBe)
        {
            using (var odr = oDa.SHPR_TICKET_PRO(oBe))
            {
                var oList = new List<ProblemTypeEntity>();
                ((IList)oList).LoadFromReader<ProblemTypeEntity>(odr);
                return (oList);
            }
        }

        /// <summary>
        /// OBTENER LAS PRIORIDADES
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<PriorityEntity> SHPR_PRIORITY_LIST(PriorityEntity oBe)
        {
            using (var odr = oDa.SHPR_PRIORITY_LIST(oBe))
            {
                var oList = new List<PriorityEntity>();
                ((IList)oList).LoadFromReader<PriorityEntity>(odr);
                return (oList);
            }
        }

        /// <summary>
        /// REGISTRO DE TICKET
        /// </summary>
        /// <param name="oBe"></param>
        public void SHPR_CREATE_TICKET(TicketEntity oBe)
        {
            try
            {
                oDa.SHPR_CREATE_TICKET(oBe);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        //public List<ProblemTypeEntity> SHPR_TICKET_PRO_LIST(ProblemTypeEntity oBe)
        //{
        //    using (var odr = oDa.SHPR_TICKET_PRO(oBe))
        //    {
        //        var oList = new List<ProblemTypeEntity>();
        //        ((IList)oList).LoadFromReader<ProblemTypeEntity>(odr);
        //        return (oList);
        //    }
        //}

        public List<TipoSolucionEntity> SHPR_TICKET_PRO_SOL_LIST(TipoSolucionEntity oBe)
        {
            using (var odr = oDa.SHPR_TICKET_PRO_SOL(oBe))
            {
                var oList = new List<TipoSolucionEntity>();
                ((IList)oList).LoadFromReader<TipoSolucionEntity>(odr);
                return (oList);
            }
        }

        public void SHPR_TICKET_EDIT(TicketEntity oBe)
        {
            try
            {
                oDa.SHPR_TICKET_EDIT(oBe);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
        public void SHPR_TICKET_ATT_INSERT(AttendEntity oBe)
        {
            try
            {
                oDa.SHPR_TICKET_ATT_INSERT(oBe);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }

        public List<AttendEntity> SHPR_TICKET_ATT_LIST(AttendEntity oBe)
        {
            using (var odr = oDa.SHPR_TICKET_ATT_LIST(oBe))
            {
                var oList = new List<AttendEntity>();
                ((IList)oList).LoadFromReader<AttendEntity>(odr);
                return (oList);
            }
        }

    }
}
