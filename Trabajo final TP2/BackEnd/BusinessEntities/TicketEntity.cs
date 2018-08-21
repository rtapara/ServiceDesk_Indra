using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessEntities
{
    public class TicketEntity
    {
        public int? TIC_Id { get; set; }
        public string TIC_Code { get; set; }
        public int TIC_PRI_Id { get; set; }
        public int TIC_PRO_Id { get; set; }
        public int TIC_SOL_Id { get; set; }
        public int TIC_SER_Id { get; set; }
        public int TIC_EMP_Id { get; set; }
        public int EMP_Id { get; set; }
        public int TIC_USU_Id { get; set; }
        public string TIC_Descripcion { get; set; }
        public DateTime TIC_FechaRegistro { get; set; }
        public DateTime TIC_FechaCierre { get; set; }
        public Int16? TIC_CodigoEstado { get; set; }
        public string EMP_RazonSocial { get; set; }
        public DateTime? TIC_StatDate { get; set; }
        public DateTime? TIC_EndDate { get; set; }
        public string TIC_USU_Description { get; set; }
        public string TIC_USU_RESP_Description { get; set; }
        public string StatusName { get; set; }
        public string TIC_FechaRegistroDescription { get; set; }
        public decimal EMP_RUC { get; set; }
        public string TIC_USU_CLIENT_Description { get; set; }
        public int USU_Id { get; set; }
        public string TIC_PRI_Description { get; set; }
        public int TIC_USU_RESP_Id { get; set; }
        public int RST_Id { get; set; }
        public string ATE_FechaAtencion { get; set; }
        public string SER_Descripcion { get; set; }
        public int? SER_Id { get; set; }

    }
}
