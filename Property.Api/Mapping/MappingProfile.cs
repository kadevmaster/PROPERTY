using AutoMapper;
using Property.Api.Resources;
using Property.Core.Models;

namespace Property.Api.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<City, CityResource>().ReverseMap();
        }
    }
}