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
    public class DASHMC_REPO
    {
        private DAGenerics oDg;
        private Database oDb;
        private DbConnection oCon;
        /// <summary>
        /// CONTRUCTOR DE LA CLASE
        /// </summary>
        public DASHMC_REPO()
        {
            oDg = new DAGenerics("manager");
        }
        /// <summary>
        /// GENERAR REPORTE
        /// </summary>
        /// <param name="oBe"></param>
        public void P0009SHPR_REPO(BESHMC_REPO oBe)
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
                        using (var ocmd = oDb.GetStoredProcCommand("P0009SHPR_REPO", oBe.COD_REPO,
                                                                                        oBe.COD_VISI,
                                                                                        oBe.FEC_REPO,
                                                                                        oBe.ALF_REPO,
                                                                                        oBe.COD_USUA_CREA,
                                                                                        oBe.NUM_ACCI))
                        {
                            ocmd.CommandTimeout = 2000;
                            oDb.ExecuteNonQuery(ocmd, obts);
                            oBe.COD_REPO = Convert.ToInt32(oDb.GetParameterValue(ocmd, "@P0009COD_REPO"));
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
