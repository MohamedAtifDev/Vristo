using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VristoAPI.Application.DTOs;
using VristoAPI.Application.Models;

namespace VristoAPI.Application.Interfaces
{
    public interface IAuth
    {
        Task<APIResponse<AuthDTO>> Register(Register register);
        Task<APIResponse<AuthDTO>> Login(Login Login);
    }
}
