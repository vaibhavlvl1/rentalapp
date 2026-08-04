using Microsoft.AspNetCore.Mvc;
using rental_system.Interfaces.IServices;
using rental_system.Models.Dtos;

namespace rental_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : BaseApiController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService) 
        {
            _userService = userService;
        }


        [HttpPost("/registerbyphone")]

        public async Task<IActionResult> RegisterByPhone([FromBody] PhoneRegisterDto PhoneRegistrationRequest)
        {
            var response = await _userService.RegisterUserAsync(PhoneRegistrationRequest);

            return HandleResponse(response);
        }

        [HttpPost]
        [Route("/addTenant")]

        public async Task<IActionResult> CreateNewUser([FromBody] AddTenantDto tenant)
        {
            var response = await _userService.CreateNewTenantAsync(tenant);

            return HandleResponse(response);
        }
    }
}
