using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("FBDb")]
[Serializable]
namespace ASPwebAPI
{
    public class WeatherForecast
    {
        [return: ValidatedContract]
        public DateTime Date { get; set; }

        public int TemperatureC { get; set; }

        public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);

        public string? Summary { get; set; }
    }
}