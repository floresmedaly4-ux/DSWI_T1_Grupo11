
namespace DSWI_T1_Grupo11.Models
{
    public class ConsumoElectrico
    {
        public decimal KwhConsumidos { get; set; }

        public decimal Subtotal
        {
            get
            {
                decimal consumo = KwhConsumidos;

                if (consumo <= 100)
                {
                    return consumo * 0.10m;
                }
                else if (consumo <= 250)
                {
                    return 100 * 0.10m
                         + (consumo - 100) * 0.15m;
                }
                else
                {
                    return 100 * 0.10m
                         + 150 * 0.15m
                         + (consumo - 250) * 0.22m;
                }
            }
        }

        public decimal PorcentajeImpuesto =>
            KwhConsumidos > 500 ? 0.08m : 0.03m;

        public decimal Impuesto =>
            Subtotal * PorcentajeImpuesto;

        public decimal TotalPagar =>
            Subtotal + Impuesto;
    }
}
