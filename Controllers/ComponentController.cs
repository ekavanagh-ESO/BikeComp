using AutoMapper;
using BikeComp.API.Entities;
using BikeComp.API.Models;
using BikeComp.API.Services;
using Microsoft.AspNetCore.Http.HttpResults;
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
    [HttpHead]
    public ActionResult<IEnumerable<ComponentDTO>> GetComponents(Guid bikeId)
    {
        if (!_bikeCompRepository.BikeExists(bikeId))
        {
            return NotFound();
        }

        var comps = _bikeCompRepository.GetComponents(bikeId);
        return Ok(_mapper.Map<IEnumerable<ComponentDTO>>(comps));
    }
    

    [HttpGet("{compId}", Name = "GetCompForBike")]
    public ActionResult<ComponentDTO> GetComponent(Guid BikeId, Guid compId)
    {
        if (!_bikeCompRepository.BikeExists(BikeId))
        {
            return NotFound();
        }

        var component = _bikeCompRepository.GetComponent(BikeId, compId);
        if (component == null)
        {
            return NotFound();
        }
        return Ok(_mapper.Map<ComponentDTO>(component));
    }

    [HttpPost]
    public ActionResult<ComponentDTO> CreateCompForBike(Guid bikeId, CompCreationDTO component)
    {
        if (!_bikeCompRepository.BikeExists(bikeId))
        {
            return NotFound();
        }

        var compEntity = _mapper.Map<Components>(component);
        compEntity.BikeId = bikeId;
        _bikeCompRepository.AddComponent(bikeId, compEntity);
        _bikeCompRepository.Save();

        var compToReturn = _mapper.Map<ComponentDTO>(compEntity);
        return CreatedAtRoute("GetCompForBike",
            new { BikeId = bikeId, compId = compToReturn.Id },
            compToReturn);


    }
}