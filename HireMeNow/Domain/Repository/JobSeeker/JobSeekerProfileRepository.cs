using AutoMapper;
using Domain.Data;
using Domain.DTOs.AuthUserDTO;
using Domain.DTOs.JobSeekerDTOs;
using Domain.Helpers;
using Domain.Interface.JobSeeker;
using Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repository.JobSeeker
{
    public class JobSeekerProfileRepository : IJobSeekerProfileRepository
    {
        protected readonly AppDbContext _context;
        public JobSeekerProfileRepository(AppDbContext context)
        {
            _context = context;
        }

        //JobSeeker       
        public async Task<JobSeekerInfoDTO> GetJobSeekerDetailsAsync(Guid jobseekerId)
        {
            var profile = await _context.JobSeekers.FirstOrDefaultAsync(e => e.JobSeekerId == jobseekerId);
            if (profile == null)
                return null;

            var dto = new JobSeekerInfoDTO
            {
                UserName = profile.UserName,
                FirstName = profile.FirstName,
                LastName = profile.LastName,
                Email = profile.Email,
                Phone = profile.Phone,
                Role = profile.Role,
                Image = profile.Image
            };

            return dto;
        }

        public async Task<AuthUserDTO> UpdateJobSeekerDetailsAsync(AuthUserDTO updatedProfile)
        {
            var existingProfile = _context.AuthUsers.FirstOrDefault(e => e.SystemUserId == updatedProfile.JobseekerId);
            var existingProfile2 = _context.JobSeekers.FirstOrDefault(e => e.JobSeekerId == updatedProfile.JobseekerId);
            if (existingProfile == null || existingProfile2 == null)
            {
                return null;
            }
            if (updatedProfile.Image != null)
            {
                byte[] byteArray = ConvertImageToByteArray(updatedProfile.Image);
                existingProfile2.Image = byteArray;
            }
            if (!string.IsNullOrEmpty(updatedProfile.FirstName))
            {
                existingProfile.FirstName = updatedProfile.FirstName;
                existingProfile2.FirstName = updatedProfile.FirstName;
            }
            if (!string.IsNullOrEmpty(updatedProfile.LastName))
            {
                existingProfile.LastName = updatedProfile.LastName;
                existingProfile2.LastName = updatedProfile.LastName;
            }
            if (!string.IsNullOrEmpty(updatedProfile.Phone))
            {
                existingProfile.Phone = updatedProfile.Phone;
                existingProfile2.Phone = updatedProfile.Phone;
            }
            if (!string.IsNullOrEmpty(updatedProfile.Password))
            {
                existingProfile.Password = updatedProfile.Password;
            }
            if (!string.IsNullOrEmpty(updatedProfile.UserName))
            {
                existingProfile.UserName = updatedProfile.UserName;
                existingProfile2.UserName = updatedProfile.UserName;
            }
            await _context.SaveChangesAsync();
            return updatedProfile;
        }
        public byte[] ConvertImageToByteArray(IFormFile imageFile)
        {
            using (var memoryStream = new MemoryStream())
            {
                imageFile.CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        //Profile
        public async Task AddProfileAsync(JobSeekerProfile profile)
        {
            profile.JobSeekerProfileId = Guid.NewGuid();
            _context.JobSeekerProfiles.Add(profile);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateProfileAsync(JobSeekerProfile profile)
        {
            var existingProfile = _context.JobSeekerProfiles.FirstOrDefault(e => e.JobSeekerId == profile.JobSeekerId && e.JobSeekerProfileId== profile.JobSeekerProfileId);
            if (existingProfile != null)
            {
                existingProfile.ProfileName = profile.ProfileName;
                existingProfile.ProfileSummary = profile.ProfileSummary;
                await _context.SaveChangesAsync();  
            }                
        }

        public Task<JobSeekerProfile> GetJobSeekerProfileById(Guid jobseekerId, Guid profileId)
        {
            return  _context.JobSeekerProfiles.FirstOrDefaultAsync(p => p.JobSeekerId == jobseekerId && p.JobSeekerProfileId == profileId);
        }

        public async Task<JobSeekerDTO> GetProfile(Guid jobseekerId, Guid profileId)
        {
            //var jobSeekerProfile =  _context.JobSeekerProfiles.FirstOrDefault(p => p.JobSeekerId == jobseekerId && p.JobSeekerProfileId== profileId);
            var jobSeekerProfile = await _context.JobSeekerProfiles
        .Include(p => p.JobSeeker)
        .Include(p => p.Qualifications)
        .Include(p => p.JobSeekerProfileSkills)
            .ThenInclude(s => s.Skill)
        .Include(p => p.WorkExperiences)
        .FirstOrDefaultAsync(p => p.JobSeekerId == jobseekerId && p.JobSeekerProfileId == profileId);
            if (jobSeekerProfile == null)
            {
                return null;
            }
            var dto = new JobSeekerDTO
            {
                UserName = jobSeekerProfile.JobSeeker.UserName,
                FirstName = jobSeekerProfile.JobSeeker.FirstName,
                LastName = jobSeekerProfile.JobSeeker.LastName,
                Phone = jobSeekerProfile.JobSeeker.Phone,
                Email = jobSeekerProfile.JobSeeker.Email,
                Image = jobSeekerProfile.JobSeeker.Image,
                Role = jobSeekerProfile.JobSeeker.Role,
                ProfileName= jobSeekerProfile.ProfileName,
                ProfileSummary = jobSeekerProfile.ProfileSummary,
                Qualification = jobSeekerProfile.Qualifications
            .Select(q => new QualificationDTO
            {
                Name = q.Name,
                Description = q.Description
            }).ToList(),

                JobSeekerProfileSkill = jobSeekerProfile.JobSeekerProfileSkills
            .Select(s => new SkillDTO
            {
                Name = s.Skill.Name
            }).ToList(),

                WorkExperience = jobSeekerProfile.WorkExperiences
            .Select(w => new WorkExperienceDTO
            {
                JobTitle = w.JobTitle,
                CompanyName = w.CompanyName,
                Summary = w.Summary,
                ServiceStart = w.ServiceStart,
                ServiceEnd = w.ServiceEnd
            }).ToList()

            };
            return dto;
        }  

        public async Task<List<JobSeekerProfile>> GetAllProfilesByIdAsync(Guid jobseekerId)
        {
            return await _context.JobSeekerProfiles
                .Where(p => p.JobSeekerId == jobseekerId)
                .Include(p => p.JobSeeker)
                .Include(p => p.JobSeekerProfileSkills)
                    .ThenInclude(s => s.Skill)
                .Include(p => p.Qualifications)
                .Include(p => p.Resumes)
                .Include(p => p.WorkExperiences)
                        .ToListAsync();
        }

        public async Task<bool> DeleteProfileAsync(Guid profileId)
        {
            var profile = await _context.JobSeekerProfiles.Include(p => p.JobSeekerProfileSkills)
                .Include(p => p.WorkExperiences)
                .Include(p => p.Qualifications)
                .Include(p => p.Resumes)     
                .FirstOrDefaultAsync(p => p.JobSeekerProfileId == profileId);
            if (profile == null) return false;
            if (profile.JobSeekerProfileSkills.Any())
                _context.JobSeekerProfileSkills.RemoveRange(profile.JobSeekerProfileSkills);
            if (profile.WorkExperiences.Any())
                _context.WorkExperiences.RemoveRange(profile.WorkExperiences);
            if (profile.Qualifications.Any())
                _context.Qualifications.RemoveRange(profile.Qualifications);
            //if (profile.Resume != null)
            //{
            //    bool isUsedElsewhere = await _context.JobSeekerProfiles
            //        .AnyAsync(p => p.ResumeId == profile.ResumeId && p.JobSeekerProfileId != profile.JobSeekerProfileId);
            //    if (!isUsedElsewhere)
            //    {
            //        _context.Resumes.Remove(profile.Resume);
            //    }
            //}
            _context.JobSeekerProfiles.Remove(profile);
            await _context.SaveChangesAsync();
            return true;
        }

        //Qualification
        public async Task AddQualificationAsync(Guid profileId, Qualification qualification)
        {
            qualification.JobseekerProfileId = profileId;
            _context.Qualifications.Add(qualification);
            await _context.SaveChangesAsync();
        }

        public List<Qualification> GetQualifications(Guid profileId)
        {
            return _context.Qualifications
               .Where(qualification => qualification.JobseekerProfileId == profileId)
               .ToList();
        }

        public Task<Qualification> GetQualificationById(Guid profileId, Guid qualificationId)
        {
            return  _context.Qualifications.FirstOrDefaultAsync(q => q.JobseekerProfileId == profileId && q.QualificationId == qualificationId);
        }

        public async Task UpdateQualificationAsync(Qualification qualification)
        {
            _context.Qualifications.Update(qualification);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteQualificationAsync(Qualification qualification)
        {
            _context.Qualifications.Remove(qualification);
            await _context.SaveChangesAsync();
        }     

        //Skill
        public async Task AddSkillAsync(Guid profileId, JobSeekerProfileSkillDTO skillDTO)
        {           
            var exist = await _context.JobSeekerProfileSkills.FirstOrDefaultAsync(j=>j.JobSeekerProfileId== profileId && j.SkillId== skillDTO.SkillId);
            if (exist != null) 
            {
                throw new SkillAlreadyExistsException("Skill Already Exists");
            }
            var skill = new JobSeekerProfileSkill
            {
                JobSeekerProfileId = profileId,
                SkillId = skillDTO.SkillId
            };
            _context.JobSeekerProfileSkills.Add(skill);
            await _context.SaveChangesAsync();                       
        }

        public async Task<List<JobSeekerProfileSkill>> GetSkillsAsync(Guid profileId)
        {
            return await _context.JobSeekerProfileSkills.Where(j=> j.JobSeekerProfileId == profileId).Include(j => j.Skill).ToListAsync();
        }

        public async Task<JobSeekerProfileSkill?> GetSkillByIdAsync(Guid profileId, Guid skillId)
        {
            return await _context.JobSeekerProfileSkills
                                 .Include(j => j.Skill)
                                 .FirstOrDefaultAsync(j => j.JobSeekerProfileId == profileId
                                                           && j.SkillId == skillId);
        }

        public async Task<JobSeekerProfileSkill> UpdateSkillAsync(JobSeekerProfileSkill skill)
        {
            _context.JobSeekerProfileSkills.Update(skill);
            await _context.SaveChangesAsync();
            return skill;
        }

        public async Task<bool> DeleteSkillAsync(Guid profileId, Guid skillId)
        {
            var skill =  _context.JobSeekerProfileSkills.FirstOrDefault(j => j.JobSeekerProfileId == profileId && j.SkillId==skillId);
            if (skill == null) return false;
            _context.JobSeekerProfileSkills.Remove(skill);
            await _context.SaveChangesAsync();
            return true;
        }

        //Resume
        public async Task AddResumeAsync(Guid profileId, Resume resume)
        {           
            resume.JobSeekerProfileId = profileId;
            _context.Resumes.Add(resume);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Resume>> GetAllResumesByJobSeekerIdAsync(Guid jobseekerId)
        {
            return await _context.Resumes.Include(r => r.JobSeekerProfile).Where(r => r.JobSeekerProfile.JobSeekerId == jobseekerId).ToListAsync();            
        }

        public async Task<Resume> GetResumeAsync(Guid profileId)
        {
            return await _context.Resumes.FirstOrDefaultAsync(p => p.JobSeekerProfileId == profileId);            
        }       

        public async Task<Resume?> GetResumeByIdAsync(Guid resumeId)
        {
            return await _context.Resumes.FirstOrDefaultAsync(r => r.ResumeId == resumeId);
        }

        public async Task<Resume> UpdateResumeAsync(Resume resume)
        {
            _context.Resumes.Update(resume);
            await _context.SaveChangesAsync();
            return resume;
        }

        public async Task<bool> DeleteResumeAsync(Guid resumeId)
        {
            var resume = await _context.Resumes.FirstOrDefaultAsync(r => r.ResumeId == resumeId);
            if (resume == null) return false;            
            _context.Resumes.Remove(resume);
            await _context.SaveChangesAsync();
            return true;
        }

        //Experience
        public async Task AddExperienceAsync(Guid profileId, WorkExperience experience)
        {
            experience.JobSeekerProfileId = profileId;
            _context.WorkExperiences.Add(experience);
            await _context.SaveChangesAsync();
        }

        public List<WorkExperience> GetExperience(Guid profileId)
        {
            return  _context.WorkExperiences.Where(w => w.JobSeekerProfileId == profileId).ToList();
        }
        public Task<WorkExperience> GetExperienceById(Guid profileId, Guid experienceId)
        {
            return _context.WorkExperiences.FirstOrDefaultAsync(w => w.JobSeekerProfileId == profileId && w.WorkExperienceId == experienceId);
        }
        public async Task UpdateExperienceAsync(Guid profileId, WorkExperience experience)
        {
            experience.JobSeekerProfileId = profileId;
            _context.WorkExperiences.Update(experience);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> DeleteExperienceAsync(Guid experienceId)
        {
            var experience = await _context.WorkExperiences.FindAsync(experienceId);            
            if (experience == null) return false;
            _context.WorkExperiences.Remove(experience);
            await _context.SaveChangesAsync();
            return true;            
        }
    }
}
