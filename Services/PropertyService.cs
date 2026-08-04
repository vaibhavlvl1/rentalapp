using Microsoft.AspNetCore.Http.HttpResults;
using rental_system.Interfaces.IRepositories;
using rental_system.Interfaces.IServices;
using rental_system.Models.Dtos;

namespace rental_system.Services
{
    public class PropertyService:IPropertyService
    {
        private readonly IPropertyRepository _propertyRepo ;
        public PropertyService(IPropertyRepository propertyRepo)
        {
            _propertyRepo = propertyRepo ;
        }

        public async Task<ApiResponseDto> AddNewPropertyAsync(AddPropertyDto property)
        {

            var result = await _propertyRepo.AddPropertyAsync(property);

            if (result != null)
            {
                return new ApiResponseDto
                {
                    status = 200,
                    message = "Property Created Successfully",
                    data = new
                    {
                        property = result
                    }
                };
            }

            return new ApiResponseDto 
            { 
                status=500,
                message= "Failed to create property"
            };
        }

        public async Task<ApiResponseDto> AddNewRoomAsync(AddRoomDto room) 
        {
            var result = await _propertyRepo.AddNewRoomAsync(room);

            if (result != null)
            {
                return new ApiResponseDto
                {
                    status = 200,
                    message = "Room Added Successfully",
                    data = result,
                };
            }
            else
            {
                return new ApiResponseDto
                {
                    status = 500,
                    message = "Room add failed",
                };
            }
        }
    }
}
