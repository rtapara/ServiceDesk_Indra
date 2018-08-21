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
    public class BRSHMC_REPO
    {
        private DASHMC_REPO oDa;
        public BRSHMC_REPO()
        {
            oDa = new DASHMC_REPO();
        }
        /// <summary>
        /// AGREGAR REPORTE
        /// </summary>
        /// <param name="oBe"></param>
        public void P0009SHPR_REPO(BESHMC_REPO oBe)
        {
            try
            {
                oDa.P0009SHPR_REPO(oBe);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
