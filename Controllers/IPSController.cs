using AutoMapper;
using IPS_survey.models;
using IPS_survey.Repos;
using IPS_survey.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;

namespace IPS_survey.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IPSController : ControllerBase
    {
        private readonly ApplicationSettings _appSettings;
        private readonly ILoggerManager _logger;
        private readonly IIdentityAdapter _identityAdapter;
        private readonly IEmailService _emailService;
        private readonly IMapper _automapper;
        private readonly ISurveyRepo _surveyRepo;

        public IPSController(ILoggerManager logger, IOptions<ApplicationSettings> appSettings, IIdentityAdapter identityAdapter, IEmailService emailService, IMapper automapper, ISurveyRepo surveyRepo)
        {
            this._appSettings = appSettings.Value;
            this._logger = logger;
            this._identityAdapter = identityAdapter;
            this._emailService = emailService;
            _automapper = automapper;
            _surveyRepo = surveyRepo;
        }

        /// <summary>
        /// Wealth manager's signature can be their name
        /// </summary>
        /// <param name="iPSSurveyRequestDto"></param>
        /// <param name="clientSignature"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("save-survey")]
        public async Task<IActionResult> SaveSurvey([FromBody] IPSSurveyRequestDto iPSSurveyRequestDto, CancellationToken ctx)
        {
            _logger.LogDebug($"received request to save questionaiare {JsonConvert.SerializeObject(iPSSurveyRequestDto)}");
            //Save file on server.
            Survey survey = _automapper.Map<Survey>(iPSSurveyRequestDto);

            _surveyRepo.AddSurvey(survey);
            await _surveyRepo.SaveChanges();

            string output = null;
            object iform = null;
            if (!string.IsNullOrEmpty(iPSSurveyRequestDto.clientSignature))
            {
                output = UtilityService.ConvertBase64ToFile(iPSSurveyRequestDto.clientSignature, Directory.GetCurrentDirectory() + "/Signatures");
                iform = UtilityService.ConvertFileToIFormFile(output);
            }
            ///Send email 
            try
            {
                var emailReq = new InternalSendEmailRequest()
                {
                    UID = survey.Id,
                    Attachment = (iform != null) ? [(IFormFile)iform] : null,
                    Body = _emailService.LoadTemplateForBD().Replace("{{customerName}}", iPSSurveyRequestDto.name ?? string.Empty),
                    FromEmailAddress = "fcmbamsd@fcmb.com",
                    Subject = "IPS Questionaire update",
                    ToEmailAddress = "Gbeminiyi.Odetayo@fcmb.com;fcmbamsd@fcmb.com",
                    //ToEmailAddress = "nkemokwuone@gmail.com",
                };
                var loginReq = new InternalLoginRequest() { EmailAddress = _appSettings.emailAccount.Username, Password = _appSettings.emailAccount.Password };

                var loginResp = await _identityAdapter.FetchToken(loginReq, ctx);
                await _emailService.SendMailAttachment(emailReq, loginResp, ctx);

                //notify client
                 emailReq = new InternalSendEmailRequest()
                {
                    UID = survey.Id,
                    //Attachment = (iform != null) ? [(IFormFile)iform] : null,
                    Body = _emailService.LoadTemplateForCustomer().Replace("{{customerName}}", iPSSurveyRequestDto.name ?? string.Empty),
                    FromEmailAddress = "fcmbamsd@fcmb.com",
                    Subject = "IPS Questionaire update",
                    //ToEmailAddress = "Gbeminiyi.Odetayo@fcmb.com;fcmbamsd@fcmb.com",
                    ToEmailAddress = iPSSurveyRequestDto.email?? "fcmbamsd@fcmb.com",
                };
                await _emailService.SendMailAttachment(emailReq, loginResp, ctx);

            }
            catch (Exception ex)
            {
                _logger.LogError($"{ex}");
            }
            return Ok("saved");

        }
        [HttpPost]
        [Route("update-survey")]
        public async Task<IActionResult> UpdateSurvey([FromForm] IPSSurveyRequestDto iPSSurveyRequestDto, CancellationToken ctx)
        {
            //Save file on server.
            Survey survey = _automapper.Map<Survey>(iPSSurveyRequestDto);

            _surveyRepo.UpdateSurvey(survey);
            await _surveyRepo.SaveChanges();

            return Ok("saved");

        }

        [HttpGet]
        [Route("find-survey")]
        public async Task<IActionResult> FindSurvey([FromQuery] string Id)
        {
            var survey = _surveyRepo.FindById(Id);
            return Ok(survey);
        }

        [HttpGet]
        [Route("all-survey")]
        public async Task<IActionResult> FetchSurveys()
        {
            IEnumerable<Survey> survey = _surveyRepo.FetchAll();

            return Ok(survey);
        }
    }
}
