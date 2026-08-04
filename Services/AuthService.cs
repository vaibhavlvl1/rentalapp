using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.IdentityModel.Tokens;
using rental_system.Interfaces.IRepositories;
using rental_system.Interfaces.IServices;
using rental_system.Models.Dtos;
using rental_system.Models.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace rental_system.Services
{
    public class AuthService:IAuthService
    {
        private readonly IUserRepository _userRepo;
        private readonly IConfiguration _config;
        public AuthService(IUserRepository userRepo,IConfiguration config)
        {
            _userRepo = userRepo;
            _config = config;
        }

        public async Task <ApiResponseDto> LoginAsync(PhoneLoginDto PhoneLoginRequest)
        {
            string password = PhoneLoginRequest.Password;

            var WhetherUserExists = await _userRepo.CheckUserInDbAsync(PhoneLoginRequest.Phone);
            if (!WhetherUserExists)
            {
                return new ApiResponseDto
                {
                    status = 400,
                    message = "User Not Found"
                };
            }
        
            var user = await _userRepo.FetchUserFromDbAsync(PhoneLoginRequest.Phone);

           

            bool isPasswordValid = BC.Verify( password, user.PasswordHash);

            if (!isPasswordValid)
            {
                return new ApiResponseDto
                {
                    status = 401,
                    message = "Invalid Caredentials"
                };
            }
            else
            {
                string token = GenerateJwtToken(user);
                return new ApiResponseDto
                {
                    status = 200,
                    message = "Login Successfull",
                    data = new
                    {
                        token = token,
                        user_data = new
                        {
                            user_id = user.Id,
                            fullName = user.FullName,
                            phone = user.Phone,
                            email = user.Email,
                        }
                    }
                };
            }            
        }
        //JWT Generator
        private string GenerateJwtToken(UserEntity user)
        {
            var jwtSettings = _config.GetSection("JwtSettings");
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            // Store user identity details inside the token payload
            var claims = new[]
            {
            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FullName),
            new Claim(ClaimTypes.MobilePhone, user.Phone),
            new Claim(ClaimTypes.Email, user.Email ?? "")
        };

            var token = new JwtSecurityToken(
                issuer: jwtSettings["Issuer"],
                audience: jwtSettings["Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(double.Parse(jwtSettings["ExpiryInMinutes"]!)),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        // for google login/register and get jwt back here

        public async Task<ApiResponseDto> LoginOrRegisterGoogleUserAsync(GoogleLoginDto GoogleDetails)
        {
            var user = await _userRepo.GetUserByEmailAsync(GoogleDetails.Gemail);

            if(user is null)
            {
                UserEntity newGoogleUser = new UserEntity
                {
                    FullName = GoogleDetails.Gname,
                    Phone = "0000000000",
                    Email = GoogleDetails.Gemail,
                    PasswordHash = BC.HashPassword(Guid.NewGuid().ToString()),
                    CreatedAt = DateTime.UtcNow,
                    ModifiedAt = DateTime.UtcNow,
                    IsDeleted = false,
                    Status = true

                };

                var newUser = await _userRepo.CreateNewUserAsync(newGoogleUser);

                string token = GenerateJwtToken(newUser);
              
                return new ApiResponseDto
                {
                    message = "Successfull",
                    status = 200,
                    data = new
                    {
                        token = token,
                        user_data = new
                        {
                            user_id = user.Id,
                            fullName = user.FullName,
                            phone = user.Phone,
                            email = user.Email,
                        }
                    }
                };

            }

            string token2 = GenerateJwtToken(user);
            return new ApiResponseDto
            {
                status = 200,
                message = "Login Successfull",
                data = new
                {
                    token = token2,
                    user_data = new
                    {
                        user_id = user.Id,
                        fullName = user.FullName,
                        phone = user.Phone,
                        email = user.Email,
                    }
                }
            };
        }

    }
}
