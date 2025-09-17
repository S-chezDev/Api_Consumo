using ConsumoApi.Models;

namespace ConsumoApi.Services
{
    public interface IApiClient
    {
        Task<IEnumerable<Producto>> GetProductosAsync();
        Task<Producto?> GetProductoByIdAsync(int id);
        Task CreateProductoAsync(Producto producto);
        Task UpdateProductoAsync(Producto producto);
        Task DeleteProductoAsync(int id);
    }
}

