using AutoMapper;
using BikeComp.API.Entities;
using BikeComp.API.Helpers;
using BikeComp.API.Models;
using BikeComp.API.Services;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;

namespace BikeComp.API.Controllers;
[ApiController]
[Microsoft.AspNetCore.Mvc.Route("api/bikes")]
public class BikeController : ControllerBase
{
    private readonly IBikeCompRepository _bikeCompRepository;
    private readonly IMapper _mapper;
    public BikeController(IBikeCompRepository bikeCompRepository, IMapper mapper)
    {
        _bikeCompRepository = bikeCompRepository ??
                              throw new ArgumentNullException(nameof(bikeCompRepository));
        _mapper = mapper ??
                  throw new ArgumentNullException(nameof(mapper));
    }

    [HttpGet]
    public ActionResult<IEnumerable<Bike>> GetBikes()
    {
        var bikesDb = _bikeCompRepository.GetBikes();
        return Ok(_mapper.Map<IEnumerable<BikeDTO>>(bikesDb));
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBikeById(Guid id)
    {
        var bikeSpecific = _bikeCompRepository.GetBike(id);
        
        if (bikeSpecific == null)
        {
            return NotFound();    
        }
        return Ok(_mapper.Map<BikeDTO>(bikeSpecific));
    }
}