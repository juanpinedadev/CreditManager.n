using System;

namespace Entidades
{
    public class HistorialPrestamo
    {
        public int Id { get; set; }
        public Prestamo Prestamo { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public string EstadoPrestamo { get; set; }
    }
}
