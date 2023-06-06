using System;

namespace Entidades
{
    public class Cuota
    {
        public int Id { get; set; }
        public Prestamo Prestamo { get; set; }
        public decimal MontoCuota { get; set; }
        public string EstadoCuota { get; set; }
        public string Estado { get; set; }
        public DateTime? FechaPago { get; set; }
        public DateTime FechaVencimiento { get; set; }
        public bool Pagada { get; set; }
    }
}
