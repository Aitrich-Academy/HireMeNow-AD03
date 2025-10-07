using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Enums;
using Domain.Interface.SignUp;
using Domain.Models;

namespace Domain.Repository.SignUp
{
    public class SignUpRequestRepository:ISignUpRequestRepository
    {
        private readonly AppDbContext _context;
        public SignUpRequestRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task<SignUpRequest?> GetSignupRequestByIdAsync(Guid signupId)
        {
            return await _context.SignUpRequests.FindAsync(signupId);
        }
        public async Task<Guid> AddSignUpRequestAsync(SignUpRequest request)
        {
            request.Status=SignUpRequestStatus.Pending;
           await _context.SignUpRequests.AddAsync(request);
            await _context.SaveChangesAsync();
            return request.SignInId;
        }
        public async Task UpdateSignupRequestAsync(SignUpRequest request)
        {
            _context.SignUpRequests.Update(request);
           await _context.SaveChangesAsync();
        }
    }
}
