using AutoMapper;
using E_Commerce.Catalog.Dtos.ProductDetailDtos;
using E_Commerce.Catalog.Entities;
using E_Commerce.Catalog.Settings;
using MongoDB.Driver;

namespace E_Commerce.Catalog.Services.ProductDetailServices
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IMapper mapper;
        private readonly IMongoCollection<ProductDetail> productDetailCollection;

        public ProductDetailService(IMapper mapper, IDatabaseSettings databaseSettings)
        {
            MongoClient client = new MongoClient(databaseSettings.ConnectionString);
            IMongoDatabase database = client.GetDatabase(databaseSettings.DatabaseName);
            productDetailCollection = database.GetCollection<ProductDetail>(databaseSettings.ProductDetailCollectionName);
            this.mapper = mapper;
        }
        public async Task CreateProductDetailAsync(CreateProductDetailDto createProductDetailDto)
        {
            ProductDetail productDetail = mapper.Map<ProductDetail>(createProductDetailDto);
            await productDetailCollection.InsertOneAsync(productDetail);
        }

        public async Task DeleteProductDetailAsync(string productDetailId)
        {
            await productDetailCollection.DeleteOneAsync(x=>x.ProductDetailId == productDetailId);
        }

        public async Task<List<ResultProductDetailDto>> GetAllProductDetailsAsync()
        {
            var productDetails = await productDetailCollection.Find(x => true).ToListAsync();
            return mapper.Map<List<ResultProductDetailDto>>(productDetails);
        }

        public async Task<ResultProductDetailDto> GetByIdProductDetailAsync(string productDetailId)
        {
            ProductDetail productDetail = await productDetailCollection.Find(x => x.ProductDetailId == productDetailId).FirstOrDefaultAsync();
            return mapper.Map<ResultProductDetailDto>(productDetail);
        }

        public async Task UpdateProductDetailAsync(UpdateProductDetailDto updateProductDetailDto)
        {
            ProductDetail productDetail = mapper.Map<ProductDetail>(updateProductDetailDto);
            await productDetailCollection.FindOneAndReplaceAsync(x => x.ProductDetailId == updateProductDetailDto.ProductDetailId, productDetail);
        }
    }
}
