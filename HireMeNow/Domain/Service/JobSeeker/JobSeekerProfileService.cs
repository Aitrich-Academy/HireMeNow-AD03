using AutoMapper;
using Azure.Core;
using Domain.DTOs.AuthUserDTO;
using Domain.DTOs.JobSeekerDTOs;
using Domain.Interface.JobSeeker;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Service.JobSeeker
{
    public class JobSeekerProfileService : IJobSeekerProfileService
    {
        public readonly IJobSeekerProfileRepository _profileRepository;
        private readonly IMapper _mapper;
        public JobSeekerProfileService(IJobSeekerProfileRepository profileRepository, IMapper mapper)
        {
            _mapper = mapper;
            _profileRepository = profileRepository;
        }

        //JobSeeker
        public async Task<JobSeekerInfoDTO> GetJobSeekerDetailsAsync(Guid jobseekerId)
        {
            var result = await _profileRepository.GetJobSeekerDetailsAsync(jobseekerId);
            return result;
        }

        public async Task<AuthUserDTO> UpdateJobSeekerDetailsAsync(AuthUserDTO updatedProfile)
        {
            var result = await _profileRepository.UpdateJobSeekerDetailsAsync(updatedProfile);
            return result;
        }

        //Profile
        public async Task<bool> AddProfileAsync(JobSeekerProfileDTO profileDTO)
        {
            var profile = _mapper.Map<JobSeekerProfile>(profileDTO);
            await _profileRepository.AddProfileAsync(profile);
            return true;
        }

        public async Task<bool> UpdateProfileAsync(JobSeekerProfileDTO profileDTO)
        {
            var profile = _mapper.Map<JobSeekerProfile>(profileDTO);
            await _profileRepository.UpdateProfileAsync(profile);
            return true;
        }

        public async Task<List<JobSeekerProfile>> GetAllProfilesByIdAsync(Guid jobseekerId)
        {
            return await _profileRepository.GetAllProfilesByIdAsync(jobseekerId);
        }

        public async Task<JobSeekerDTO> GetProfile(Guid jobseekerId, Guid profileId)
        {
            return await _profileRepository.GetProfile(jobseekerId, profileId);
        }
            
        public async Task<bool> DeleteProfileAsync(Guid jobseekerId, Guid profileId)
        {
            var profile = await _profileRepository.GetJobSeekerProfileById(jobseekerId, profileId);
            if (profile != null)
            {
                await _profileRepository.DeleteProfileAsync(profileId);
                return true;
            }
            else
            {
                //throw new Exception("Profile not found");
                return false;
            }
        }

        //Qualification
        public async Task<bool> AddQualificationAsync(Guid jobseekerId, Guid profileId, QualificationDTO qualificationDTO)
        {
            var profile = await _profileRepository.GetJobSeekerProfileById(jobseekerId, profileId);
            if (profile != null)
            {
                var Qualification = _mapper.Map<Qualification>(qualificationDTO);
                await _profileRepository.AddQualificationAsync(profileId, Qualification);
                return true;
            }
            else
            {
                //throw new Exception("Profile not found");
                return false;
            }
        }

        public List<QualificationDTO> GetQualifications(Guid profileId)
        {
            var Qualifications = _profileRepository.GetQualifications(profileId);
            var QualificationDtos = _mapper.Map<List<QualificationDTO>>(Qualifications);
            return QualificationDtos;
        }

        public async Task<bool> UpdateQualificationAsync(Guid jobseekerId, Guid profileId,Guid qualificationId, QualificationDTO qualificationDTO)
        {
            var profile = await _profileRepository.GetJobSeekerProfileById(jobseekerId, profileId);
            if (profile != null)
            {
                var qualification = await _profileRepository.GetQualificationById(profileId, qualificationId);
                if (qualification == null) return false;
                qualification.Name = qualificationDTO.Name;
                qualification.Description = qualificationDTO.Description;                
                await _profileRepository.UpdateQualificationAsync(qualification);
                return true;
            }
            else
            {
                //throw new Exception("Profile not found");
                return false;
            }
        }

        public async Task<bool> DeleteQualificationAsync(Guid jobseekerId, Guid profileId, Guid qualificationId)
        {
            var profile = await _profileRepository.GetJobSeekerProfileById(jobseekerId, profileId);
            if (profile != null)
            {
                var qualification = await _profileRepository.GetQualificationById(profileId, qualificationId);
                if (qualification == null) return false;
                 await _profileRepository.DeleteQualificationAsync(qualification);
                return true;
            }
            else
            {
                return false;
            }
        }

        //Skill
        public async Task<bool> AddSkillAsync(Guid jobseekerId, Guid profileId, JobSeekerProfileSkillDTO skillDTO)
        {                    
            var profile = await _profileRepository.GetJobSeekerProfileById(jobseekerId, profileId);
            if (profile == null) return false;            
            //var skill = _mapper.Map<JobSeekerProfileSkill>(skillDTO);
            await _profileRepository.AddSkillAsync(profileId,skillDTO);
            return true;           
        }

        public async Task<List<JobSeekerProfileSkill>>GetSkillsAsync(Guid profileId)
        {
            return await _profileRepository.GetSkillsAsync(profileId);
        }

        public async Task<JobSeekerProfileSkill> GetSkillByIdAsync(Guid profileId, Guid skillId)
        {
            var skill = await _profileRepository.GetSkillByIdAsync(profileId, skillId);
            if (skill == null) return null;
            return skill;            
        }

        //public async Task<bool> UpdateSkillAsync(Guid profileId,Guid skillId, JobSeekerProfileSkillDTO skillDTO)
        //{
        //    var skill = await _profileRepository.GetSkillByIdAsync(profileId, skillId);
        //    if (skill == null) return false;
        //    skill.JobSeekerProfileId = skillDTO.JobSeekerProfileId;
        //    skill.SkillId = skillDTO.SkillId;
        //    await _profileRepository.UpdateSkillAsync(skill);
        //    return true;           
        //}

        public async Task<bool> DeleteSkillAsync(Guid profileId, Guid skillId)
        {
            return await _profileRepository.DeleteSkillAsync(profileId,skillId);
        }

        //Resume
        public async Task<bool> AddResumeAsync(Guid jobseekerId, Guid profileId,ResumeDTO resumeDTO)
        {
            var profile = await _profileRepository.GetJobSeekerProfileById(jobseekerId, profileId);
            if (profile != null)
            {
                var resume = await _profileRepository.GetResumeAsync(profileId);
                if (resume == null)
                {
                    resume = new Resume
                    {
                        ResumeId = Guid.NewGuid(),
                        ResumeTitle = resumeDTO.ResumeTitle,
                        File = resumeDTO.File
                    };
                    await _profileRepository.AddResumeAsync(profileId, resume);
                    return true;
                }
                else
                {
                    throw new Exception("Resume Already exists for given Profile.");
                    //return false;
                }                
            }
            else
            {
                throw new Exception("Profile not found");
                //return false;
            }
        }

        public async Task<List<Resume>> GetAllResumesByJobSeekerIdAsync(Guid jobseekerId)
        {
            return await _profileRepository.GetAllResumesByJobSeekerIdAsync(jobseekerId);
        }

        public async Task<ResumeDTO> GetResumeAsync(Guid profileId)
        {
            var resume = await _profileRepository.GetResumeAsync(profileId);
            if (resume == null) return null;
            return new ResumeDTO
            {
                ResumeId = resume.ResumeId,
                ResumeTitle = resume.ResumeTitle,
                File = resume.File,
            };
        }               

        public async Task<Resume> GetResumeByIdAsync(Guid resumeId)
        {
            var resume = await _profileRepository.GetResumeByIdAsync(resumeId);
            if (resume == null) return null;
            return new Resume
            {
                ResumeId = resume.ResumeId,
                ResumeTitle = resume.ResumeTitle,
                File = resume.File
            };
        }

        public async Task<bool> UpdateResumeAsync(Guid profileId, ResumeDTO resumeDTO)
        {
            var existing = await _profileRepository.GetResumeAsync(profileId);
            if (existing == null) return false;
            existing.ResumeTitle = resumeDTO.ResumeTitle ?? existing.ResumeTitle;
            //existing.File = resumeDTO.File ?? existing.File;
            var updated = await _profileRepository.UpdateResumeAsync(existing);
            return true;
        }

        public async Task<bool> DeleteResumeAsync(Guid resumeId)
        {
            return await _profileRepository.DeleteResumeAsync(resumeId);
        }

        //Experience
        public async Task<bool> AddExperienceAsync(Guid jobseekerId, Guid profileId, WorkExperienceDTO experienceDTO)
        {
            var profile = await _profileRepository.GetJobSeekerProfileById(jobseekerId, profileId);
            if (profile != null)
            {
                var experience = _mapper.Map<WorkExperience>(experienceDTO);
                await _profileRepository.AddExperienceAsync(profileId, experience);
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task <List<WorkExperienceDTO>> GetExperience(Guid profileId)
        {
            var experience = _profileRepository.GetExperience(profileId);
            var experienceDTO = _mapper.Map<List<WorkExperienceDTO>>(experience);
            return experienceDTO;
        }

        public async Task<bool> UpdateExperienceAsync(Guid jobseekerId, Guid profileId, Guid experienceId, WorkExperienceDTO experienceDTO)
        {
            var profile = await _profileRepository.GetJobSeekerProfileById(jobseekerId, profileId);
            if (profile != null)
            {
                var experience = await _profileRepository.GetExperienceById(profileId, experienceId);
                if (experience == null) return false;
                experience.JobTitle = experienceDTO.JobTitle;
                experience.CompanyName = experienceDTO.CompanyName;
                experience.Summary = experienceDTO.Summary;
                experience.ServiceStart = experienceDTO.ServiceStart;
                experience.ServiceEnd = experienceDTO.ServiceEnd;
                await _profileRepository.UpdateExperienceAsync(profileId, experience);
                return true;
            }
            else
            {
                //throw new Exception("Profile not found");
                return false;
            }
        }

        public async Task<bool> DeleteExperienceAsync(Guid jobseekerId, Guid profileId, Guid experienceId)
        {
            var profile = await _profileRepository.GetJobSeekerProfileById(jobseekerId, profileId);
            if (profile != null)
            {
                await _profileRepository.DeleteExperienceAsync(experienceId);
                return true;
            }
            else
            {
                //throw new Exception("Profile not found");
                return false;
            }
        }

    }
}
