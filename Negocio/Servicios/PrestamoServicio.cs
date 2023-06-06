using Datos.Repositorios;
using Entidades;
using System.Collections.Generic;

namespace Negocio.Servicios
{
    public class PrestamoServicio 
    {
        private readonly PrestamoRepositorio repositorio = new PrestamoRepositorio();

        public bool InsertarPrestamoConCuotas(Prestamo prestamo, out string mensaje)
        {
            return repositorio.InsertarPrestamoConCuotas(prestamo, out mensaje);
        }

        public List<Prestamo> ListarPrestamosActivos()
        {
            return repositorio.ListarPrestamosActivos();
        }

        public List<Cuota> ObtenerCuotasPorDia(int idPrestamo)
        {
            return repositorio.ObtenerCuotasPorDia(idPrestamo);
        }

        public bool RegistrarPago(Pago pago, out string mensaje)
        {
            return repositorio.RegistrarPago(pago, out mensaje);
        }
    }
}
