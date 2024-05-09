using E_Commerce.Catalog.Entities;

namespace E_Commerce.Catalog.Dtos.ProductImageDtos
{
    public class UpdateProductImageDto
    {
        public string ProductImageId { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string ProductId { get; set; }

    }
}
