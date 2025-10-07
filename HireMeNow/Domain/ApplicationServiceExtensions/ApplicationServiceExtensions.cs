using Domain.Data;
using Domain.Interface.JobSeeker;
using Domain.Repository.JobSeeker;
using Domain.Service.JobSeeker;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HireMeNow.ApplicationExtension
{
    public static class ApplicationServiceExtensions
    {
        public static void AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Register controllers
            services.AddControllers();

            // Register AppDbContext with SQL Server
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IJobSeekerProfileService, JobSeekerProfileService>();
            services.AddScoped<IJobSeekerProfileRepository, JobSeekerProfileRepository>();
        }
    }
}
