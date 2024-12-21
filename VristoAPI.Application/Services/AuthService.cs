


using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using VristoAPI.Application.DTOs;
using VristoAPI.Application.Interfaces;
using VristoAPI.Application.Models;
using VristoAPI.Domain.Entities;

namespace VristoAPI.Application.Services
{
    public class AuthService(UserManager<ApplicationUser> userManager,IOptions<JWT> option) : IAuth
    {
        public async Task<APIResponse<AuthDTO>> Login(Login Login)
        {
            var user =await userManager.FindByEmailAsync(Login.Email);
         if ( user is null)
                return new APIResponse<AuthDTO> { IsSuccess = false, StatusCode = (int)HttpStatusCode.NotFound, Message = "User Not Found" };

         if (!await userManager.CheckPasswordAsync(user, Login.Password))
                return new APIResponse<AuthDTO> { IsSuccess = false, StatusCode = (int)HttpStatusCode.BadRequest, Message = "Invalid UserName Or Password" };



         var token=await CreateJwtToken(user);
            var AuthDTO = new AuthDTO
            {
                Email = Login.Email,
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                ExpiresAt = token.ValidTo
            };
            return new APIResponse<AuthDTO> { IsSuccess = true, StatusCode = (int)HttpStatusCode.OK, Data =AuthDTO, Message = "Login Successfully" };

        }

        public async Task<APIResponse<AuthDTO>> Register(Register register)
        {
            if(await userManager.FindByEmailAsync(register.Email) is not null)
            {
                return new APIResponse<AuthDTO> { IsSuccess = false, StatusCode = (int)HttpStatusCode.BadRequest, Message = "User Already Exist" };
            }
            else
            {
                var user = new ApplicationUser
                {
                    Email = register.Email,
                    UserName=register.Email

               };
               var result = await userManager.CreateAsync(user,register.Password);

               if (!result.Succeeded)
               {
                   var errors = string.Empty;
                   foreach (var Error in result.Errors)
                   {
                       errors += $"{Error.Description},";

                   }
                   return new APIResponse<AuthDTO> { IsSuccess = false, StatusCode = (int)HttpStatusCode.BadRequest, Message = errors };

               }
               else
               {
                 
                   return new APIResponse<AuthDTO> { IsSuccess = false, StatusCode = (int)HttpStatusCode.OK, Message = "User Created Successfully" ,Data = null };

               }
           }
        }


      

    

        private async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await userManager.GetClaimsAsync(user);



         var roles = await userManager.GetRolesAsync(user);
            var roleClaims = new List<Claim>();

            foreach (var role in roles)
                roleClaims.Add(new Claim("Roles", role));

            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim("uid", user.Id)
            }
            .Union(userClaims)
            .Union(roleClaims);




            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(option.Value.Key));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            var jwtSecurityToken = new JwtSecurityToken(
                issuer: option.Value.Issuer,
                audience: option.Value.Audience,
                
                expires: DateTime.Now.AddDays(option.Value.DurationInDays),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }
    }
}
