using System;

namespace Entidades
{
    public class HistorialPago
    {
        public int Id { get; set; }
        public Pago Pago { get; set; }
        public Cuota Cuota { get; set; }
        public decimal Monto { get; set; }
        public DateTime FechaPago { get; set; }
        public string EstadoPrestamo { get; set; }
        public string EstadoPago { get; set; }
    }
}
