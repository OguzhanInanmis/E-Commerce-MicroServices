using E_Commerce.Cargo.Business.Abstract;
using E_Commerce.Cargo.Dto.DTOs.CargoDetailDTOs;
using E_Commerce.Cargo.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Cargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailsController : ControllerBase
    {
        private readonly ICargoDetailService cargoDetailService;

        public CargoDetailsController(ICargoDetailService cargoDetailService)
        {
            this.cargoDetailService = cargoDetailService;
        }
        [HttpGet]
        public IActionResult CargoDetailList()
        {
            var values = cargoDetailService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoDetail(CreateCargoDetailDTO createCargoDetailDTO)
        {
            CargoDetail cargoDetail = new() { 
                Barcode = createCargoDetailDTO.Barcode,
                CargoCompanyId = createCargoDetailDTO.CargoCompanyId,
                ReceiverCustomer = createCargoDetailDTO.ReceiverCustomer,
                SenderCustomer = createCargoDetailDTO.SenderCustomer,
            };
            cargoDetailService.TInsert(cargoDetail);
            return Ok("Kargo detayı başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult RemoveCargoDetail(int id)
        {
            cargoDetailService.TDelete(id);
            return Ok("Kargo detayı başarıyla silindi.");
        }
        [HttpGet("id")]
        public IActionResult GetCargoDetailById(int id)
        {
            var value = cargoDetailService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCargoDetail(UpdateCargoDetailDTO updateCargoDetailDTO)
        {
            CargoDetail cargoDetail = new() 
            {
                SenderCustomer = updateCargoDetailDTO.ReceiverCustomer,
                ReceiverCustomer = updateCargoDetailDTO.ReceiverCustomer,
                CargoCompanyId = updateCargoDetailDTO.CargoCompanyId,
                Barcode = updateCargoDetailDTO.Barcode,
            };
            cargoDetailService.TUpdate(cargoDetail);
            return Ok("Kargo detayı başarıyla güncellendi.");
        }
    }
}
