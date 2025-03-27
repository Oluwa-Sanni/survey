using IPS_survey.models;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text.Json;

namespace IPS_survey.Services
{
    public class EmailService : IEmailService
    {
        private readonly HttpClient _httpClient;
        private readonly ApplicationSettings _appSettings;
        private readonly ILoggerManager _logger;

        public EmailService(IOptions<ApplicationSettings> option, IHttpClientFactory httpClientFactory, ILoggerManager logger)
        {
            _httpClient = httpClientFactory.CreateClient("EmailConfig");
            this._appSettings = option.Value;
            this._logger = logger;
        }
        public string LoadTemplateForBD()
        {
            string fileName = "EmailTemplate/test.html"; // Update with your folder/file name
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (System.IO.File.Exists(filePath))
            {
                return File.ReadAllText(filePath); // Reads the file content
            }
            else
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }
        }
        public string LoadTemplateForCustomer()
        {
            string fileName = "EmailTemplate/questionaire-received.html"; // Update with your folder/file name
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, fileName);

            if (System.IO.File.Exists(filePath))
            {
                return File.ReadAllText(filePath); // Reads the file content
            }
            else
            {
                throw new FileNotFoundException($"File not found: {filePath}");
            }
        }
        public async Task<Response<string>> SendMailAttachment(InternalSendEmailRequest apiInput, string token, CancellationToken ctx)
        {

            HttpRequestMessage message = new HttpRequestMessage(HttpMethod.Post, "Email/SendEmailWithAttachment");

            var time = DateTime.UtcNow;

            message.Headers.Add("Accept", "application/json");
            message.Headers.Add("X-Client-Id", _appSettings.ClientId);
            message.Headers.Add("X-TimeStamp", DateTime.UtcNow.ToString());
            message.Headers.Add("X-Seed-Id", UtilityService.GenerateAsymptoticHash(time, _appSettings.AuthenticatedPassword, _appSettings.ClientId));
            message.Headers.Add("X-Api-Key", _appSettings.ApiKey);
            if (!string.IsNullOrEmpty(token))
            {
                message.Headers.Add("Authorization", $"Bearer {token}");

            }
            var request = new MultipartFormDataContent();
            // Add string data
            request.Add(new StringContent(apiInput.ToEmailAddress), "ToEmailAddress");
            request.Add(new StringContent(apiInput.FromEmailAddress), "FromEmailAddress");
            request.Add(new StringContent(apiInput.Subject), "Subject");
            request.Add(new StringContent(apiInput.Body), "Body");
            request.Add(new StringContent("summary-report"), "SenderApplicationType");

            // Add file data

            //var fileStream = new FileStream(filePath, FileMode.Open, FileAccess.Read);
            StreamContent fileContent = null;
            HttpResponseMessage httpResponseMessage = null;
            if(apiInput.Attachment !=  null)
            {
                string filename = apiInput.UID + "-" + apiInput.Attachment[0].FileName;
                string filePath = Path.Combine(Directory.GetCurrentDirectory(), filename);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await apiInput.Attachment[0].CopyToAsync(stream);
                }
                using (var fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
                {

                    fileContent = new StreamContent(fs);
                    fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"); // Adjust content type
                    request.Add(fileContent, "Attachment", filename);


                    message.Content = request;
                    //message.Content = new StringContent(JsonConvert.SerializeObject(apiInput), Encoding.UTF8, "application/json");

                    //var httpClient = httpClientFactory.CreateClient("EmailConfig");
                    httpResponseMessage = await _httpClient.SendAsync(message);

                }
            }
            else
            {
               
                    message.Content = request;
                    //message.Content = new StringContent(JsonConvert.SerializeObject(apiInput), Encoding.UTF8, "application/json");

                    //var httpClient = httpClientFactory.CreateClient("EmailConfig");
                    httpResponseMessage = await _httpClient.SendAsync(message);
 
            }
          



            var contentStream = await httpResponseMessage.Content.ReadAsStringAsync();
            _logger.LogDebug($"Response from send mail with attachment: {contentStream}");
            httpResponseMessage.EnsureSuccessStatusCode();
            var response = JsonSerializer
                     .Deserialize<Response<string>>(contentStream,
                     UtilityService.SharedOptions) ?? new Response<string>();
            return response;
        }

    }
}
