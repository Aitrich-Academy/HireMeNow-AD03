using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Models;

namespace Domain.Interface.AuthUser
{
    public interface IAuthUserRepository
    {
        Task<Domain.Models.AuthUser> AddAuthUserJobSeekerAsync(Domain.Models.AuthUser authUser);
        Task<Domain.Models.AuthUser> AddAuthUserJobProviderAsync(Domain.Models.AuthUser authUser, JobProviderCompany? company=null);
      // Task<Domain.Models.AuthUser?> GetAuthUserByEmailAndRoleAsync(string email, Roles role);
        Task<Domain.Models.AuthUser?> GetAuthUserByEmail(string email);
        // Task<Domain.Models.AuthUser?> GetAuthUserByIdAsync(Guid id);
        // string CreateToken(Domain.Models.AuthUser user);
    }
}
