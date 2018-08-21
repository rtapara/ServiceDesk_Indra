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
    public class BRSHMC_VISI
    {
        private DASHMC_VISI oDa;
        public BRSHMC_VISI()
        {
            oDa = new DASHMC_VISI();
        }
        /// <summary>
        /// AGREGAR VISITA
        /// </summary>
        /// <param name="oBe"></param>
        public void P0008SHPR_VISI(BESHMC_VISI oBe)
        {
            try
            {
                oDa.P0008SHPR_VISI(oBe);
            }
            catch (Exception ex)
            {
                throw new ArgumentException(ex.Message);
            }
        }
    }
}
