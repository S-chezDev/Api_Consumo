using ConsumoApi.Models;
using ConsumoApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace ConsumoApi.Controllers
{
    public class ProductosController : Controller
    {
        private readonly IApiClient _apiClient;

        public ProductosController(IApiClient apiClient)
        {
            _apiClient = apiClient;
        }

        // GET: Productos
        public async Task<IActionResult> Index()
        {
            var productos = await _apiClient.GetProductosAsync();
            return View(productos);
        }

        // GET: Productos/Details/5
        public async Task<IActionResult> Details(int id)
        {
            var producto = await _apiClient.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // GET: Productos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Producto producto)
        {
            if (ModelState.IsValid)
            {
                await _apiClient.CreateProductoAsync(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productos/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var producto = await _apiClient.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productos/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, Producto producto)
        {
            if (id != producto.IdProducto)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            {
                await _apiClient.UpdateProductoAsync(producto);
                return RedirectToAction(nameof(Index));
            }
            return View(producto);
        }

        // GET: Productos/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var producto = await _apiClient.GetProductoByIdAsync(id);
            if (producto == null)
            {
                return NotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _apiClient.DeleteProductoAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
