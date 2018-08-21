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
    public class DASHMC_USUA
    {
        private DAGenerics oDg;
        private Database oDb;
        private DbConnection oCon;
        /// <summary>
        /// CONTRUCTOR DE LA CLASE
        /// </summary>
        public DASHMC_USUA()
        {
            oDg = new DAGenerics("manager");
        }
        /// <summary>
        /// OBTENER EL USUARIO LOGEADO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public IDataReader P0001SHPR_USUA_LIST(BESHMC_USUA oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var ocmd = oDb.GetStoredProcCommand("P0001SHPR_USUA_LIST", oBe.COD_USUA,
                                                                            oBe.ALF_PASS,
                                                                            oBe.NUM_ACCI);
                ocmd.CommandTimeout = 2000;
                var odr = oDb.ExecuteReader(ocmd);
                return (odr);
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
        public IDataReader P0002SHPR_USUA_LIST(BESHMC_USUA oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var ocmd = oDb.GetStoredProcCommand("P0002SHPR_USUA_LIST", oBe.COD_USUA, 
                                                                            oBe.NUM_ACCI);
                ocmd.CommandTimeout = 2000;
                var odr = oDb.ExecuteReader(ocmd);
                return (odr);
            }
            finally
            {
                oCon.Close();
            }
        }
        /// <summary>
        /// ACTUALIZAR REGISTRO DE USUARIOS
        /// </summary>
        /// <param name="oBe"></param>
        public void P0005SHPR_USUA(BESHMC_USUA oBe)
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
                        using (var ocmd = oDb.GetStoredProcCommand("P0005SHPR_USUA",
                                                                                oBe.COD_AGEN,
                                                                                oBe.COD_USUA,
                                                                                oBe.ALF_PASS,
                                                                                oBe.COD_TIPO_USUA,
                                                                                oBe.IND_ACTI,
                                                                                oBe.NUM_TOKE,
                                                                                oBe.COD_USUA_CREA,
                                                                                oBe.COD_USUA_MODI,
                                                                                oBe.NUM_ACCI))
                        {
                            ocmd.CommandTimeout = 2000;
                            oDb.ExecuteNonQuery(ocmd, obts);
                            oBe.NUM_TOKE = Convert.ToInt32(oDb.GetParameterValue(ocmd, "@P0005NUM_TOKE"));
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
        /// <summary>
        /// ACTUALIZAR REGISTRO DE USUARIOS DESDE MOBILE
        /// </summary>
        /// <param name="oBe"></param>
        public void P0006SHPR_USUA(BESHMC_USUA oBe)
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
                        using (var ocmd = oDb.GetStoredProcCommand("P0006SHPR_USUA",
                                                                                oBe.COD_USUA,
                                                                                oBe.NUM_TOKE))
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
    }
}
