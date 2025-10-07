using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Domain.DTOs.JobProviderDTO
{
    public class ShortListDto
    {
        public Guid ShortListId { get; set; }
        public Guid JobApplicationId { get; set; }
        public Guid JobSeekerId { get; set; }
        public Guid JobProviderId { get; set; }
        public Guid CompanyUserId { get; set; }
        public ShortListStatus ShortlistStatus { get; set; }
    }
}
