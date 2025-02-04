using BikeComp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeComp.API.Controllers;
[ApiController]
[Route("api/bikes")]
public class BikeController : ControllerBase
{
    private readonly IBikeCompRepository _bikeCompRepository;

    public BikeController(IBikeCompRepository bikeCompRepository)
    {
        _bikeCompRepository = bikeCompRepository ??
                              throw new ArgumentNullException(nameof(bikeCompRepository));
    }

    [HttpGet]
    public IActionResult GetBikes()
    {
        var bikes = _bikeCompRepository.GetBikes();
        return new JsonResult(bikes);
    }

    [HttpGet("{id:guid}")]
    public IActionResult GetBikeById(Guid id)
    {
        var bikeSpecific = _bikeCompRepository.GetBike(id);
        return new JsonResult(bikeSpecific);
    }
}