using AutoMapper;
using E_Commerce.Catalog.Dtos.ProductImageDtos;
using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Settings;
using MongoDB.Driver;

namespace E_Commerce.Catalog.Services.ProductImageServices
{
    public class ProductImageService : IProductImageService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ProductImage> productImageCollection;

        public ProductImageService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            MongoClient client = new MongoClient(databaseSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(databaseSettings.DatabaseName);
            productImageCollection = database.GetCollection<ProductImage>(databaseSettings.ProductImageCollectionName);
            this.mapper = mapper;
        }
        public async Task CreateProductImageAsync(CreateProductImageDto createProductImageDto)
        {
            ProductImage productImage = mapper.Map<ProductImage>(createProductImageDto);
            await productImageCollection.InsertOneAsync(productImage);
        }

        public async Task DeleteProductImageAsync(string productImageId)
        {
            await productImageCollection.DeleteOneAsync(x=>x.ProductImageId == productImageId);
        }

        public async Task<List<ResultProductImageDto>> GetAllProductImagesAsync()
        {
            var productImages = await productImageCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultProductImageDto>>(productImages);
        }

        public async Task<ResultProductImageDto> GetByIdProductImageAsync(string productImageId)
        {
            ProductImage productImage = await productImageCollection.Find(x => x.ProductImageId == productImageId).FirstOrDefaultAsync();
            return mapper.Map<ResultProductImageDto>(productImage);
        }

        public async Task UpdateProductImageAsync(UpdateProductImageDto updateProductImageDto)
        {
            ProductImage productImage = mapper.Map<ProductImage>(updateProductImageDto);
            await productImageCollection.FindOneAndReplaceAsync(x => x.ProductImageId == updateProductImageDto.ProductImageId, productImage);
        }
    }
}
