using Entidades;
using System.Collections.Generic;

namespace Datos.Interfaces
{
    public interface IPrestamoRepositorio
    {
        bool InsertarPrestamoConCuotas(Prestamo prestamo, out string mensaje);
        bool RegistrarPago(Pago pago, out string mensaje);
        List<Prestamo> ListarPrestamosActivos();
        List<Cuota> ObtenerCuotasPorDia(int idPrestamo);
    }
}
