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
    public class BRSHMC_USUA
    {
        private DASHMC_USUA oDa;
        public BRSHMC_USUA()
        {
            oDa = new DASHMC_USUA();
        }
        /// <summary>
        /// OBTENER EL USUARIO LOGEADO
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESHMC_USUA> P0001SHPR_USUA_LIST(BESHMC_USUA oBe)
        {
            using (var odr = oDa.P0001SHPR_USUA_LIST(oBe))
            {
                var oList = new List<BESHMC_USUA>();
                ((IList)oList).LoadFromReader<BESHMC_USUA>(odr);
                return (oList);
            }
        }
        /// <summary>
        /// OBTENER LA LISTA DE USUARIOS
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<BESHMC_USUA> P0002SHPR_USUA_LIST(BESHMC_USUA oBe)
        {
            using (var odr = oDa.P0002SHPR_USUA_LIST(oBe))
            {
                var oList = new List<BESHMC_USUA>();
                ((IList)oList).LoadFromReader<BESHMC_USUA>(odr);
                return (oList);
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
                oDa.P0005SHPR_USUA(oBe);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
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
                oDa.P0006SHPR_USUA(oBe);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
