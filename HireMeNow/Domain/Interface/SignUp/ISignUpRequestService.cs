using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.SignUpDTO;
using Domain.Enums;

namespace Domain.Interface.SignUp
{
    public interface ISignUpRequestService
    {
        // Create a signup request for JobSeeker or JobProvider
        Task<Guid> CreateSignupRequestAsync(SignUpRequestDto dto,Roles role);
        // Verify email via signup request ID
        Task<bool> VerifyEmailAsync(Guid signupId);
        // Set password and create AuthUser
         Task<Domain.Models.AuthUser?>CreateUserAsync(Guid signupId, string password,Roles role);
        
    }
}
