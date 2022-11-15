using AutoMapper;
using Example.CodingTask.Core.Entity;
using Example.CodingTask.Core.Persistent;
using Example.CodingTask.Core.Transient;

namespace Example.CodingTask.Service.Mapping
{
    public class UserMatchMappingProfile : Profile
    {
        public UserMatchMappingProfile()
        {
            CreateMap<CreateUserMatchDto, UserMatch>();

            CreateMap<UserMatch, UserMatchDto>();
        }
    }
}
