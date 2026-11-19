
namespace DSWI_T1_Grupo11.Models
{
    public class DescuentoMoto
    {
        public decimal PrecioMoto { get; set; } = 6000m;

        public decimal DescuentoMartes => PrecioMoto * 0.12m;
        public decimal DescuentoSabado => PrecioMoto * 0.18m;
        public decimal DescuentoFeriado => PrecioMoto * 0.25m;

        public decimal TotalMartes => PrecioMoto - DescuentoMartes;
        public decimal TotalSabado => PrecioMoto - DescuentoSabado;
        public decimal TotalFeriado => PrecioMoto - DescuentoFeriado;
    }
}
