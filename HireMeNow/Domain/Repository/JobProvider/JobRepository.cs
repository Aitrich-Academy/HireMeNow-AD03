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
    public class JobRepository : IJobRepository
    {
        private readonly AppDbContext _context;

        public JobRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<JobPost> CreateNewJobPostByCompanyUserAsync(Guid companyUserID, JobPost NewPost)
        {
            var CompanyUserExists = await _context.CompanyUsers.FirstOrDefaultAsync(Su => Su.CompanyUserId == companyUserID);
            if (CompanyUserExists == null)
            {
                return null;
            }
            else
            {
                NewPost.CreatorID = companyUserID;
                NewPost.JobProviderID = CompanyUserExists.JobProviderId;
                NewPost.PostedDate = DateTime.Now;
                NewPost.JobPostId = Guid.NewGuid();
                // NewPost.LocationId =CompanyUserExists.
                //NewPost.IndustryID = CompanyUserExists.

                _context.JobPosts.Add(NewPost); 
                await _context.SaveChangesAsync();      

                return NewPost;
            }
        }

        public async Task<JobPost> UpdateJobPostAsync(Guid jobPostID, JobPost UpdatedPost)
        {
            var JobPostExists = await _context.JobPosts.FirstOrDefaultAsync(Jp => Jp.JobPostId == jobPostID);
            if (JobPostExists == null)
            {
                return null;
            }
            else
            {
                JobPostExists.JobTitle =UpdatedPost.JobTitle;
                JobPostExists.JobSummary =UpdatedPost.JobSummary;
                JobPostExists.CompanyName =UpdatedPost.CompanyName;
                JobPostExists.CreatorID = UpdatedPost.CreatorID;
                JobPostExists.JobProviderID = UpdatedPost.JobProviderID;
                JobPostExists.JobType=UpdatedPost.JobType;
                JobPostExists.LocationId=UpdatedPost.LocationId;
                JobPostExists.IndustryId =UpdatedPost.IndustryId;

                _context.JobPosts.Update(JobPostExists);
                await _context.SaveChangesAsync();
                return JobPostExists;
            }
        }

        public async Task<List<JobPost>> GetAllJobListsByCompanyUserIDAsync(Guid CompanyUserID)
        {
            var CompanyUseExists = await _context.CompanyUsers.FirstOrDefaultAsync(Cu => Cu.CompanyUserId == CompanyUserID);
            if (CompanyUseExists == null)
            {
                return null;
            }
            else
            {
               var ListAllJobs = await _context.JobPosts.Where(J => J.CreatorID == CompanyUserID).ToListAsync();
                return ListAllJobs;
                
            }
        }

        public async Task<List<JobPost>> GetAllJobListByJobProviderCompanyAsync(Guid jobProviderCompanyID)
        {
            var JobProviderExists = await _context.JobProviderCompanys.AnyAsync(Jp => Jp.JobProviderId == jobProviderCompanyID);
            if (!JobProviderExists)
            {
                return null;
            }
            else
            {
                var ListAllJobs = await _context.JobPosts.Where(J => J.JobProviderID == jobProviderCompanyID).ToListAsync();
                return ListAllJobs;

            }
        }

        public async Task<JobPost> GetDetailedJobPostAsync(Guid jobPostID)
        {
            return await _context.JobPosts.FirstOrDefaultAsync(Jp => Jp.JobPostId == jobPostID);
        }

        public async Task<List<JobPost>> GetJobsByLocationAsync(Guid locID)
        {
            var LocationExists = await _context.Locations.AnyAsync(Jp => Jp.LocationId == locID);
            if (!LocationExists)
            {
                return null;
            }
            else
            {
                var ListAllJobs = await _context.JobPosts.Where(J => J.LocationId == locID).ToListAsync();
                return ListAllJobs;

            }
        }
        public async Task<List<JobPost>> GetJobsByIndustryAsync(Guid indID)
        {
            var IndustryExists = await _context.Industrys.AnyAsync(Jp => Jp.IndustryId == indID);
            if (!IndustryExists)
            {
                return null;
            }
            else
            {
                var ListAllJobs = await _context.JobPosts.Where(J => J.IndustryId == indID).ToListAsync();
                return ListAllJobs;

            }
        }

        public async Task<List<JobPost>> GetAllJobPostListAsync()
        {
            return await _context.JobPosts.ToListAsync();
        }

        public async Task<JobPost> DeleteJobByIDAsync(Guid jobID)
        {
            var jobToDelete = await _context.JobPosts.FindAsync(jobID);
            if (jobToDelete != null)
            {
                _context.JobPosts.Remove(jobToDelete);
                await _context.SaveChangesAsync();
                return jobToDelete;
            }
            return null;
        }

        public async Task<int> GetJobPostCountAsync()
        {
            return await _context.JobPosts.CountAsync();
        }


    }
}
