using AutoMapper;
using BikeComp.API.Helpers;

namespace BikeComp.API.Profiles;

public class BikeProfile : Profile
{
    public BikeProfile()
    {
        CreateMap<Entities.Bike, Models.BikeDTO>()
            .ForMember(
                dest => dest.BikeName,
                opt => opt.MapFrom(src => src.BikeName)
                ).ForMember(
                dest => dest.DaysSinceService,
                opt => opt.MapFrom(src => src.GetTimeFromlastService()));
    }
}