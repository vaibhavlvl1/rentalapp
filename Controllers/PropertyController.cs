using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using rental_system.Interfaces.IServices;
using rental_system.Models.Dtos;

namespace rental_system.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : BaseApiController
    {
        private readonly IPropertyService _propertyService;
        public PropertyController(IPropertyService propService)
        {
            _propertyService = propService;
        }


        [HttpPost]
        [Route("/addnewproperty")]

        public async Task <IActionResult> AddNewProperty(AddPropertyDto property)
        {   

           var response = await _propertyService.AddNewPropertyAsync(property);


            return HandleResponse(response);
        }

        [HttpPost]
        [Route("/addnewroom")]

        public async Task <IActionResult> AddNewRoom(AddRoomDto room)
        {
            var response = await _propertyService.AddNewRoomAsync(room);

            return HandleResponse(response);
        }
    }
}
