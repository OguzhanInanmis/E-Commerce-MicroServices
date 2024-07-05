using E_Commerce.Cargo.Business.Abstract;
using E_Commerce.Cargo.Dto.DTOs.CargoCompanyDTOs;
using E_Commerce.Cargo.Entity.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Cargo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CargoCompaniesController : ControllerBase
    {
        private readonly ICargoCompanyService cargoCompanyService;

        public CargoCompaniesController(ICargoCompanyService cargoCompanyService)
        {
            this.cargoCompanyService = cargoCompanyService;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = cargoCompanyService.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCargoCompany(CreateCargoCompanyDTO createCargoCompanyDTO)
        {
            CargoCompany cargoCompany = new() { CompanyName = createCargoCompanyDTO.CompanyName };
            cargoCompanyService.TInsert(cargoCompany);
            return Ok("Kargo şirketi başarıyla eklendi.");
        }
        [HttpDelete]
        public IActionResult RemoveCargoCompany(int id)
        {
            cargoCompanyService.TDelete(id);
            return Ok("Kargo şirketi başarıyla silindi.");
        }
        [HttpGet("id")]
        public IActionResult GetCargoCompanyById(int id)
        {
            var value = cargoCompanyService.TGetById(id);
            return Ok(value);
        }
        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDTO updateCargoCompanyDTO)
        {
            CargoCompany cargoCompany = new() { Id = updateCargoCompanyDTO.Id, CompanyName = updateCargoCompanyDTO.CompanyName };
            cargoCompanyService.TUpdate(cargoCompany);
            return Ok("Kargo şirketi başarıyla güncellendi.");
        }
    }
}
