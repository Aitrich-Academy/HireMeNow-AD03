using System.ComponentModel.DataAnnotations;

namespace HireMeNowAD03.RequestObject.JobProvider
{
    public class ShortlistApplicationRequest
    {
        [Required]
        public Guid JobProviderId { get; set; }
    }
}
