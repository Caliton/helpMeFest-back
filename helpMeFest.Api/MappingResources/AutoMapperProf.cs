using AutoMapper;
using helpMeFest.Api.Dtos;
using helpMeFest.Models.Models;

namespace helpMeFest.Api.MappingResources
{
    public class AutoMapperProf : AutoMapper.Profile
    {
        public AutoMapperProf()
        {

            #region Dto to Domain

            CreateMap<SaveUserDto, User>();
            CreateMap<SaveUserEvent, UserEvent>();

            CreateMap<EventDto, Event>();

            #endregion Dto to Domain

            #region Domain to Dto

            CreateMap<User, UserDto>();

            #endregion Domain to Dto
        }

    }
}
