using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Domain.Interface.JobSeeker
{
    public interface IJobSeekerRepository
    {
        //Search Job
        Task<IEnumerable<JobPost>> GetAllJobsAsync();
        Task<JobPost?> GetJobByIdAsync(Guid jobPostId);

        // Apply Job
        Task<JobApplication?> GetByJobAndSeekerAsync(Guid jobPostId, Guid jobSeekerId);
        Task AddAsync(JobApplication jobApplication);
        // Task SaveChangesAsync();
        Task<IEnumerable<JobApplication>> GetAppliedJobsAsync(Guid jobSeekerId);
       // Task<JobApplication?> GetAppliedJobByIdAsync(Guid jobApplicationId);
        Task<JobApplication?> GetByIdAsync(Guid applicationId);

        //Save Job
        //Task<SavedJob> SaveJobAsync(SavedJob savedJob);
        //Task<IEnumerable<SavedJob>> GetSavedJobsAsync(Guid jobSeekerId);
        //Task<SavedJob?> GetSavedJobByIdAsync(Guid savedJobId);
        //Task<bool> RemoveSavedJobAsync(Guid savedJobId);
    }
}
