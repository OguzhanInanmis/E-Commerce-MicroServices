namespace E_Commerce.Cargo.Dto.DTOs.CargoOperationDTOs
{
    public class CreateCargoOperationDTO
    {
        public string Barcode { get; set; }
        public string Description { get; set; }
        public DateTime OperationDate { get; set; }
    }
}
