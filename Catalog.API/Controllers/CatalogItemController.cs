using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Onis.Domain.Contracts;
using Onis.Domain.Entities;
using Onis.Infrastructure.DB;

namespace Catalog.API.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
       
        private readonly ICatalogItemRepository _repo;

        public ProductsController(ICatalogItemRepository repo)
        {
            _repo = repo;
        }
        // GET: /Products
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _repo.GetAllItems();
                return Ok(products);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        // GET: /Products/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await _repo.GetByID(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }


        [HttpPost]
        public async Task<ActionResult<CatalogItem>> Create(CatalogItem catalogItem)
        {
            repo.CatalogItems.Add(catalogItem);
            await repo.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = catalogItem.Id }, catalogItem);
        }
    }
}
