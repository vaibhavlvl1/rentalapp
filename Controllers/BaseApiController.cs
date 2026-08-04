using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rental_system.Models.Dtos;

namespace rental_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseApiController : ControllerBase
    {
        protected IActionResult HandleResponse(ApiResponseDto response)
        {
            return response.status switch
            {
                200 => Ok(response),
                201 => StatusCode(201, response),
                400 => BadRequest(response),
                401 => Unauthorized(response),
                404 => NotFound(response),
                409 => Conflict(response),
                _   => StatusCode(response.status,response)
            };
        }
    }
}
