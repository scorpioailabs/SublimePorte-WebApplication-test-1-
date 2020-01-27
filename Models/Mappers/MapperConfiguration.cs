using AutoMapper;
using SublimePorteApplication.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SublimePorteApplication.Models.Mappers
{
    public class MapperConfiguration : Profile
    {
        public MapperConfiguration()
            : this("SublimePorte.MapperConfiguration") { }

        public MapperConfiguration(string profileName) : base(profileName)
        {
            CreateMap<User, UserProfileModel>();
            CreateMap<UserProfileModel, User>();

            CreateMap<User, RegisterUserModel>();
            CreateMap<RegisterUserModel, User>();
        }
    }
}
