using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Data;
using Domain.Enums;
using Domain.Interface.JobSeeker;
using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain.Repository.JobSeeker
{
    public class JobSearchRepository:IJobSearchRepository
    {
        private readonly AppDbContext _context;
        public JobSearchRepository(AppDbContext context) => _context = context;

        public async Task<IEnumerable<JobPost>> SearchJobsAsync(Guid? locationId, string? jobTitle, JobType? jobType)
        {
            var query = _context.JobPosts.AsQueryable();

            if (locationId.HasValue)
                query = query.Where(j => j.LocationId == locationId.Value);

            if (!string.IsNullOrEmpty(jobTitle))
                query = query.Where(j => j.JobTitle.Contains(jobTitle));

            if (jobType.HasValue)
                query = query.Where(j => j.JobType == jobType.Value);

            return await query.ToListAsync();
        }
        public async Task<JobPost?> GetJobByIdAsync(Guid jobPostId) =>
           await _context.JobPosts.Include(j => j.JobProviderCompany)
                                  .FirstOrDefaultAsync(j => j.JobPostId == jobPostId);

        public async Task<JobApplication> ApplyJobAsync(JobApplication application)
        {
            application.JobApplicationId = Guid.NewGuid();
            application.AppliedDate = DateTime.UtcNow;
            application.ApplicationStatus = ApplicationStatus.Pending;

            await _context.JobApplications.AddAsync(application);
            await _context.SaveChangesAsync();
            return application;
        }
        public async Task<JobApplication?> GetApplicationByIdAsync(Guid applicationId)
        {
            return await _context.JobApplications
                .Include(a => a.JobPost)
                .Include(a => a.JobSeeker)
                .FirstOrDefaultAsync(a => a.JobApplicationId == applicationId);
        }
        public async Task<Guid> SaveJobAsync(SavedJob entity)
        {
            _context.SavedJobs.Add(entity);
            await _context.SaveChangesAsync();
            return entity.SavedJobId;
        }

        public async Task<IEnumerable<SavedJob>> GetSavedJobsAsync(Guid jobSeekerId)
        {
            return await _context.SavedJobs
                .Include(s => s.JobPost)
                .Where(s => s.JobSeekerId == jobSeekerId)
                .ToListAsync();
        }
        public async Task<IEnumerable<JobApplication>> GetAppliedJobsAsync(Guid jobSeekerId) =>
           await _context.JobApplications.Include(a => a.JobPost)
                                         .Where(a => a.JobSeekerId == jobSeekerId)
                                         .ToListAsync();


        //
        public async Task<JobApplication?> GetByIdAsync(Guid id)
        {
            return await _context.JobApplications
                .Include(j => j.JobPost)
                .FirstOrDefaultAsync(j => j.JobApplicationId == id);
        }




    }


}
