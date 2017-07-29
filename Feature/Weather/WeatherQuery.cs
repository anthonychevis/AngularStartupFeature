using MediatR;
using System;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.Extensions.Options;

namespace Kit.Feature.Weather
{

    public class Weather
    {
        public class Query : IRequest<Result>
        {
            public string City { get; set; }
        }

        public class QueryHandler : IAsyncRequestHandler<Query, Result>
        {
            private readonly IOptions<ApplicationOptions> _options;

            public QueryHandler(IOptions<ApplicationOptions> options)
            {
                _options = options;
            }

            public async Task<Result> Handle(Query message)
            {
                using (var client = new HttpClient()) {
                    client.BaseAddress = new Uri("http://api.openweathermap.org");
                    var response = await client.GetAsync($"/data/2.5/weather?q={message.City}&appid={_options.Value.openWeatherApiKey}&units=metric");
                    response.EnsureSuccessStatusCode();

                    string result = await response.Content.ReadAsStringAsync();
                    var rawWeather = JsonConvert.DeserializeObject<OpenWeatherResponse>(result);
                    return new Result {
                        Temp = rawWeather.Main.Temp,
                        Summary = string.Join(",", rawWeather.Weather.Select(x => x.Main)),
                        City = rawWeather.Name
                    };
                }
            }
        }

        public class Result : IRequest
        {
            public string City { get; set; }
            public string Temp { get; set; }
            public string Summary { get; set; }

        }
    }
}
