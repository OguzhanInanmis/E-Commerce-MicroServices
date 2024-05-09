using E_Commerce.Catalog.Dtos.ProductDetailDtos;

namespace E_Commerce.Catalog.Services.ProductDetailServices
{
    public interface IProductDetailService
    {
        Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync();
        Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto);
        Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto);
        Task DeleteProductDetailAsync(string productDetailId);
        Task<ResultProductDetailDto> GetByIdProductDetailAsync(string productDetailId);
    }
}
