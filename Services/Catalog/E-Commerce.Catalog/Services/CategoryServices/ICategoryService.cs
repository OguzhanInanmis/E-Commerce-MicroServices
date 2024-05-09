using E_Commerce.Catalog.Dtos.CategoryDtos;

namespace E_Commerce.Catalog.Services.CategoryServices
{
    public interface ICategoryService
    {
        Task<List<ResultCategoryDto>> GetAllCategoriesAsync();
        Task CreateCategoryAsync(CreateCategoryDto createCategoryDto);
        Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto);
        Task DeleteCategoryAsync(string categoryId);
        Task<ResultCategoryDto> GetByIdCategoryAsync(string categoryId);
    }
}
