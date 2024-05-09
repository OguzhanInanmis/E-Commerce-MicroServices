using AutoMapper;
using E_Commerce.Catalog.Dtos.CategoryDtos;
using E_Commerce.Catalog.Dtos.ProductDtos;
using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Settings;
using MongoDB.Driver;

namespace E_Commerce.Catalog.Services.ProductServices
{
    public class ProductService : IProductService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<Product> productCollection;

        public ProductService(IMapper mapper,IDatabaseSettings databaseSettings)
        {
            MongoClient client = new MongoClient(databaseSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(databaseSettings.DatabaseName);
            productCollection = database.GetCollection<Product>(databaseSettings.ProductCollectionName);
            this.mapper = mapper;
        }
        public async Task CreateProductAsync(CreateProductDto createProductDto)
        {
            Product product = mapper.Map<Product>(createProductDto);
            await productCollection.InsertOneAsync(product);
        }

        public async Task DeleteProductAsync(string productId)
        {
            await productCollection.DeleteOneAsync(x=>x.ProductId == productId);
        }

        public async Task<List<ResultProductDto>> GetAllProductsAsync()
        {
            var products = await productCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultProductDto>>(products);
        }

        public async Task<ResultProductDto> GetByIdProductAsync(string productId)
        {
            Product product = await productCollection.Find(x => x.ProductId == productId).FirstOrDefaultAsync();
            return mapper.Map<ResultProductDto>(product);
        }

        public async Task UpdateProductAsync(UpdateProductDto updateProductDto)
        {
            Product product = mapper.Map<Product>(updateProductDto);
            await productCollection.FindOneAndReplaceAsync(x=>x.ProductId == updateProductDto.ProductId, product);
        }
    }
}
