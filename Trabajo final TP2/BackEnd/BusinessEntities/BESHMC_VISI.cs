using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class BESHMC_VISI
    {
        public int COD_VISI { get; set; }
        public int COD_CAMP { get; set; }
        public int COD_AGEN { get; set; }
        public int COD_MORO { get; set; }
        public DateTime? FEC_VISI { get; set; }
        public string ALF_GPSS_PART { get; set; }
        public string ALF_GPSS_LLEG { get; set; }
        public string COD_USUA_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }
        public int NUM_ACCI { get; set; }
    }
}
