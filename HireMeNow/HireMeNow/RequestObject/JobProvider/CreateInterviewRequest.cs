using Domain.Enums;

namespace HireMeNowAD03.RequestObject.JobProvider
{
    public class CreateInterviewRequest
    {
        public DateTime InterviewDate { get; set; }
        public string InterviewTime { get; set; } = null!;
        public InterviewMode InterviewMode { get; set; }
        public InterviewStatus InterviewStatus { get; set; }

        public Guid JobSeekerId { get; set; }
        public Guid ShortListId { get; set; }
        public Guid ApplicationId { get; set; }  
    }
}
