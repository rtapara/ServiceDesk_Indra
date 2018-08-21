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
    public class DASHMC_VISI
    {
        private DAGenerics oDg;
        private Database oDb;
        private DbConnection oCon;
        /// <summary>
        /// CONTRUCTOR DE LA CLASE
        /// </summary>
        public DASHMC_VISI()
        {
            oDg = new DAGenerics("manager");
        }
        /// <summary>
        /// GENERAR VISITA
        /// </summary>
        /// <param name="oBe"></param>
        public void P0008SHPR_VISI(BESHMC_VISI oBe)
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
                        using (var ocmd = oDb.GetStoredProcCommand("P0008SHPR_VISI",    oBe.COD_VISI,
                                                                                        oBe.COD_AGEN,
	                                                                                    oBe.COD_MORO,
	                                                                                    oBe.FEC_VISI,
	                                                                                    oBe.ALF_GPSS_PART,
	                                                                                    oBe.ALF_GPSS_LLEG,
	                                                                                    oBe.COD_USUA_CREA,
	                                                                                    oBe.NUM_ACCI))
                        {
                            ocmd.CommandTimeout = 2000;
                            oDb.ExecuteNonQuery(ocmd, obts);
                            oBe.COD_VISI = Convert.ToInt32(oDb.GetParameterValue(ocmd, "@P0008COD_VISI"));
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
