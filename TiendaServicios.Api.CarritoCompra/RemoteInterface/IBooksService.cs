using TiendaServicios.Api.CarritoCompra.RemoteModel;

namespace TiendaServicios.Api.CarritoCompra.RemoteInterface
{
    public interface IBooksService
    {
        Task<(bool result, BookRemote Book, string ErrorMessage)> GetBook(string BookId);
    }
}
