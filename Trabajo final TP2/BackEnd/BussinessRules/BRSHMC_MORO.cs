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
    public class BRSHMC_MORO
    {
        private DASHMC_MORO oDa;
        public BRSHMC_MORO()
        {
            oDa = new DASHMC_MORO();
        }
        /// <summary>
        /// OBTENER LA LISTA DE COLABORADORES
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESHMC_AGEN> P0007SHPR_MORO_LIST(BESHMC_MORO oBe)
        {
            using (var odr = oDa.P0007SHPR_MORO_LIST(oBe))
            {
                var oList = new List<BESHMC_AGEN>();
                ((IList)oList).LoadFromReader<BESHMC_AGEN>(odr);
                return (oList);
            }
        }
    }
}
