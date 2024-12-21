using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using VristoAPI.Application.DTOs;
using VristoAPI.Application.Interfaces;
using VristoAPI.Application.Models;
using VristoAPI.Application.Services;
namespace VristoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController(IAuth Auth) : ControllerBase
    {
    
        [HttpPost]
        [Route("Register")]
       public async Task<APIResponse<AuthDTO>> RegisterAsync([FromBody]Register register)
        {
            if (!ModelState.IsValid)
            {
            
                return new APIResponse<AuthDTO> { IsSuccess = false, StatusCode = (int)HttpStatusCode.BadRequest, Message = ErrorsHandler.HandleErrors(ModelState) };
            }
            else
            {
                var result = await Auth.Register(register);
                return result;

            }
            
        }


       [HttpPost]
        [Route("Login")]
        public async Task<APIResponse<AuthDTO>> LoginAsync([FromBody] Login Login)
        {
            if (!ModelState.IsValid)
            {
            


                return new APIResponse<AuthDTO> { IsSuccess = false, StatusCode = (int)HttpStatusCode.BadRequest,  Message = ErrorsHandler.HandleErrors(ModelState) };
            }
            else
            {
                var result = await Auth.Login(Login);
                return result;

            }
        }
    }
}

