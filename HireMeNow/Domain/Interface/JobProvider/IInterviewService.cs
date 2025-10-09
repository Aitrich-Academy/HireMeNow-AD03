using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.DTOs.JobProviderDTO;

namespace Domain.Interface.JobProvider
{
    public interface IInterviewService
    {
        Task<List<InterviewDto>> GetInterviewsByJobProviderAsync(Guid jobProviderId);
        Task<InterviewResponseDto?> UpdateInterviewAsync(UpdateInterviewDto dto);
        Task<InterviewDto?> GetByIdAsync(Guid id);
        Task<List<InterviewDto>> GetInterviewsByJobSeekerAsync(Guid jobSeekerId);
        Task<List<InterviewDto>> GetInterviewsByJobPostAsync(Guid jobPostId);
        Task<InterviewDto> CreateInterviewAsync(CreateInterviewDto dto);
        Task<bool> DeleteInterviewAsync(Guid interviewId);
        Task<int> GetInterviewCountByJobProviderAsync(Guid jobProviderId);




    }
}
