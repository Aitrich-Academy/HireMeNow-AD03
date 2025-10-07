using AutoMapper;
using HireMeNowAD03.RequestObject.JobProvider;
using Domain.DTOs.JobProviderDTO;
using Domain.Models;

namespace HireMeNowAD03.Mapping
{
    public class AutoMapperProfile:Profile
    {
        public AutoMapperProfile() 
        {
            CreateMap<CompanyUser,CreateCompanyUserDTO>().ReverseMap();
            CreateMap<CreateCompanyUserRequest, CreateCompanyUserDTO>().ReverseMap();

            CreateMap<CompanyUser, UpdateCompanyUserDTO>().ReverseMap();
            CreateMap<UpdateCompanyUserRequest, UpdateCompanyUserDTO>().ReverseMap();

            CreateMap<JobProviderCompany, CreateJobProviderCompanyDTO>().ReverseMap();
            CreateMap<CreateJobProviderCompanyDTO, CreateJobProviderCompanyRequest>().ReverseMap();

            CreateMap<JobProviderCompany, UpdateJobProviderCompanyDTO>().ReverseMap();
            CreateMap<UpdateJobProviderCompanyDTO, UpdateJobProviderCompanyRequest>().ReverseMap();

            CreateMap<JobPost, CreateNewJobPostDTO>().ReverseMap();
            CreateMap<CreateNewJobPostDTO, CreateNewJobPostRequest>().ReverseMap();

            CreateMap<JobPost, UpdateJobPostDTO>().ReverseMap();
            CreateMap<UpdateJobPostDTO, UpdateJobPostRequest>().ReverseMap();
        }
    }
}
