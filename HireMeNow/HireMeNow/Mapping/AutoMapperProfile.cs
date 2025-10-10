using AutoMapper;
using Domain.DTOs.JobProviderDTO;
using Domain.DTOs.JobSeekerDTO;
using Domain.DTOs.JobSeekerDTOs;
using Domain.DTOs.LogInDTO;
using Domain.DTOs.SignUpDTO;
using Domain.Models;
using HireMeNowAD03.RequestObject.JobProvider;
using HireMeNowAD03.RequestObject.JobProvider.HireMeNow_WebApi.API.JobProvider.RequestObjects;
using HireMeNowAD03.RequestObject.JobSeeker;

namespace HireMeNowAD03.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile()
        {
			CreateMap<AuthUser, JobSeeker>().ReverseMap();
            CreateMap<AuthUser, SystemUser>().ReverseMap();
			
			CreateMap<JobSeekerDTO, JobSeeker>().ReverseMap();
            CreateMap<JobSeekerInfoDTO, JobSeeker>().ReverseMap();

            CreateMap<JobSeekerProfileRequestDTO, JobSeekerProfile>().ReverseMap();
            CreateMap<JobSeekerProfileRequestDTO, JobSeekerProfileDTO>().ReverseMap();
            CreateMap<JobSeekerProfileDTO, JobSeekerProfile>().ReverseMap();

            CreateMap<QualificationRequestDTO,Qualification>().ReverseMap();
            CreateMap<QualificationRequestDTO, QualificationDTO>().ReverseMap();
            CreateMap<QualificationDTO,Qualification>().ReverseMap();

            CreateMap<WorkExperienceRequestDTO, WorkExperience>().ReverseMap();
            CreateMap<WorkExperienceRequestDTO, WorkExperienceDTO>().ReverseMap();
            CreateMap<WorkExperienceDTO, WorkExperience>().ReverseMap();

            CreateMap<ResumeRequestDTO, Resume>().ReverseMap();
            CreateMap<ResumeRequestDTO, ResumeDTO>().ReverseMap();
            CreateMap<ResumeDTO, Resume>().ReverseMap();

            CreateMap<JobSeekerProfileSkillDTO, JobSeekerProfileSkill>().ReverseMap();

            CreateMap<SkillDTO, Skill>().ReverseMap();
			
            CreateMap<JobSeekerSignupRequest, SignUpRequest>();
            CreateMap<JobProviderSignupRequest, SignUpRequest>();
            CreateMap<SignUpRequest, AuthUser>();

            CreateMap<JobSeekerSignupRequest, SignUpRequestDto>();
            CreateMap<JobProviderSignupRequest, SignUpRequestDto>();
            CreateMap<SignupRequest, SignUpRequestDto>();
            CreateMap<SignUpRequestDto, SignUpRequest>();
            CreateMap<AuthUser, LoginDto>();
           
            CreateMap<ApplyJobRequest, JobApplicationDto>();
            CreateMap<JobApplicationDto, JobApplication>().ReverseMap();

            CreateMap<JobPost, JobPostDto>();
            CreateMap<JobPost, JobSearchResultDto>();
            CreateMap<SaveJobRequest, SavedJobDto>();
            CreateMap<SavedJobDto, SavedJob>();
            CreateMap<SavedJob, SavedJobDto>();

            CreateMap<JobSeeker, ApplicantDto>();
            CreateMap<JobApplication, JobApplicationDetailsDto>();
            CreateMap<JobApplication,ApplicantDto>();
            CreateMap<JobApplication, ApplicationDto>();
            CreateMap<ShortList, ShortListDto>();

            CreateMap<Interview, InterviewDto>();
          
            CreateMap<JobApplication, InterviewApplicationDto>();
          
            CreateMap<JobSeeker, JobSeekerSummaryDto>();
            CreateMap<JobPost, JobPostSummaryDto>();

            CreateMap<UpdateInterviewDto, Interview>().ReverseMap();
            CreateMap<UpdateInterviewRequest, UpdateInterviewDto>().ReverseMap();
            CreateMap<Interview , InterviewResponseDto>().ReverseMap();
            CreateMap<CreateInterviewRequest, CreateInterviewDto>();
            CreateMap<CreateInterviewDto, Interview>();

        }
    }
}
