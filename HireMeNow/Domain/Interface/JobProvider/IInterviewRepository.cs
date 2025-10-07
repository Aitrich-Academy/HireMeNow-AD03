using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.JobProviderDTO;
using Domain.Models;

namespace Domain.Interface.JobProvider
{
    public interface IInterviewRepository
    {
        Task<List<Interview>> GetInterviewsByJobProviderIdAsync(Guid jobProviderId);
        Task<Interview?> GetByIdAsync(Guid id);
        Task UpdateAsync(Interview interview);
        Task<Interview?> GetByInterviewIdAsync(Guid id);
        Task<List<Interview>> GetByJobSeekerIdAsync(Guid jobSeekerId);
        Task<List<Interview>> GetByJobPostIdAsync(Guid jobPostId);
        Task AddAsync(Interview interview);
        Task DeleteAsync(Interview interview);
        Task<int> CountByJobProviderAsync(Guid jobProviderId);


    }
}
