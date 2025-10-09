using Domain.Data;
using Domain.Interface.JobProvider;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.JobProvider
{
    public class JobProviderRepository : IJobProviderRepository
    {
        private readonly AppDbContext _context;

        public JobProviderRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CompanyUser> GetCompanyUserByIDAsync(Guid CompanyUserID)
        {
            return await _context.CompanyUsers.FindAsync(CompanyUserID);
        }


        public async Task<List<CompanyUser>> GetCompanyUserListAsync(Guid JobProviderID)
        {
            return await _context.CompanyUsers.Where(Cu => Cu.JobProviderId == JobProviderID).ToListAsync();
        }

        public async Task<CompanyUser> GetCompanyUserAsync(Guid CompanyUserID, Guid JobProviderID)
        {
            return await _context.CompanyUsers.FirstOrDefaultAsync(Cu => Cu.CompanyUserId == CompanyUserID && Cu.JobProviderId == JobProviderID);
        }

        public async Task<CompanyUser> AddNewCompanyUserAsync(CompanyUser NewCompanyUser)
        {
            bool CompanyUserExist = await _context.CompanyUsers.AnyAsync
                (Cu => Cu.Email == NewCompanyUser.Email &&
                Cu.JobProviderId == NewCompanyUser.JobProviderId);
            if (!CompanyUserExist)
            {
                NewCompanyUser.CompanyUserId = Guid.NewGuid();
                _context.CompanyUsers.Add(NewCompanyUser);
                await _context.SaveChangesAsync();
                return NewCompanyUser;

            }
            else
            {
                return null;
            }

        }

        public async Task<CompanyUser?> UpdateCompanyUserAsync(Guid companyUserId, CompanyUser updatedCompanyUser)
        {
            var existingUser = await _context.CompanyUsers
                .FirstOrDefaultAsync(cu => cu.CompanyUserId == companyUserId);

            if (existingUser == null)
            {
                return null;
            }

            existingUser.FirstName = updatedCompanyUser.FirstName;
            existingUser.LastName = updatedCompanyUser.LastName;
            existingUser.CompanyName = updatedCompanyUser.CompanyName;
            existingUser.CompanyUserRole = updatedCompanyUser.CompanyUserRole;
            existingUser.Email = updatedCompanyUser.Email;
            existingUser.Phone = updatedCompanyUser.Phone;

            _context.CompanyUsers.Update(existingUser);
            await _context.SaveChangesAsync();

            return existingUser;
        }

        public async Task<CompanyUser> DeleteCompanyUserAsync(Guid CompanyUserID)
        {
            var UserToDelete = await _context.CompanyUsers.FirstOrDefaultAsync(Cu => Cu.CompanyUserId == CompanyUserID);
            if (UserToDelete != null)
            {
                _context.CompanyUsers.Remove(UserToDelete);
                await _context.SaveChangesAsync();
                return UserToDelete;
            }
            return null;

        }
        public async Task<int> GetCompanyUserCountAsync()
        {
            return await _context.CompanyUsers.CountAsync();
        }

        public async Task<JobProviderCompany> GetJobProviderCompanyByIDAsync(Guid JobProviderID)
        {
            return await _context.JobProviderCompanys.FirstOrDefaultAsync(Jp => Jp.JobProviderId == JobProviderID);
        }

        public async Task<List<JobProviderCompany>> GetJobProviderCompaniesList()
        {
            return await _context.JobProviderCompanys.ToListAsync();
        }

        public async Task<List<JobProviderCompany>> GetJobProviderCompaniesByLocationID(Guid LocationID)
        {
            return await _context.JobProviderCompanys.Where(jp => jp.LocationId == LocationID).ToListAsync();
        }

        public async Task<List<JobProviderCompany>> GetJobProviderCompaniesByIndustryIDAsync(Guid industryID)
        {
            return await _context.JobProviderCompanys.Where(jp => jp.IndustryId == industryID).ToListAsync();
        }

        public async Task<JobProviderCompany> CreateNewJobProviderCompanyAsync(Guid systemID, JobProviderCompany NewCompany)
        {
            var CompanyExists = await _context.SystemUsers.FirstOrDefaultAsync(Su => Su.SystemUserId == systemID);
            if (CompanyExists == null)
            {
                return null;
            }
            else
            {
                NewCompany.JobProviderId = systemID;
                _context.JobProviderCompanys.Add(NewCompany);
                await _context.SaveChangesAsync();
                return NewCompany;
            }
        }

        public async Task<JobProviderCompany> UpdateJobProviderCompanyAsync(Guid jobProviderID, JobProviderCompany UpdatedCompany)
        {
            var CompanyExists = await _context.JobProviderCompanys.FirstOrDefaultAsync(Jp => Jp.JobProviderId == jobProviderID);
            if (CompanyExists == null)
            {
                return null;
            }
            else
            {
                CompanyExists.CompanyName = UpdatedCompany.CompanyName;
                CompanyExists.Email = UpdatedCompany.Email;
                CompanyExists.Role = UpdatedCompany.Role;
                CompanyExists.IndustryId = UpdatedCompany.IndustryId;
                CompanyExists.LocationId = UpdatedCompany.LocationId;

                _context.JobProviderCompanys.Update(CompanyExists);
                await _context.SaveChangesAsync();
                return CompanyExists;
            }
        }

        public async Task<JobProviderCompany> DeleteJobProviderCompanyAsync(Guid jobProviderID)
        {
            var CompanyExists = await _context.JobProviderCompanys.FirstOrDefaultAsync(Jp => Jp.JobProviderId == jobProviderID);
            var SystemUserExists = await _context.SystemUsers.FirstOrDefaultAsync(Su => Su.SystemUserId == jobProviderID);
            if (CompanyExists == null && SystemUserExists == null)
            {
                return null;
            }
            else
            {
                _context.JobProviderCompanys.Remove(CompanyExists);
                _context.SystemUsers.Remove(SystemUserExists);
                await _context.SaveChangesAsync();
                return CompanyExists;
            }
        }

        public async Task<int> GetJobProviderCompanyCountAsync()
        {
            return await _context.JobProviderCompanys.CountAsync();
        }
    }
}
