namespace Application.Features.WeatherForecasts.Queries
{
    public record GetWeatherForecastsQuery : IRequest<IEnumerable<WeatherForecast>>;
}
