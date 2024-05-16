using E_Commerce.IdentityServer.Dtos;
using E_Commerce.IdentityServer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using static Duende.IdentityServer.IdentityServerConstants;

namespace E_Commerce.IdentityServer.Controllers
{
    [Route("api/[controller]/")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> userManager;

        public RegisterController(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        [Authorize(LocalApi.PolicyName)]
        public async Task<IActionResult> UserRegister(UserRegisterDto userRegisterDto)
        {
            var value = new ApplicationUser()
            {
                UserName = userRegisterDto.Username,
                Email = userRegisterDto.Email,
                Name = userRegisterDto.Name,
                Surname = userRegisterDto.Surname,
                
            };
            var result = await userManager.CreateAsync(value,userRegisterDto.Password);
            if(result.Succeeded)
            {
                return Ok("Kullanıcı başarıyla eklendi.");
            }
            else
            {
                return Ok("Kullanıcı oluşturulamadı lütfen tekrar deneyiniz.");
            }
        }
        [HttpGet]
        public async Task<IActionResult> Deneme()
        {
            return Ok("Deneme başarılı;");
        }
    }
}
