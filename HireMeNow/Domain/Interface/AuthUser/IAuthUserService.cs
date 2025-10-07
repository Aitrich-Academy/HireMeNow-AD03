using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.LogInDTO;
using Domain.Enums;

namespace Domain.Interface.AuthUser
{
    public interface IAuthUserService
    {
       // Task<LoginDto?> LoginAsync(string email, string password,Roles role);
        Task<LoginDto?> LoginAsync(string email, string password);
        string GenerateJwtToken(Domain.Models.AuthUser user);

    }
}
