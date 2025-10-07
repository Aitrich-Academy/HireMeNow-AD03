using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.JobSeekerDTO;

namespace Domain.Interface.JobSeeker
{
    public interface ISaveJobService
    {
       // Task<SavedJobDto> SaveJobAsync(Guid jobSeekerId, SavedJobDto dto);
        Task<SavedJobDto> SaveJobAsync(SavedJobDto dto);
        Task<IEnumerable<SavedJobDto>> GetSavedJobsAsync(Guid jobSeekerId);
       

       // Task<IEnumerable<SavedJobDto>> GetSavedJobsAsync(Guid jobSeekerId);
       Task<SavedJobDto?> GetSavedJobByIdAsync(Guid jobSeekerId, Guid savedJobId);
        Task<bool> RemoveSavedJobAsync(Guid jobSeekerId, Guid savedJobId);
    }
}
