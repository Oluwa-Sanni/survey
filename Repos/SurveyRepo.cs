using IPS_survey.Context;
using IPS_survey.models;

namespace IPS_survey.Repos
{
    public class SurveyRepo : ISurveyRepo
    {
        private readonly ApplicationDbContext _context;

        public SurveyRepo(ApplicationDbContext context)
        {
            this._context = context;
        }
        public void AddSurvey(Survey survey)
        {
            survey.DateCreated = DateTime.Now;
            _context.surveyRequest.Add(survey);
        }

        public IEnumerable<Survey> FetchAll()
        {
            return _context.surveyRequest.ToList();
        }

        public Survey FindById(string guid)
        {
            return _context.surveyRequest.Where(survey => survey.Id == guid).FirstOrDefault();
        }

        public async Task<int> SaveChanges()
        {
            return await _context.SaveChangesAsync();
        }

        public void UpdateSurvey(Survey surveyRequestDto)
        {
            surveyRequestDto.DateUpdated = DateTime.Now;
            _context.surveyRequest.Update(surveyRequestDto);
        }
    }
}
