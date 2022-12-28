using Microsoft.AspNetCore.Mvc;
using PartnerPortal.Application.WeatherForecasts.Queries;
using PartnerPortal.WebApi;

namespace PartnerPortal.WebApi.Controllers
{
    [ApiController]
    public class WeatherForecastController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<WeatherForecast>> Get()
        {
            return await Mediator.Send(new GetWeatherForecastsQuery());
        }
    }
}