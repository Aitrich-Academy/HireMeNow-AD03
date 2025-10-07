using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interface.SignUp
{
    public interface ISignUpRequestRepository
    {
        Task<SignUpRequest> GetSignupRequestByIdAsync(Guid signupId);
       Task<Guid> AddSignUpRequestAsync(SignUpRequest request);
        Task UpdateSignupRequestAsync(SignUpRequest request);
    }
}
