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
    public class DASHMC_TIPO_USUA
    {
        private DAGenerics oDg;
        private Database oDb;
        private DbConnection oCon;
        /// <summary>
        /// CONTRUCTOR DE LA CLASE
        /// </summary>
        public DASHMC_TIPO_USUA()
        {
            oDg = new DAGenerics("manager");
        }
        /// <summary>
        /// OBTENER LA LISTA DE COLABORADORES
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public IDataReader P0004SHPR_TIPO_USUA_LIST(BESHMC_TIPO_USUA oBe)
        {
            try
            {
                oDb = oDg.getDataBase();
                oCon = oDg.getConnection();
                if (oCon.State == ConnectionState.Closed) oCon.Open();
                var ocmd = oDb.GetStoredProcCommand("P0004SHPR_TIPO_USUA_LIST", oBe.COD_TIPO_USUA,
                                                                                oBe.ALF_TIPO_USUA,
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
    }
}
