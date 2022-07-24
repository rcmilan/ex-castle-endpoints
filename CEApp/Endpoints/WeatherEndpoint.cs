using CEApp.Models;
using CEApp.Requests;
using CEApp.Services;
using FastEndpoints;

namespace CEApp.Endpoints
{
    public class WeatherEndpoint : Endpoint<WeatherEndpointRequest, List<WeatherForecast>>
    {
        private readonly IWeatherForecastService weatherForecastService;

        public WeatherEndpoint(IWeatherForecastService weatherForecastService)
        {
            this.weatherForecastService = weatherForecastService;
        }

        public override void Configure()
        {
            Verbs(Http.GET);
            Routes("api/weather");
            AllowAnonymous();
        }

        public override async Task HandleAsync(WeatherEndpointRequest req, CancellationToken ct)
        {
            var result = await weatherForecastService.GetForecastAsync(req.EventDate);

            await SendAsync(result.ToList(), cancellation: ct);
        }
    }
}
