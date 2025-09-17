using System.Net.Http.Json;
using ConsumoApi.Models;

namespace ConsumoApi.Services
{
    public class ApiClient : IApiClient
    {
        private readonly HttpClient _httpClient;

        public ApiClient(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
        }

        // Obtener todos los productos
        public async Task<IEnumerable<Producto>> GetProductosAsync()
        {
            var response = await _httpClient.GetFromJsonAsync<IEnumerable<Producto>>("Productos");
            return response ?? Enumerable.Empty<Producto>();
        }

        // Obtener un producto por ID
        public async Task<Producto?> GetProductoByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Producto>($"Productos/{id}");
        }

        // Crear un nuevo producto
        public async Task CreateProductoAsync(Producto producto)
        {
            var response = await _httpClient.PostAsJsonAsync("Productos", producto);
            response.EnsureSuccessStatusCode();
        }

        // Actualizar un producto
        public async Task UpdateProductoAsync(Producto producto)
        {
            var response = await _httpClient.PutAsJsonAsync($"Productos/{producto.IdProducto}", producto);
            response.EnsureSuccessStatusCode();
        }

        // Eliminar un producto
        public async Task DeleteProductoAsync(int id)
        {
            var response = await _httpClient.DeleteAsync($"Productos/{id}");
            response.EnsureSuccessStatusCode();
        }
    }
}
