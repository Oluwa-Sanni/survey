using AutoMapper;
using IPS_survey.models;

namespace IPS_survey.mapperConfig
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Survey, IPSSurveyRequestDto>();
            CreateMap<IEnumerable<Survey>, IEnumerable<IPSSurveyRequestDto>>();
            CreateMap<IPSSurveyRequestDto, Survey>();
        }
    }
}
