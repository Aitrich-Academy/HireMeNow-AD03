using Domain.Data;
using Domain.Interface.AuthUser;
using Domain.Interface.JobProvider;
using Domain.Interface.JobSeeker;
using Domain.Interface.SignUp;
using Domain.Repository.AuthUser;
using Domain.Repository.JobProvider;
using Domain.Repository.JobSeeker;
using Domain.Repository.SignUp;
using Domain.Service.AuthUser;
using Domain.Service.JobSeeker;
using Domain.Service.SignUp;
using Microsoft.EntityFrameworkCore;
using Domain.Interface.JobProvider;
using HireMeNowAD03.Mapping;
using Domain.Repository.JobProvider;
using Domain.Service.JobProvider;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace HireMeNowAD03.Extensions
{

    public static class ApplicationServiceExtensions
    {

        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddDbContext<AppDbContext>(options =>
               options.UseSqlServer(config.GetConnectionString("DefaultConnection"))
            );
            services.AddTransient<IEmailService, EmailService>();
            services.AddScoped<ISignUpRequestService, SignUpRequestService>();
            services.AddScoped<IAuthUserService, AuthUserService>();
           // services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IAuthUserRepository, AuthUserRepository>();
            services.AddScoped<ISignUpRequestRepository, SignUpRequestRepository>();
          //  services.AddScoped<IJobSeekerRepository, JobSeekerRepository>();
           // services.AddScoped<IJobSeekerService, JobSeekerService>();
            services.AddScoped<ISaveJobService, SaveJobService>();
            services.AddScoped<ISaveJobRepository, SaveJobRepository>();
            
           // services.AddScoped<IJobProviderService, JobProviderService>();
            services.AddScoped<IInterviewRepository, InterviewRepository>();
            services.AddScoped<IInterviewService, InterviewService>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IApplicationService, ApplicationService>();
            services.AddScoped<IJobSearchRepository,JobSearchRepository>();
            services.AddScoped<IJobSearchService, JobSearchService>();
            services.AddScoped<IJobProviderRepository, JobProviderRepository>();
            services.AddScoped<IJobProviderService, JobProviderService>();
            services.AddScoped<IJobRepository, JobRepository>();
            services.AddScoped<IJobService, JobService>();
        
			services.AddScoped<IJobSeekerProfileService, JobSeekerProfileService>();
            services.AddScoped<IJobSeekerProfileRepository, JobSeekerProfileRepository>();
            return services;
        }
    }
}
