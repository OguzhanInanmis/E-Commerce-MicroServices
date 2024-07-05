using E_Commerce.Cargo.Entity.Concrete;

namespace E_Commerce.Cargo.Dto.DTOs.CargoDetailDTOs
{
    public class UpdateCargoDetailDTO
    {
        public int Id { get; set; }
        public string SenderCustomer { get; set; }
        public string ReceiverCustomer { get; set; }
        public string Barcode { get; set; }

        public int CargoCompanyId { get; set; }
        public CargoCompany CargoCompany { get; set; }
    }
}
