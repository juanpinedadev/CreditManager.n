using System;

namespace Entidades
{
    public class Empleado
    {
        public int Id { get; set; }
        public Persona Persona { get; set; }
        public Cargo Cargo { get; set; }
        public bool Estado { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}
