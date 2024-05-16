using E_Commerce.Discount.Dtos;
using E_Commerce.Discount.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DiscountsController : ControllerBase
    {
        private readonly IDiscountService discountService;

        public DiscountsController(IDiscountService discountService)
        {
            this.discountService = discountService;
        }

        [HttpGet]
        public async Task<IActionResult> CouponList()
        {
            List<ResultCouponDto> values = await discountService.GetAllCouponsAsync();
            return Ok(values);
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetCouponById(int id)
        {
            ResultCouponDto value = await discountService.GetByIdCouponAsync(id);
            return Ok(value);

        }
        [HttpPost]
        public async Task<IActionResult> CreateCoupon(CreateCouponDto createCouponDto)
        {
            await discountService.CreateCouponAsync(createCouponDto);
            return Ok("Kupon başarıyla oluşturuldu.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateCoupon(UpdateCouponDto updateCouponDto)
        {
            await discountService.UpdateCouponAsync(updateCouponDto);
            return Ok("Kupon başarıyla güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteCoupon(int id)
        {
            await discountService.DeleteCouponAsync(id);
            return Ok("Kupon başarıyla silindi.");
        }
    }
}
