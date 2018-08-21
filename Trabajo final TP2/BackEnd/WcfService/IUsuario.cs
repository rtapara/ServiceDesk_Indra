using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using BusinessEntities;
using BussinessRules;

namespace WcfService
{
    [ServiceContract]
    public interface IUsuario
    {
        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "Usuarios",RequestFormat=WebMessageFormat.Json, ResponseFormat = WebMessageFormat.Json)]
        BESHMC_USUA_SOAA ValidarUsuario(BESHMC_USUA_SOAA oBe);
    }
}
