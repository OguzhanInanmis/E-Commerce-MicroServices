using E_Commerce.Catalog.Dtos.ProductDtos;
using E_Commerce.Catalog.Services.ProductServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductList()
        {
            List<ResultProductDto> categories = await productService.GetAllProductsAsync();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            await productService.CreateProductAsync(createProductDto);
            return Ok("Ürün başarıyla eklendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {
            ResultProductDto Product = await productService.GetByIdProductAsync(id);
            return Ok(Product);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProduct(string id)
        {
            await productService.DeleteProductAsync(id);
            return Ok("Ürün başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            await productService.UpdateProductAsync(updateProductDto);
            return Ok("Ürün başarıyla güncellendi.");
        }
    }
}
