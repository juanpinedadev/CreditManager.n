using System;

namespace Entidades
{
    public class Pago
    {
        public int Id { get; set; }
        public Cuota Cuota { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
    }
}
