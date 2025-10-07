using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.JobProvider
{
    public interface IJobRepository
    {
        Task<JobPost> CreateNewJobPostByCompanyUserAsync(Guid companyUserID, JobPost NewPost);
        Task<JobPost> UpdateJobPostAsync(Guid jobPostID, JobPost UpdatedPost);
        Task<List<JobPost>> GetAllJobListsByCompanyUserIDAsync(Guid CompanyUserID);
        Task<List<JobPost>> GetAllJobListByJobProviderCompanyAsync(Guid jobProviderCompanyID);
        Task<JobPost> GetDetailedJobPostAsync(Guid jobPostID);
        Task<List<JobPost>> GetJobsByLocationAsync(Guid locID);
        Task<List<JobPost>> GetJobsByIndustryAsync(Guid indID);
        Task<List<JobPost>> GetAllJobPostListAsync();
        Task<JobPost> DeleteJobByIDAsync(Guid jobID);
        Task<int> GetJobPostCountAsync();
    }
}
