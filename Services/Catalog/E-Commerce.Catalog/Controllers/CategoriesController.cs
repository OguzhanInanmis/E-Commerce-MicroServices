using E_Commerce.Catalog.Dtos.CategoryDtos;
using E_Commerce.Catalog.Services.CategoryServices;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoriesController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpGet]
        public async Task<IActionResult> CategoryList()
        {
            List<ResultCategoryDto> categories = await categoryService.GetAllCategoriesAsync();
            return Ok(categories);
        }
        [HttpPost]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategoryDto)
        {
            await categoryService.CreateCategoryAsync(createCategoryDto);
            return Ok("Kategori başarıyla eklendi.");
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetCategoryById(string id)
        {
            ResultCategoryDto category = await categoryService.GetByIdCategoryAsync(id);
            return Ok(category);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCategory(string id)
        {
            await categoryService.DeleteCategoryAsync(id);
            return Ok("Kategori başarıyla silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {
            await categoryService.UpdateCategoryAsync(updateCategoryDto);
            return Ok("Kategori başarıyla güncellendi.");
        }
    }
}
