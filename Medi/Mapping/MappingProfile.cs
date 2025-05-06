using AutoMapper;
using Medi.Core.Models;
using Medi.DataAccess.Entities;

namespace Medi.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<UserEntity, User>();
            this.CreateMap<User, UserEntity>();
        }
    }
}
