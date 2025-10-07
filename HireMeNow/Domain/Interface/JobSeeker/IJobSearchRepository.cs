using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.JobSeekerDTO;
using Domain.Enums;
using Domain.Models;


namespace Domain.Interface.JobSeeker
{
    public interface IJobSearchRepository
    {

        Task<IEnumerable<JobPost>> SearchJobsAsync(Guid? locationId, string? jobTitle, JobType? jobType);
        Task<JobPost?> GetJobByIdAsync(Guid jobPostId);
        
        Task<JobApplication> ApplyJobAsync(JobApplication application);
        Task<JobApplication?> GetApplicationByIdAsync(Guid applicationId);
       // Task<SavedJob> SaveJobAsync(SavedJob savedJob);
       // Task<IEnumerable<SavedJob>> GetSavedJobsByJobSeekerAsync(Guid jobSeekerId);
        Task<Guid> SaveJobAsync(SavedJob entity);
        Task<IEnumerable<SavedJob>> GetSavedJobsAsync(Guid jobSeekerId);
        Task<IEnumerable<JobApplication>> GetAppliedJobsAsync(Guid jobSeekerId);

        //
        Task<JobApplication?> GetByIdAsync(Guid id);
    }
}
