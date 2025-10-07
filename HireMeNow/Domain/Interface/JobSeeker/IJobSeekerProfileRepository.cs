using Domain.DTOs.AuthUserDTO;
using Domain.DTOs.JobSeekerDTOs;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interface.JobSeeker
{
    public interface IJobSeekerProfileRepository
    {
        //JobSeeker
        Task<JobSeekerInfoDTO> GetJobSeekerDetailsAsync(Guid jobseekerId);
        Task<AuthUserDTO> UpdateJobSeekerDetailsAsync(AuthUserDTO updatedProfile);

        //Profile
        Task AddProfileAsync(JobSeekerProfile profile);
        Task UpdateProfileAsync(JobSeekerProfile profile);
        Task<List<JobSeekerProfile>> GetAllProfilesByIdAsync(Guid jobseekerId);
        Task<JobSeekerDTO> GetProfile(Guid jobseekerId, Guid profileId);
        Task<JobSeekerProfile> GetJobSeekerProfileById(Guid jobseekerId, Guid profileId);       
        Task<bool> DeleteProfileAsync(Guid profileId);

        //Qualification
        Task AddQualificationAsync(Guid profileId, Qualification qualification);
        List<Qualification> GetQualifications(Guid profileId);
        Task<Qualification> GetQualificationById(Guid profileId, Guid qualificationId);
        Task UpdateQualificationAsync(Qualification qualification);
        Task DeleteQualificationAsync(Qualification qualification);

        //Skill
        Task AddSkillAsync(Guid profileId, JobSeekerProfileSkillDTO skill);
        Task<List<JobSeekerProfileSkill>> GetSkillsAsync(Guid profileId);
        Task<JobSeekerProfileSkill?> GetSkillByIdAsync(Guid profileId, Guid skillId);
        Task<JobSeekerProfileSkill> UpdateSkillAsync(JobSeekerProfileSkill skill);
        Task<bool> DeleteSkillAsync(Guid profileId, Guid skillId);

        //Resume
        Task AddResumeAsync(Guid profileId, Resume resume);
        Task<List<Resume>> GetAllResumesByJobSeekerIdAsync(Guid jobseekerId);
        Task<Resume> GetResumeAsync(Guid profileId);        
        Task<Resume?> GetResumeByIdAsync(Guid resumeId);
        Task<Resume> UpdateResumeAsync(Resume resume);
        Task<bool> DeleteResumeAsync(Guid resumeId);

        //Experience
        Task AddExperienceAsync(Guid profileId, WorkExperience experience);
        List<WorkExperience> GetExperience(Guid profileId);
        Task<WorkExperience> GetExperienceById(Guid profileId, Guid experienceId);
        Task UpdateExperienceAsync(Guid profileId, WorkExperience experience);
        Task<bool> DeleteExperienceAsync(Guid experienceId);

    }
}
