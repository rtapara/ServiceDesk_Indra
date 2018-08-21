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
    public class BRSHMC_AGEN
    {
        private DASHMC_AGEN oDa;
        public BRSHMC_AGEN()
        {
            oDa = new DASHMC_AGEN();
        }
        /// <summary>
        /// OBTENER LA LISTA DE COLABORADORES
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESHMC_AGEN> P0003SHPR_AGEN_LIST(BESHMC_AGEN oBe)
        {
            using (var odr = oDa.P0003SHPR_AGEN_LIST(oBe))
            {
                var oList = new List<BESHMC_AGEN>();
                ((IList)oList).LoadFromReader<BESHMC_AGEN>(odr);
                return (oList);
            }
        }
    }
}
