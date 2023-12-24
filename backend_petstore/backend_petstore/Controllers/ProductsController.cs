using BackEndPetStore.Context;
using BackEndPetStore.Dtos;
using BackEndPetStore.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BackEndPetStore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        //CRUD -> Create - Read - Update - Delete

        //Create
        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateUpdateProductDto createUpdateProductDto)
        {
            var newProduct = new ProductEntity()
            {
                Brand = createUpdateProductDto.Brand,
                Title = createUpdateProductDto.Title,
            };
           await _context.Products.AddAsync(newProduct);
            await _context.SaveChangesAsync();  
            return Ok("Product Saved Successfully");
        }

        //Read
        [HttpGet]
        public async Task<ActionResult<List<ProductEntity>>> GetAllProducts()
        {
            var products = await _context.Products.OrderByDescending(q => q.UpdatedAt).ToListAsync();
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<ProductEntity>> GetProductById([FromRoute] long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if(product is null)
            {
                return NotFound("Product Not Found");
            }
            return Ok(product);
        }


        //Update
        [HttpPut("{id}")]
        //[Route("{id}")]
        public async Task<IActionResult> UpdateProduct([FromRoute]long id, [FromBody] CreateUpdateProductDto createUpdateProductDto)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);

            if (product is null)
            {
                return NotFound("Product Not Found");
            }
            product.Title = createUpdateProductDto.Title;   
            product.Brand = createUpdateProductDto.Brand;
            product.UpdatedAt = DateTime.Now;

            await _context.SaveChangesAsync();

            return Ok("Product Updated Successfully");
        }

        //Delete
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x=>x.Id == id);

            if(product is null)
            {
                return NotFound("Product Not Found");
            }

            _context.Products.Remove(product);
            await _context.SaveChangesAsync();
            return Ok("Product Deleted Successfully");
        }
    }
}
