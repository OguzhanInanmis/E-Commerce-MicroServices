using E_Commerce.Catalog.Dtos.ProductImageDtos;
using E_Commerce.Catalog.Services.ProductImageServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService productImageService;

        public ProductImagesController(IProductImageService productImageService)
        {
            this.productImageService = productImageService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            List<ResultProductImageDto> productImages = await productImageService.GetAllProductImagesAsync();
            return Ok(productImages);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün resimleri başarıyla eklendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            ResultProductImageDto productImage = await productImageService.GetByIdProductImageAsync(id);
            return Ok(productImage);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün resimleri başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün resimleri başarıyla güncellendi.");
        }
    }
}
