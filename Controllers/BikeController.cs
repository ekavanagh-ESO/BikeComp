using BikeComp.API.Services;
using Microsoft.AspNetCore.Mvc;

namespace BikeComp.API.Controllers;
[ApiController]
[Route("api/[controller]")]
public class BikeController : ControllerBase
{
    private readonly IBikeCompRepository _bikeCompRepository;

    public BikeController(IBikeCompRepository bikeCompRepository)
    {
        _bikeCompRepository = bikeCompRepository;
    }

    [HttpGet]
    public IActionResult GetBikes()
    {
        var bikes = _bikeCompRepository.GetBikes();
        return Ok(bikes);
    }

}