using AutoMapper;
using BikeComp.API.Entities;
using BikeComp.API.Helpers;
using Microsoft.EntityFrameworkCore;

namespace BikeComp.API.Profiles;

public class ComponentProfile : Profile
{
    public ComponentProfile()
    {
        CreateMap<Entities.Components, Models.ComponentDTO>()
            .ForMember(dest => dest.DaysSinceService, opt => opt.MapFrom(src => src.ServiceDate.GetTimeFromlastService()));
        CreateMap<Models.CompCreationDTO, Components>();
    }
    
}