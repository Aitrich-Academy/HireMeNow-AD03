using AutoMapper;
using Domain.DTOs.JobProviderDTO;
using Domain.DTOs.JobSeekerDTO;
using Domain.DTOs.LogInDTO;
using Domain.DTOs.SignUpDTO;
using Domain.Models;
using HireMeNowAD03.RequestObject.JobProvider;
using HireMeNowAD03.RequestObject.JobProvider.HireMeNow_WebApi.API.JobProvider.RequestObjects;
using HireMeNowAD03.RequestObject.JobSeeker;

namespace HireMeNowAD03.Mapping
{
    public class AutoMapperProfiles:Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<JobSeekerSignupRequest, SignUpRequest>();
            CreateMap<JobProviderSignupRequest, SignUpRequest>();
            CreateMap<SignUpRequest, AuthUser>();

            CreateMap<JobSeekerSignupRequest, SignUpRequestDto>();
            CreateMap<JobProviderSignupRequest, SignUpRequestDto>();
            CreateMap<SignupRequest, SignUpRequestDto>();
            CreateMap<SignUpRequestDto, SignUpRequest>();
            CreateMap<AuthUser, LoginDto>();

            //JobSeekerControll 
            

           // CreateMap<JobPost, JobPostDto>()
           //.ForMember(dest => dest.CompanyName, opt => opt.MapFrom(src => src.JobProviderCompany.CompanyName));

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
