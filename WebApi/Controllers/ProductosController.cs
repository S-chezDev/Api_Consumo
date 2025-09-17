using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        private readonly InventarioDbContext _context;

        public ProductosController(InventarioDbContext context)
        {
            _context = context;
        }

        // GET: api/Productos
        [HttpGet(Name = "GetProductos")]
        public ActionResult<IEnumerable<Producto>> GetAll()
        {
            return _context.Productos.ToList();
        }

        // GET: api/Productos/5
        [HttpGet("{id}")]
        public ActionResult<Producto> GetById(int id)
        {
            var producto = _context.Productos.Find(id);

            if (producto == null)
                return NotFound();

            return producto;
        }

        // POST: api/Productos
        [HttpPost]
        public ActionResult<Producto> Create(Producto producto)
        {
            _context.Productos.Add(producto);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetById), new { id = producto.IdProducto }, producto);
        }

        // PUT: api/Productos/5
        [HttpPut("{id}")]
        public IActionResult Update(int id, Producto producto)
        {
            if (id != producto.IdProducto)
                return BadRequest();

            _context.Entry(producto).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/Productos/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var producto = _context.Productos.Find(id);

            if (producto == null)
                return NotFound();

            _context.Productos.Remove(producto);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
