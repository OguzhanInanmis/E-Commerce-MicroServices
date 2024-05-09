using E_Commerce.Discount.Dtos;

namespace E_Commerce.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultCouponDto>> GetAllCouponsAsync();
        Task CreateCouponAsync(CreateCouponDto createCouponDto);
        Task UpdateCouponAsync(UpdateCouponDto updateCouponDto);
        Task DeleteCouponAsync(int couponId);
        Task<ResultCouponDto> GetByIdCouponAsync(int couponId);
    }
}
