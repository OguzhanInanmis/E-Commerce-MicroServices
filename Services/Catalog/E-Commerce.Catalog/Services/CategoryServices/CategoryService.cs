using AutoMapper;
using E_Commerce.Catalog.Dtos.CategoryDtos;
using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Settings;
using MongoDB.Driver;

namespace E_Commerce.Catalog.Services.CategoryServices
{
    public class CategoryService : ICategoryService
    {
        private readonly IMongoCollection<Category> categoryCollection;
        private readonly IMapper mapper;

        public CategoryService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            MongoClient client = new MongoClient(databaseSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(databaseSettings.DatabaseName);
            categoryCollection = database.GetCollection<Category>(databaseSettings.CategoryCollectionName);
            this.mapper = mapper;
        }
        public async Task CreateCategoryAsync(CreateCategoryDto createCategoryDto)
        {
            Category category = mapper.Map<Category>(createCategoryDto);
            await categoryCollection.InsertOneAsync(category);
        }

        public async Task<List<ResultCategoryDto>> GetAllCategoriesAsync()
        {
            List<Category> categories = await categoryCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultCategoryDto>>(categories);
        }

        public async Task<ResultCategoryDto> GetByIdCategoryAsync(string categoryId)
        {
            Category category = await categoryCollection.Find(x => x.CategoryId == categoryId).FirstOrDefaultAsync();
            return mapper.Map<ResultCategoryDto>(category);
        }

        public async Task UpdateCategoryAsync(UpdateCategoryDto updateCategoryDto)
        {
            Category map = mapper.Map<Category>(updateCategoryDto);
            await categoryCollection.FindOneAndReplaceAsync(x => x.CategoryId == updateCategoryDto.CategoryId, map);
        }

        public async Task DeleteCategoryAsync(string categoryId)
        {
            await categoryCollection.DeleteOneAsync(x=> x.CategoryId == categoryId);
        }
    }
}
