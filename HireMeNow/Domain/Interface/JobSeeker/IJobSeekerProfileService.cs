using Domain.DTOs.AuthUserDTO;
using Domain.DTOs.JobSeekerDTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.JobSeeker
{
    public interface IJobSeekerProfileService
    {
        //JobSeeker
        Task<JobSeekerInfoDTO> GetJobSeekerDetailsAsync(Guid jobseekerId);
        Task<AuthUserDTO> UpdateJobSeekerDetailsAsync(AuthUserDTO updatedProfile);

        //Profile
        Task<bool> AddProfileAsync(JobSeekerProfileDTO profileDTO);
        Task<bool> UpdateProfileAsync(JobSeekerProfileDTO profileDTO);
        Task<List<JobSeekerProfile>> GetAllProfilesByIdAsync(Guid jobseekerId);
        Task<JobSeekerDTO> GetProfile(Guid jobseekerId, Guid profileId);        
        Task<bool> DeleteProfileAsync(Guid jobseekerId, Guid profileId);

        //Qualification
        Task<bool> AddQualificationAsync(Guid jobseekerId, Guid profileId, QualificationDTO qualificationDTO);
        List<QualificationDTO> GetQualifications(Guid profileId);
        Task<bool> UpdateQualificationAsync(Guid jobseekerId, Guid profileId,Guid qualificationId, QualificationDTO qualificationDTO);
        Task<bool> DeleteQualificationAsync(Guid jobseekerId, Guid profileId, Guid qualificationId);

        //Skill
        Task<bool> AddSkillAsync(Guid jobseekerId, Guid profileId, JobSeekerProfileSkillDTO skillDTO);
        Task<List<JobSeekerProfileSkill>> GetSkillsAsync(Guid profileId);
        Task<JobSeekerProfileSkill> GetSkillByIdAsync(Guid profileId, Guid skillId);
        //Task<bool> UpdateSkillAsync(Guid profileId, Guid skillId, JobSeekerProfileSkillDTO skillDTO);
        Task<bool> DeleteSkillAsync(Guid profileId, Guid skillId);

        //Resume
        Task<bool> AddResumeAsync(Guid jobseekerId, Guid profileId, ResumeDTO resumeDTO);
        Task<List<Resume>> GetAllResumesByJobSeekerIdAsync(Guid jobseekerId);
        Task<ResumeDTO> GetResumeAsync(Guid profileId);        
        Task<Resume> GetResumeByIdAsync(Guid resumeId);
        Task<bool> UpdateResumeAsync(Guid profileId, ResumeDTO resumeDTO);
        Task<bool> DeleteResumeAsync(Guid resumeId);

        //Experience
        Task<bool> AddExperienceAsync(Guid jobseekerId, Guid profileId, WorkExperienceDTO experienceDTO);
        Task <List<WorkExperienceDTO>> GetExperience(Guid profileId);
        Task<bool> UpdateExperienceAsync(Guid jobseekerId, Guid profileId, Guid experienceId, WorkExperienceDTO experienceDTO);
        Task<bool> DeleteExperienceAsync(Guid jobseekerId, Guid profileId, Guid experienceId);
    }
}


