using IPS_survey.models;

namespace IPS_survey.Services
{
    public interface IEmailService
    {
        string LoadTemplateForBD();
        string LoadTemplateForCustomer();
        Task<Response<string>> SendMailAttachment(InternalSendEmailRequest apiInput, string token, CancellationToken ctx);
    }
}