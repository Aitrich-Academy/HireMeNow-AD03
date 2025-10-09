using Domain.Interface.JobProvider;
using Domain.Models;
using Domain.Repository.JobProvider;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobProvider
{
    public class JobService :IJobService
    {
        private readonly IJobRepository _repo;

        public JobService(IJobRepository repo)
        {
            _repo = repo;
        }
        public async Task<JobPost> CreateNewJobPostByCompanyUserAsync(Guid companyUserID, JobPost NewPost)
        {
           return await _repo.CreateNewJobPostByCompanyUserAsync(companyUserID, NewPost);
        }

        public async Task<JobPost> UpdateJobPostAsync(Guid jobPostID, JobPost UpdatedPost)
        {
            return await _repo.UpdateJobPostAsync(jobPostID, UpdatedPost);
        }

        public async Task<List<JobPost>> GetAllJobListsByCompanyUserIDAsync(Guid CompanyUserID)
        {
            return await _repo.GetAllJobListsByCompanyUserIDAsync(CompanyUserID);
        }

        public async Task<List<JobPost>> GetAllJobListByJobProviderCompanyAsync(Guid jobProviderCompanyID)
        {
            return await _repo.GetAllJobListByJobProviderCompanyAsync(jobProviderCompanyID);
        }

        public async Task<JobPost> GetDetailedJobPostAsync(Guid jobPostID)
        {
            return await _repo.GetDetailedJobPostAsync(jobPostID);
        }

        public async Task<List<JobPost>> GetJobsByLocationAsync(Guid locID)
        {
            return await _repo.GetJobsByLocationAsync(locID);
        }

        public async Task<List<JobPost>> GetJobsByIndustryAsync(Guid indID)
        {
            return await _repo.GetJobsByIndustryAsync(indID);
        }

        public async Task<List<JobPost>> GetAllJobPostListAsync()
        {
            return await _repo.GetAllJobPostListAsync();
        }

        public async Task<JobPost> DeleteJobByIDAsync(Guid jobID)
        {
            return await _repo.DeleteJobByIDAsync(jobID);
        }

        public async Task<int> GetJobPostCountAsync()
        {
            return await _repo.GetJobPostCountAsync();
        }


    }
}
