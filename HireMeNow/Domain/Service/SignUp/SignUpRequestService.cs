using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.Internal;
using Domain.DTOs.SignUpDTO;
using Domain.Enums;
using Domain.Helpers;
using Domain.Interface.AuthUser;
using Domain.Interface.SignUp;
using Domain.Models;
using Org.BouncyCastle.Cms;

namespace Domain.Service.SignUp
{
    public class SignUpRequestService:ISignUpRequestService
    {
        private readonly ISignUpRequestRepository _signupRepo;
        private readonly IAuthUserRepository _authRepo;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        public SignUpRequestService(ISignUpRequestRepository signupRepo, IAuthUserRepository authRepo, IMapper mapper, IEmailService emailService)
        {
            _signupRepo = signupRepo;
            _authRepo = authRepo;
            _mapper = mapper;
            _emailService = emailService;
        }
        // Step 1: Create Signup Request + Send Verification Email

        public async Task<Guid> CreateSignupRequestAsync(SignUpRequestDto dto, Roles role)
        {
            var request = _mapper.Map<SignUpRequest>(dto);
            var id = await _signupRepo.AddSignUpRequestAsync(request);

            // Send verification email
            var verificationLink  = $"https://localhost:7297/api/auth/verify-email/{id}";
            await _emailService.SendEmailAsync(new MailRequest
            {
                ToEmail = request.Email,
                Subject = "Verify your email",
                Body = $"Click this link to verify: <a href='{verificationLink}'>Verify Email</a>"
            });

            return id;
        }
        // Step 2: Verify Email
        public async Task<bool> VerifyEmailAsync(Guid signupId)
        {
            var request = await _signupRepo.GetSignupRequestByIdAsync(signupId);
            if (request == null) return false;

            request.Status = SignUpRequestStatus.Verified;
             await _signupRepo.UpdateSignupRequestAsync(request);
            return true;
        }

        // Step 3: Create AuthUser (Set Password)
        //public async Task<Domain.Models.AuthUser?> CreateUserAsync(Guid signupId, string password, Roles role)
        //{
        //    var request = await _signupRepo.GetSignupRequestByIdAsync(signupId);

        //    if (request == null || request.Status != SignUpRequestStatus.Verified)
        //        throw new InvalidOperationException("Invalid Request or Email not verified");

        //    // ✅ Manually map values
        //    var authUser = new Domain.Models.AuthUser
        //    {
        //        UserName = request.UserName,
        //        FirstName = request.FirstName,
        //        LastName = request.LastName,
        //        Email = request.Email,
        //        Phone = request.Phone,
        //        Role = role,
        //        Password = password
        //    };

        //    Domain.Models.AuthUser createdUser;

        //    if (role == Roles.JobSeeker)
        //    {
        //        createdUser = await _authRepo.AddAuthUserJobSeekerAsync(authUser);
        //    }
        //    else if (role == Roles.JobProvider)
        //    {
        //        createdUser = await _authRepo.AddAuthUserJobProviderAsync(authUser, null);
        //    }
        //    else
        //    {
        //        throw new InvalidOperationException("Unsupported role for signup.");
        //    }

        //    // ✅ Update SignUpRequest status
        //    request.Status = SignUpRequestStatus.Created;
        //    await _signupRepo.UpdateSignupRequestAsync(request);

        //    return createdUser;
        //}


        public async Task<Domain.Models.AuthUser?> CreateUserAsync(Guid signupId, string password, Roles role)
        {
            try
            {
                // 1️⃣ Get the signup request
                var request = await _signupRepo.GetSignupRequestByIdAsync(signupId);
                if (request == null)
                {
                    throw new InvalidOperationException($"No signup request found with ID: {signupId}");
                }

                if (request.Status != SignUpRequestStatus.Verified)
                {
                    throw new InvalidOperationException($"Signup request status is not verified. Current status: {request.Status}");
                }

                // 2️⃣ Map values to AuthUser
                var authUser = new Domain.Models.AuthUser
                {
                    UserName = request.UserName,
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    Email = request.Email,
                    Phone = request.Phone,
                    Role = role,
                    Password = password
                };

                Domain.Models.AuthUser createdUser;

                // 3️⃣ Insert into DB based on role
                if (role == Roles.JobSeeker)
                {
                    try
                    {
                        createdUser = await _authRepo.AddAuthUserJobSeekerAsync(authUser);
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException("Error adding JobSeeker: " + ex.Message, ex);
                    }
                }
                else if (role == Roles.JobProvider)
                {
                    try
                    {
                        JobProviderCompany? company = null; // null = create new company automatically
                        createdUser = await _authRepo.AddAuthUserJobProviderAsync(authUser, company);
                    }
                    catch (Exception ex)
                    {
                        throw new InvalidOperationException("Error adding JobProvider: " + ex.Message, ex);
                    }
                }
                else
                {
                    throw new InvalidOperationException($"Unsupported role for signup: {role}");
                }

                // 4️⃣ Update signup request status
                try
                {
                    request.Status = SignUpRequestStatus.Created;
                    await _signupRepo.UpdateSignupRequestAsync(request);
                }
                catch (Exception ex)
                {
                    throw new InvalidOperationException("Failed to update signup request status: " + ex.Message, ex);
                }

                return createdUser;
            }
            catch (Exception ex)
            {
                // ✅ Log the full exception for debugging
                Console.WriteLine("CreateUserAsync Exception: " + ex.Message);
                Console.WriteLine("Inner Exception: " + ex.InnerException?.Message);
                throw; // rethrow to see it in API response
            }
        }



    }
}
