using System.ComponentModel.DataAnnotations;
using Domain.Enums;

namespace HireMeNowAD03.RequestObject.JobProvider
{
    public class UpdateApplicationStatusRequest
    {
        public ApplicationStatus Status { get; set; } 
    }
}
