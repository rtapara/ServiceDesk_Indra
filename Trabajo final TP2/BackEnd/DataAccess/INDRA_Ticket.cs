using BusinessEntities;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class INDRA_Ticket
    {
        private DAGenerics oDg;
        private Database oDb;
        private DbConnection oCon;
        /// <summary>
        /// CONTRUCTOR DE LA CLASE
        /// </summary>
        public INDRA_Ticket()
        {
            oDg = new DAGenerics("manager");
        }

        /// <summary>
        /// OBTENER LA LISTA DE TICKETS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public IDataReader SHPR_TICKET_LIST(TicketEntity oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                //var ocmd = oDb.GetStoredProcCommand("up_ConsultarTicket_Sebastian", oBe.TIC_Id,
                var ocmd = oDb.GetStoredProcCommand("up_ConsultarTicket", oBe.TIC_Id,
                                                                            oBe.EMP_RazonSocial,
                                                                            oBe.TIC_StatDate,
                                                                            oBe.TIC_EndDate,
                                                                            oBe.TIC_CodigoEstado);
                ocmd.CommandTimeout = 2000;
                var odr = oDb.ExecuteReader(ocmd);
                return (odr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCon.Close();
            }
        }

        /// <summary>
        /// OBTENER LA LISTA DE HISTORIAL DE TICKETS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public IDataReader SHPR_TICKET_HISTORY_LIST(TicketHistoryEntity oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var ocmd = oDb.GetStoredProcCommand("up_ConsultarHistorialTicket", oBe.TIC_Id);
                ocmd.CommandTimeout = 2000;
                var odr = oDb.ExecuteReader(ocmd);
                return (odr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCon.Close();
            }
        }

        /// <summary>
        /// OBTENER LA LISTA DE EMPRESAS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public IDataReader SHPR_ENTERPRISE_LIST(TicketEntity oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var ocmd = oDb.GetStoredProcCommand("usp_Empresa", oBe.EMP_RazonSocial);
                ocmd.CommandTimeout = 2000;
                var odr = oDb.ExecuteReader(ocmd);
                return (odr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCon.Close();
            }
        }

        /// <summary>
        /// OBTENER LA LISTA DE USUARIOS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public IDataReader SHPR_USER_CLIENT_LIST(TicketEntity oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var ocmd = oDb.GetStoredProcCommand("usp_UsuarioCliente", oBe.TIC_USU_CLIENT_Description);
                ocmd.CommandTimeout = 2000;
                var odr = oDb.ExecuteReader(ocmd);
                return (odr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCon.Close();
            }
        }

        /// <summary>
        /// OBTENER LA LISTA DE TICKETS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public IDataReader SHPR_SERVICE_LIST(ServiceEntity oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var ocmd = oDb.GetStoredProcCommand("usp_Servicios");
                ocmd.CommandTimeout = 2000;
                var odr = oDb.ExecuteReader(ocmd);
                return (odr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCon.Close();
            }
        }

        /// <summary>
        /// OBTENER LA LISTA DE ESTADOS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public IDataReader SHPR_STATUS_LIST(StatusEntity oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var ocmd = oDb.GetStoredProcCommand("up_ListarEstado");
                ocmd.CommandTimeout = 2000;
                var odr = oDb.ExecuteReader(ocmd);
                return (odr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCon.Close();
            }
        }

        /// <summary>
        /// OBTENER LA LISTA DE TIPOS DE PROBLEMA
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public IDataReader SHPR_PROBLEM_TYPE_LIST(ProblemTypeEntity oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var ocmd = oDb.GetStoredProcCommand("usp_TipoProblema");
                ocmd.CommandTimeout = 2000;
                var odr = oDb.ExecuteReader(ocmd);
                return (odr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCon.Close();
            }
        }

        /// <summary>
        /// OBTENER LA LISTA DE PRIORIDADES
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public IDataReader SHPR_PRIORITY_LIST(PriorityEntity oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var ocmd = oDb.GetStoredProcCommand("usp_Prioridad");
                ocmd.CommandTimeout = 2000;
                var odr = oDb.ExecuteReader(ocmd);
                return (odr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCon.Close();
            }
        }

        /// <summary>
        /// REGISTRO DE TICKETS
        /// </summary>
        /// <param name="oBe"></param>
        public void SHPR_CREATE_TICKET(TicketEntity oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                using (var obts = oCon.BeginTransaction())
                {
                    try
                    {
                        using (var ocmd = oDb.GetStoredProcCommand("usp_InsertTicket",
                                                                                oBe.TIC_PRI_Id,
                                                                                oBe.TIC_PRO_Id,
                                                                                1,
                                                                                oBe.TIC_SER_Id,
                                                                                oBe.TIC_EMP_Id,
                                                                                oBe.TIC_USU_Id,
                                                                                oBe.TIC_Descripcion,
                                                                                1))
                        {
                            ocmd.CommandTimeout = 2000;
                            oDb.ExecuteNonQuery(ocmd, obts);
                            //oBe.NUM_TOKE = Convert.ToInt32(oDb.GetParameterValue(ocmd, "@P0005NUM_TOKE"));
                            obts.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        obts.Rollback();
                        throw new ArgumentException(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                oCon.Close();
            }
        }


        // roly


        public IDataReader SHPR_TICKET_PRO(ProblemTypeEntity oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var ocmd = oDb.GetStoredProcCommand("up_ListarTipoProblema", oBe.PRO_Id, oBe.SER_Id);
                ocmd.CommandTimeout = 2000;
                var odr = oDb.ExecuteReader(ocmd);
                return (odr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCon.Close();
            }

            //
        }

        public IDataReader SHPR_TICKET_PRO_SOL(TipoSolucionEntity oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var ocmd = oDb.GetStoredProcCommand("up_ListarSolucion", oBe.SOL_PROD_Id);
                ocmd.CommandTimeout = 2000;
                var odr = oDb.ExecuteReader(ocmd);
                return (odr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCon.Close();
            }
        }

        public void SHPR_TICKET_EDIT(TicketEntity oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                using (var obts = oCon.BeginTransaction())
                {
                    try
                    {
                        using (var ocmd = oDb.GetStoredProcCommand("up_ActualizarTicket",
                                                                                oBe.TIC_Id,
                                                                                oBe.TIC_SER_Id,
                                                                                oBe.TIC_PRO_Id,
                                                                                oBe.TIC_PRI_Id,
                                                                                oBe.TIC_USU_RESP_Id,
                                                                                oBe.TIC_Descripcion,
                                                                                oBe.TIC_CodigoEstado))
                        {
                            ocmd.CommandTimeout = 2000;
                            oDb.ExecuteNonQuery(ocmd, obts);
                            obts.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        obts.Rollback();
                        throw new ArgumentException(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                oCon.Close();
            }
        }
        public void SHPR_TICKET_ATT_INSERT(AttendEntity oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                using (var obts = oCon.BeginTransaction())
                {
                    try
                    {
                        using (var ocmd = oDb.GetStoredProcCommand("up_RegistrarAtencion",
                                                                                oBe.ATE_TIC_Id,
                                                                                oBe.ATE_FEC_INI,
                                                                                oBe.ATE_FEC_FIN,
                                                                                oBe.ATE_FLAG_RES,
                                                                                oBe.ATE_DET_TRA))
                        {
                            ocmd.CommandTimeout = 2000;
                            oDb.ExecuteNonQuery(ocmd, obts);
                            obts.Commit();
                        }
                    }
                    catch (Exception ex)
                    {
                        obts.Rollback();
                        throw new ArgumentException(ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
            finally
            {
                oCon.Close();
            }
        }

        public IDataReader SHPR_TICKET_ATT_LIST(AttendEntity oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                //var ocmd = oDb.GetStoredProcCommand("up_ConsultarTicket_Sebastian", oBe.TIC_Id,
                var ocmd = oDb.GetStoredProcCommand("up_ConsultarAtencion", oBe.ATE_Id);
                ocmd.CommandTimeout = 2000;
                var odr = oDb.ExecuteReader(ocmd);
                return (odr);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                oCon.Close();
            }
        }


    }
}
