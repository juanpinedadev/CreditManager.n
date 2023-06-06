namespace Entidades
{
    public class Direccion
    {
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public string Nombre { get; set; }
        public bool Estado { get; set; }
    }
}
