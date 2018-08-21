using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class UsuarioResponsableEntity
    {
        public int? RES_Id { get; set; }
        public string RES_IdLogin { get; set; }
        public string RES_Nombre { get; set; }
        public string RES_ApellidoPaterno { get; set; }
        public string RES_ApellidoMaterno { get; set; }
        public string USU_RESP_Description { get; set; }
        public string RES_Email { get; set; }

    }
}
