using E_Commerce.Catalog.Dtos.ProductImageDtos;

namespace E_Commerce.Catalog.Services.ProductImageServices
{
    public interface IProductImageService
    {
        Task<List<ResultProductImageDto>> GetAllProductImagesAsync();
        Task CreateProductImageAsync(CreateProductImageDto createProductImageDto);
        Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto);
        Task DeleteProductImageAsync(string productImageId);
        Task<ResultProductImageDto> GetByIdProductImageAsync(string productImageId);
    }
}
