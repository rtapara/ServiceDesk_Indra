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
    public class BRSHMC_TIPO_USUA
    {
        private DASHMC_TIPO_USUA oDa;
        public BRSHMC_TIPO_USUA()
        {
            oDa = new DASHMC_TIPO_USUA();
        }
        /// <summary>
        /// OBTENER LA LISTA DE TIPOS DE USUARIO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESHMC_TIPO_USUA> P0004SHPR_TIPO_USUA_LIST(BESHMC_TIPO_USUA oBe)
        {
            using (var odr = oDa.P0004SHPR_TIPO_USUA_LIST(oBe))
            {
                var oList = new List<BESHMC_TIPO_USUA>();
                ((IList)oList).LoadFromReader<BESHMC_TIPO_USUA>(odr);
                return (oList);
            }
        }
    }
}
