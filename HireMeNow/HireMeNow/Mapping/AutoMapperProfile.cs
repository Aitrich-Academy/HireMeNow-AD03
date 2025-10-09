using AutoMapper;
using Domain.DTOs.JobSeekerDTOs;
using Domain.Models;
using HireMeNowAD03.RequestObject.JobSeeker;

namespace HireMeNowAD03.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() {
            CreateMap<SignUpRequest, SystemUser>().ReverseMap();
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
        }
    }
}
