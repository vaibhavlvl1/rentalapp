using Microsoft.OpenApi.Any;

namespace rental_system.Models.Dtos
{
    public class ApiResponseDto
    {
        public required int status { get; set; }
        public  string? message { get; set; }
        public object? data { get; set; }
    }
}
