using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class BESHMC_REPO
    {
        public int COD_VISI { get; set; }
        public int COD_REPO { get; set; }
        public DateTime? FEC_REPO { get; set; }
        public string ALF_REPO { get; set; }
        public string COD_USUA_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }
        public int NUM_ACCI { get; set; }
    }
}
