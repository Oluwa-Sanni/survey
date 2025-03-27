using IPS_survey.models;

namespace IPS_survey.Repos
{
    public interface ISurveyRepo
    {
        public void AddSurvey(Survey surveyRequestDto);
        public void UpdateSurvey(Survey surveyRequestDto);
        IEnumerable<Survey> FetchAll();
        Survey FindById(string guid);
        public Task<int> SaveChanges();
    }
}
