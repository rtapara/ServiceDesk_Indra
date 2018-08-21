using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class AttendEntity
    {
        public int ATE_Id { get; set; }
        public int ATE_TIC_Id { get; set; }
        public DateTime? ATE_FEC_INI { get; set; }
        public DateTime? ATE_FEC_FIN { get; set; }
        public Boolean ATE_FLAG_RES { get; set; }
        public string ATE_DET_TRA { get; set; }

        public string TIC_Code { get; set; }
        public string TIC_Descripcion { get; set; }
        public string RST_Descripcion { get; set; }

    }
}
