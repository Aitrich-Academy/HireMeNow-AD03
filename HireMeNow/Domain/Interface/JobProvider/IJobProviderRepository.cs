using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.JobProvider
{
    public interface IJobProviderRepository
    {
        Task<CompanyUser>GetCompanyUserByIDAsync(Guid CompanyUserID);
        Task<List<CompanyUser>> GetCompanyUserListAsync(Guid JobProviderID);
        Task<CompanyUser> AddNewCompanyUserAsync(CompanyUser NewCompanyUser);
        Task<CompanyUser> GetCompanyUserAsync(Guid CompanyUserID,Guid JobProviderID);
        Task<CompanyUser> UpdateCompanyUserAsync(Guid CompanyUserID, CompanyUser UpdatedCompanyUser);
        Task<CompanyUser> DeleteCompanyUserAsync(Guid CompanyUserID);
        Task<int> GetCompanyUserCountAsync();
        Task<JobProviderCompany> GetJobProviderCompanyByIDAsync(Guid JobProviderID);
        Task<List<JobProviderCompany>> GetJobProviderCompaniesList();
        Task<List<JobProviderCompany>> GetJobProviderCompaniesByLocationID(Guid LocationID);
        Task<List<JobProviderCompany>> GetJobProviderCompaniesByIndustryIDAsync(Guid industryID);
        Task<JobProviderCompany> CreateNewJobProviderCompanyAsync(Guid systemID, JobProviderCompany NewCompany);
        Task<JobProviderCompany> UpdateJobProviderCompanyAsync(Guid jobProviderID, JobProviderCompany UpdatedCompany);
        Task<JobProviderCompany> DeleteJobProviderCompanyAsync(Guid jobProviderID);
        Task<int> GetJobProviderCompanyCountAsync();

    }
}
