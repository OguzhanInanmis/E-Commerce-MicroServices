using E_Commerce.Catalog.Dtos.ProductDetailDtos;
using E_Commerce.Catalog.Services.ProductDetailServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService productDetailService;

        public ProductDetailsController(IProductDetailService productDetailService)
        {
            this.productDetailService = productDetailService;
        }
        [HttpGet]
        public async Task<IActionResult> ProductDetailList()
        {
            List<ResultProductDetailDto> productDetails = await productDetailService.GetAllProductDetailsAsync();
            return Ok(productDetails);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            await productDetailService.CreateProductDetailAsync(createProductDetailDto);
            return Ok("Ürün Detayı başarıyla eklendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailById(string id)
        {
            ResultProductDetailDto productDetail = await productDetailService.GetByIdProductDetailAsync(id);
            return Ok(productDetail);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetail(string id)
        {
            await productDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün Detayı başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {
            await productDetailService.UpdateProductDetailAsync(updateProductDetailDto);
            return Ok("Ürün Detayı başarıyla güncellendi.");
        }
    }
}
