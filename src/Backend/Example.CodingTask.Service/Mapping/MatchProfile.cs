using AutoMapper;
using Example.CodingTask.Core.Entity;
using Example.CodingTask.Core.Persistent;

namespace Example.CodingTask.Service.Mapping
{
    public class MatchProfile : Profile
    {
        public MatchProfile()
        {
            CreateMap<Match, MatchDto>();
        }
    }
}
