using AutoMapper;

namespace BikeComp.API.Profiles;

public class ComponentProfile : Profile
{
    public ComponentProfile()
    {
        CreateMap<Entities.Components, Models.ComponentDTO>();
    }
    
}