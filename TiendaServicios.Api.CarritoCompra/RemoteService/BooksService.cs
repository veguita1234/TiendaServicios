using System.Text.Json;
using TiendaServicios.Api.CarritoCompra.RemoteInterface;
using TiendaServicios.Api.CarritoCompra.RemoteModel;

namespace TiendaServicios.Api.CarritoCompra.RemoteService
{
    public class BooksService : IBooksService
    {
        
        private readonly IHttpClientFactory _httpClient;
        private readonly ILogger<BooksService> _logger;

        public BooksService(IHttpClientFactory httpClient, ILogger<BooksService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<(bool result, BookRemote Book, string ErrorMessage)> GetBook(string BookId)
        {
            try
            {
                var client = _httpClient.CreateClient("Books");
                var code = new Guid(BookId);
                var response = await client.GetAsync($"api/MaterialBook/{code}");

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();

                    var options = new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true,
                    };

                    var result = JsonSerializer.Deserialize<BookRemote>(content, options);

                    return (true, result, null);
                }

                return (false, null, response.ReasonPhrase);
            }

            catch (Exception e)
            {
                _logger?.LogError(e.ToString());
                return (false, null, e.Message);
            }
        }
    }
}
