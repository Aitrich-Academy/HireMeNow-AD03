using Domain.Interface.JobProvider;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider
{
    public class JobProviderService:IJobProviderService
    {
        private readonly IJobProviderRepository _repo;

        public JobProviderService(IJobProviderRepository repo)
        {
            _repo = repo;
        }

        public async Task<CompanyUser> GetCompanyUserByID(Guid CompanyUserID)
        {
            return await _repo.GetCompanyUserByIDAsync(CompanyUserID);
        }

        public async Task<List<CompanyUser>> GetCompanyUserListAsync(Guid JobProviderID)
        {
            return await _repo.GetCompanyUserListAsync(JobProviderID);
        }

        public async Task<CompanyUser> GetCompanyUserAsync(Guid CompanyUserID, Guid JobProviderID)
        {
            return await _repo.GetCompanyUserAsync(CompanyUserID, JobProviderID);
        }

        public async Task<CompanyUser> AddNewCompanyUserAsync(CompanyUser NewCompanyUser)
        {
            return await _repo.AddNewCompanyUserAsync(NewCompanyUser);
        }

        public async Task<CompanyUser> UpdateCompanyUserAsync(Guid CompanyUserID, CompanyUser UpdatedCompanyUser)
        {
            return await _repo.UpdateCompanyUserAsync(CompanyUserID, UpdatedCompanyUser);
        }

        public async Task<CompanyUser> DeleteCompanyUserAsync(Guid CompanyUserID)
        {
            return await _repo.DeleteCompanyUserAsync(CompanyUserID);
        }

        public async Task<int> GetCompanyUserCountAsync()
        {
            return await _repo.GetCompanyUserCountAsync();
        }

        public async Task<JobProviderCompany> GetJobProviderCompanyByIDAsync(Guid JobProviderID)
        {
            return await _repo.GetJobProviderCompanyByIDAsync(JobProviderID);
        }

        public async Task<List<JobProviderCompany>> GetJobProviderCompaniesList()
        {
            return await _repo.GetJobProviderCompaniesList();
        }

        public async Task<List<JobProviderCompany>> GetJobProviderCompaniesByLocationID(Guid LocationID)
        {
            return await _repo.GetJobProviderCompaniesByLocationID(LocationID);
        }
        public async Task<List<JobProviderCompany>> GetJobProviderCompaniesByIndustryIDAsync(Guid industryID)
        {
            return await _repo.GetJobProviderCompaniesByIndustryIDAsync(industryID);
        }

        public async Task<JobProviderCompany> CreateNewJobProviderCompanyAsync(Guid systemID, JobProviderCompany NewCompany)
        {
            return await _repo.CreateNewJobProviderCompanyAsync(systemID, NewCompany);
        }

        public async Task<JobProviderCompany> UpdateJobProviderCompanyAsync(Guid jobProviderID, JobProviderCompany UpdatedCompany)
        {
            return await _repo.UpdateJobProviderCompanyAsync(jobProviderID, UpdatedCompany);
        }

        public async Task<JobProviderCompany> DeleteJobProviderCompanyAsync(Guid jobProviderID)
        {
            return await _repo.DeleteJobProviderCompanyAsync(jobProviderID);
        }
        public async Task<int> GetJobProviderCompanyCountAsync()
        {
            return await _repo.GetJobProviderCompanyCountAsync();
        }

    }
}
