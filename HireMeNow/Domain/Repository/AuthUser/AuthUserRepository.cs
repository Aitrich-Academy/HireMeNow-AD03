using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.Data;
using Domain.Enums;
using Domain.Interface.AuthUser;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Domain.Repository.AuthUser
{
    public class AuthUserRepository:IAuthUserRepository
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly IConfiguration _config;
        public AuthUserRepository(AppDbContext context, IMapper mapper, IConfiguration config)
        {
            _context = context;
            _mapper = mapper;
            _config = config;
            
        }
        public async Task<Domain.Models.AuthUser> AddAuthUserJobSeekerAsync(Domain.Models.AuthUser authUser)
        {
            authUser.Role=Roles.JobSeeker;
           
            // Add to AuthUser table
            
            // Create JobSeeker linked to AuthUser
            var jobSeeker = new Domain.Models.JobSeeker
            {
                JobSeekerId = authUser.SystemUserId, // use SystemUserId as FK
                JobSeekerNavigation = authUser,
                FirstName = authUser.FirstName,
                LastName = authUser.LastName,
                UserName=authUser.UserName,
                Email = authUser.Email,
                Phone = authUser.Phone,
                Role = authUser.Role
            };
            await _context.AuthUsers.AddAsync(authUser);
            await _context.JobSeekers.AddAsync(jobSeeker);

            
            //// Create empty profile for JobSeeker
            //var profile = new JobSeekerProfile { JobSeekerId = jobSeeker.JobSeekerId };
            //await _context.JobSeekerProfiles.AddAsync(profile);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException ex)
            {
                Console.WriteLine("❌ Error saving changes: " + ex.Message);
                if (ex.InnerException != null)
                    Console.WriteLine("👉 Inner exception: " + ex.InnerException.Message);
                throw; // rethrow or handle
            }


           // await _context.SaveChangesAsync();
            return authUser;
        }
        // Add JobProvider
        public async Task<Domain.Models.AuthUser> AddAuthUserJobProviderAsync(Domain.Models.AuthUser authUser,
            JobProviderCompany? company=null)
        {
            
            authUser.Role = Roles.JobProvider;

            // Add to AuthUser table
            await _context.AuthUsers.AddAsync(authUser);
            await _context.SaveChangesAsync();
            //  Handle company
            if (company == null)
            {
                // If no company provided, create a new one
                company = new JobProviderCompany
                {
                    CompanyName = authUser.UserName ?? "New Company", // or get from request
                    SystemUserId= authUser.SystemUserId,
                    Email = authUser.Email,
                    Role = Roles.JobProvider,
                    //LocationId = Guid.NewGuid(),           // set default or from request
                    //IndustryId = Guid.NewGuid()            // set default or from request

                };
                await _context.JobProviderCompanys.AddAsync(company);
                await _context.SaveChangesAsync(); // ensures JobProviderId is generated
            }
            

            
            var companyUser = new CompanyUser
            {
                SystemUserId = authUser.SystemUserId,
                JobProviderId=company.JobProviderId,
                FirstName = authUser.FirstName,
                LastName = authUser.LastName,
                Email = authUser.Email,
                Phone= authUser.Phone,
                Role=Roles.CompanyUser,
                CompanyName = company.CompanyName

            };


            await _context.CompanyUsers.AddAsync(companyUser);

            await _context.SaveChangesAsync();
            return authUser;
        }
        // Get AuthUser by Email
        //public async Task<Domain.Models.AuthUser?> GetAuthUserByEmailAndRoleAsync(string email, Roles role)
        //{
        //    return await _context.AuthUsers.FirstOrDefaultAsync(u => u.Email == email&& u.Role==role);
        //}
        public async Task<Domain.Models.AuthUser?> GetAuthUserByEmail(string email)
        {
            return await _context.AuthUsers.FirstOrDefaultAsync(u => u.Email == email);
        }

        // Get AuthUser by Id
        //public async Task<Domain.Models.AuthUser?> GetAuthUserByIdAsync(Guid id)
        //{
        //    return await _context.AuthUsers.FirstOrDefaultAsync(u => u.SystemUserId == id);
        //}

    }
}
