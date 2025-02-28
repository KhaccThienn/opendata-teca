namespace Application.Features.WeatherForecasts.Handlers
{
    public class GetWeatherForecastsQueryHandler : IRequestHandler<GetWeatherForecastsQuery, IEnumerable<WeatherForecast>>
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        public async Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastsQuery request, CancellationToken cancellationToken)
        {
            var rand = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date         = DateTime.UtcNow.AddDays(index),
                TemperatureC = rand.Next(-20, 55),
                Summary      = Summaries[rand.Next(Summaries.Length)]
            });
        }
    }
}
