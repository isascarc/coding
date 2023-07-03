using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;
public class WeatherForecastController : BaseApiController
{
    [HttpGet]
    public bool Get()
    {
        return true;
    }
}
