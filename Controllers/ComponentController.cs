using AutoMapper;
using BikeComp.API.Entities;
using BikeComp.API.Models;
using BikeComp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeComp.API.Controllers;

[ApiController]
[Route("api/bikes/{bikeId}/components")]
public class ComponentController : ControllerBase
{
    private readonly IBikeCompRepository _bikeCompRepository;
    private readonly IMapper _mapper;

    public ComponentController(IBikeCompRepository bikeCompRepository, IMapper mapper)
    {
        _bikeCompRepository = bikeCompRepository ??
                              throw new ArgumentNullException(nameof(bikeCompRepository));
        _mapper = mapper ??
                  throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public ActionResult<IEnumerable<ComponentDTO>> GetComponents(Guid bikeId)
    {
        if (!_bikeCompRepository.BikeExists(bikeId))
        {
            return NotFound();
        }

        var comps = _bikeCompRepository.GetComponents(bikeId);
        return Ok(_mapper.Map<IEnumerable<ComponentDTO>>(comps));



    }
}