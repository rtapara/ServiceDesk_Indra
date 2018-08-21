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
    public class ResponsibleRule
    {
        private INDRA_Resposible oDa;
        public ResponsibleRule()
        {
            oDa = new INDRA_Resposible();
        }
        /// <summary>
        /// OBTENER LA LISTA DE COLABORADORES
        /// </summary>
        /// <param name="oBe"></param>
        /// <returns></returns>
        public List<UsuarioResponsableEntity> ListarResponsible(UsuarioResponsableEntity oBe)
        {
            using (var odr = oDa.ListarResponsible(oBe))
            {
                var oList = new List<UsuarioResponsableEntity>();
                ((IList)oList).LoadFromReader<UsuarioResponsableEntity>(odr);
                return (oList);
            }
        }

    }
}
