using E_Commerce.Cargo.Business.Abstract;
using E_Commerce.Cargo.Dto.DTOs.CargoCustomerDTOs;
using E_Commerce.Cargo.Entity.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Cargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomersController : ControllerBase
    {
        private readonly ICargoCustomerService cargoCustomerService;

        public CargoCustomersController(ICargoCustomerService cargoCustomerService)
        {
            this.cargoCustomerService = cargoCustomerService;
        }
        [HttpGet]
        public IActionResult CargoCustomerList()
        {
            var values = cargoCustomerService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCustomer(CreateCargoCustomerDTO createCargoCustomerDTO)
        {
            CargoCustomer cargoCustomer = new() { 
                Address = createCargoCustomerDTO.Address,
                City = createCargoCustomerDTO.City,
                District = createCargoCustomerDTO.District,
                Name = createCargoCustomerDTO.Name,
                Phone = createCargoCustomerDTO.Phone,
                Surname = createCargoCustomerDTO.Surname,
            };
            cargoCustomerService.TInsert(cargoCustomer);
            return Ok("Kargo müşterisi başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult RemoveCargoCustomer(int id)
        {
            cargoCustomerService.TDelete(id);
            return Ok("Kargo müşterisi başarıyla silindi.");
        }
        [HttpGet("id")]
        public IActionResult GetCargoCustomerById(int id)
        {
            var value = cargoCustomerService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCargoCustomer(UpdateCargoCustomerDTO updateCargoCustomerDTO)
        {
            CargoCustomer cargoCustomer = new() 
            {
                Id = updateCargoCustomerDTO.Id,
                Address = updateCargoCustomerDTO.Address,
                City = updateCargoCustomerDTO.City,
                Surname = updateCargoCustomerDTO.Surname,
                Phone = updateCargoCustomerDTO.Phone,
                District = updateCargoCustomerDTO.District,
                Name = updateCargoCustomerDTO.Name
            };
            cargoCustomerService.TUpdate(cargoCustomer);
            return Ok("Kargo müşterisi başarıyla güncellendi.");
        }
    }
}
