using System;

namespace Entidades
{
    public class Prestamo
    {
        public int Id { get; set; }
        public FrecuenciaPago FrecuenciaPrestamo { get; set; }
        public Cliente Cliente { get; set; }
        public Empleado Empleado { get; set; }
        public decimal MontoSolicitado { get; set; }
        public decimal TotalIntereses { get; set; }
        public decimal TotalPagar { get; set; }
        public decimal TasaInteres { get; set; }
        public string Estado { get; set; }
        public int NumeroCuotas { get; set; }
        public DateTime FechaPrestamo { get; set; }
        public DateTime FechaVencimiento { get; set; }
    }
}
