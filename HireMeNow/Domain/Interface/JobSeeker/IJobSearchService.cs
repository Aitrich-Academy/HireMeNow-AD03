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
    public interface IJobSearchService
    {
        Task<IEnumerable<JobSearchResultDto>> SearchJobsAsync(Guid? locationId, string? jobTitle, JobType? jobType);
        Task<JobPostDto?> GetJobByIdAsync(Guid id);
        Task<JobApplicationDto> ApplyJobAsync(JobApplicationDto dto);
        Task<JobApplicationDto?> GetApplicationByIdAsync(Guid applicationId);
        Task<IEnumerable<JobApplicationDto>> GetAppliedJobsAsync(Guid jobSeekerId);

        //
        
        Task<JobApplicationDto?> GetAppliedJobByIdAsync(Guid applicationId);






    }
}
