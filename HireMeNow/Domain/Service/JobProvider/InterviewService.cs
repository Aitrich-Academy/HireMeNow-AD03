using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Domain.DTOs.JobProviderDTO;
using Domain.Interface.JobProvider;
using Domain.Models;

namespace Domain.Service.JobProvider
{
    public class InterviewService:IInterviewService
    {
        private readonly IInterviewRepository _interviewRepository;
        private readonly IMapper _mapper;
        public InterviewService(IInterviewRepository interviewRepository, IMapper mapper)
        {
            _interviewRepository = interviewRepository;
            _mapper = mapper;
        }
        //public async Task<List<InterviewDto>> GetInterviewsByJobProviderAsync(Guid jobProviderId)
        //{
        //    var interviews = await _interviewRepository.GetInterviewsByJobProviderIdAsync(jobProviderId);
        //    return _mapper.Map<List<InterviewDto>>(interviews);
        //}
        public async Task<List<InterviewDto>> GetInterviewsByJobProviderAsync(Guid jobProviderId)
        {
            var interviews = await _interviewRepository.GetInterviewsByJobProviderIdAsync(jobProviderId);

            return interviews.Select(i => new InterviewDto
            {
                InterviewId = i.InterviewId,
                InterviewDate = i.InterviewDate,
                InterviewTime = i.InterviewTime,
                InterviewMode = i.InterviewMode,
                InterviewStatus = i.InterviewStatus,
                JobApplication = new InterviewApplicationDto
                {
                    JobApplicationId = i.JobApplication.JobApplicationId,
                    CoverLetter = i.JobApplication.CoverLetter,
                    AppliedDate = i.JobApplication.AppliedDate,
                    ApplicationStatus = i.JobApplication.ApplicationStatus,
                    JobSeeker = new JobSeekerSummaryDto
                    {
                        JobSeekerId = i.JobApplication.JobSeeker.JobSeekerId,
                        FirstName = i.JobApplication.JobSeeker.FirstName,
                        LastName = i.JobApplication.JobSeeker.LastName,
                        Email = i.JobApplication.JobSeeker.Email,
                        Phone = i.JobApplication.JobSeeker.Phone
                    },
                    JobPost = new JobPostSummaryDto
                    {
                        JobPostId = i.JobApplication.JobPost.JobPostId,
                        JobTitle = i.JobApplication.JobPost.JobTitle,
                        JobSummary = i.JobApplication.JobPost.JobSummary,
                      //  CompanyName = i.JobApplication.JobPost.JobProviderCompany.CompanyName
                    }
                }
            }).ToList();

        }
        public async Task<InterviewResponseDto?> UpdateInterviewAsync(UpdateInterviewDto dto)
        {
            var interview = await _interviewRepository.GetByIdAsync(dto.InterviewId);
            if (interview == null)
                throw new Exception("Interview not found");

            _mapper.Map(dto, interview);

             await _interviewRepository.UpdateAsync(interview);
            return _mapper.Map<InterviewResponseDto>(interview);
        }
        public async Task<InterviewDto?> GetByIdAsync(Guid id)
        {
            var interview = await _interviewRepository.GetByIdAsync(id);
            if (interview == null) return null;

            return _mapper.Map<InterviewDto>(interview);
        }
        public async Task<List<InterviewDto>> GetInterviewsByJobSeekerAsync(Guid jobSeekerId)
        {
            var interviews = await _interviewRepository.GetByJobSeekerIdAsync(jobSeekerId);

            // Map Interview → InterviewDto
            return _mapper.Map<List<InterviewDto>>(interviews);
        }
        public async Task<List<InterviewDto>> GetInterviewsByJobPostAsync(Guid jobPostId)
        {
            var interviews = await _interviewRepository.GetByJobPostIdAsync(jobPostId);

            // Map Interview → InterviewDto
            return _mapper.Map<List<InterviewDto>>(interviews);
        }
        public async Task<InterviewDto> CreateInterviewAsync(CreateInterviewDto dto)
        {
            var interview = _mapper.Map<Interview>(dto);

            interview.InterviewId = Guid.NewGuid();

            await _interviewRepository.AddAsync(interview);

            return _mapper.Map<InterviewDto>(interview);
        }
        public async Task<int> GetInterviewCountByJobProviderAsync(Guid jobProviderId)
        {
            return await _interviewRepository.CountByJobProviderAsync(jobProviderId);
        }
        public async Task<bool> DeleteInterviewAsync(Guid interviewId)
        {
            var interview = await _interviewRepository.GetByIdAsync(interviewId);
            if (interview == null)
                return false;

            await _interviewRepository.DeleteAsync(interview);
            return true;
        }










    }
}
