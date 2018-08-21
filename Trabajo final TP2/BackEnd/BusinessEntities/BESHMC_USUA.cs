using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace BusinessEntities
{
    public class BESHMC_USUA
    {
        public BESHMC_AGEN OBJ_AGEN { get; set; }
        public string COD_USUA { get; set; }
        public string ALF_PASS { get; set; }
        public string ALF_PASS_REPE { get; set; }
        public int COD_AGEN { get; set; }
        public int COD_TIPO_USUA { get; set; }
        public string ALF_AGEN { get; set; }
        public string ALF_DNII { get; set; }
        public string ALF_DIRE { get; set; }
        public int NUM_TOKE { get; set; }
        public bool IND_ACTI { get; set; }
        public string COD_USUA_CREA { get; set; }
        public string COD_USUA_MODI { get; set; }
        public int NUM_ACCI { get; set; }
    }
}
