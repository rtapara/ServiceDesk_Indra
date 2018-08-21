using BusinessEntities;
using BussinessRules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace WcfService
{
    public class Usuario : IUsuario
    {
        public BRSHMC_USUA oBr = new BRSHMC_USUA();
        public BESHMC_USUA_SOAA ValidarUsuario(BESHMC_USUA_SOAA oBe)
        {
            try
            {
                oBr.P0006SHPR_USUA(oBe);
                return oBe;
            }
            catch (Exception ex)
            {
                throw new WebFaultException<string>(ex.Message, HttpStatusCode.NotAcceptable);
            }
        }
    }
}
