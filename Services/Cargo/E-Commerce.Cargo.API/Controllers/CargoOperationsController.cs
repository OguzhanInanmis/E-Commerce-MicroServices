using E_Commerce.Cargo.Business.Abstract;
using E_Commerce.Cargo.Dto.DTOs.CargoOperationDTOs;
using E_Commerce.Cargo.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Cargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationsController : ControllerBase
    {
        private readonly ICargoOperationService cargoOperationService;

        public CargoOperationsController(ICargoOperationService cargoOperationService)
        {
            this.cargoOperationService = cargoOperationService;
        }
        [HttpGet]
        public IActionResult CargoOperationList()
        {
            var values = cargoOperationService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoOperation(CreateCargoOperationDTO createCargoOperationDTO)
        {
            CargoOperation cargoOperation = new() { 
                Barcode = createCargoOperationDTO.Barcode,
                OperationDate = createCargoOperationDTO.OperationDate,
                Description = createCargoOperationDTO.Description,
            };
            cargoOperationService.TInsert(cargoOperation);
            return Ok("Kargo operasyonu başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult RemoveCargoOperation(int id)
        {
            cargoOperationService.TDelete(id);
            return Ok("Kargo operasyonu başarıyla silindi.");
        }
        [HttpGet("id")]
        public IActionResult GetCargoOperationById(int id)
        {
            var value = cargoOperationService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCargoOperation(UpdateCargoOperationDTO updateCargoOperationDTO)
        {
            CargoOperation cargoOperation = new() 
            {
                Id = updateCargoOperationDTO.Id,
                Description = updateCargoOperationDTO.Description,
                OperationDate = updateCargoOperationDTO.OperationDate,
                Barcode = updateCargoOperationDTO.Barcode,
            };
            cargoOperationService.TUpdate(cargoOperation);
            return Ok("Kargo operasyonu başarıyla güncellendi.");
        }
    }
}
