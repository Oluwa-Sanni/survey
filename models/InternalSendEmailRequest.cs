namespace IPS_survey.models
{
    public class InternalSendEmailRequest
    {
        public string UID { get; set; }
        public string? ToEmailAddress { get; set; }
        public string? FromEmailAddress { get; set; }
        public string? Subject { get; set; }
        public string? Body { get; set; }
        public string? SenderApplicationType { get; set; }
        public List<IFormFile>? Attachment { get; set; }
    }
}
