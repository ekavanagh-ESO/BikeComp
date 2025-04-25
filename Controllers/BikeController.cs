using AutoMapper;
using BikeComp.API.Entities;
using BikeComp.API.Helpers;
using BikeComp.API.Models;
using BikeComp.API.ResourceParameters;
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
    [HttpHead]
    public ActionResult<IEnumerable<Bike>> GetBikes([FromQuery] BikeParameters bikeParameters)
    {
        var bikesDb = _bikeCompRepository.GetBikes(bikeParameters);
        return Ok(_mapper.Map<IEnumerable<BikeDTO>>(bikesDb));
    }

    [HttpGet]
    [Microsoft.AspNetCore.Mvc.Route("all")]
    public ActionResult<IEnumerable<Bike>> GetAllBikes()
    {
        var allBikes = _bikeCompRepository.GetBikes();
        return Ok(_mapper.Map<IEnumerable<BikeDTO>>(allBikes));
    }

    [HttpGet("{id:guid}", Name = "GetBike")]
    public IActionResult GetBikeById(Guid id)
    {
        var bikeSpecific = _bikeCompRepository.GetBike(id);
        
        if (bikeSpecific == null)
        {
            return NotFound();    
        }
        return Ok(_mapper.Map<BikeDTO>(bikeSpecific));
    }

    [HttpPost]
    public ActionResult<BikeDTO> CreateBike(BikeCreationDTO bike)
    {
        var bikeEntity = _mapper.Map<Bike>(bike);
        _bikeCompRepository.AddBike(bikeEntity);
        _bikeCompRepository.Save();

        var bikeRet = _mapper.Map<BikeDTO>(bikeEntity);
        return CreatedAtRoute("GetBike",
            new { id = bikeRet.Id },
            bikeRet);
    }
    
    
    
}