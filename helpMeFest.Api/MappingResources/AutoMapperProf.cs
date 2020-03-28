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
            //.ForMember(modelUser => modelUser.Profile, dtoUser => dtoUser.MapFrom(
            //    data => new Models.Models.Profile()
            //    {
            //        Id = data.IdProfile
            //    }
            //))
            //.ForMember(modelUser => modelUser.Departament, dtoUser => dtoUser.MapFrom(
            //        data => new Departament()
            //        {
            //            Id = data.IdDepartament
            //        }
            //    ));

            CreateMap<EventDto, Event>();
                //.ForMember(modelEvent => modelEvent.EventOrganizer, dtoEvent => dtoEvent.MapFrom(
                //    data => new User()
                //    {
                //        Id = data.EventOrganizerId
                //    }
                //));

            #endregion Dto to Domain

            #region Domain to Dto

            CreateMap<User, UserDto>();

            #endregion Domain to Dto

        }

    }
}
