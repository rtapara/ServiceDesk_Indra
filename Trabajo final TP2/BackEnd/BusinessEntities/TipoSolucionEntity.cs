using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class TipoSolucionEntity
    {
        public int? SOL_Id { get; set; }
        public int? SOL_PROD_Id { get; set; }
        public string SOL_Descripcion { get; set; }
        public string SOL_RutaArchivo { get; set; }
    }
}
