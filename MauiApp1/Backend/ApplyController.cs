using EmbedIO;
using EmbedIO.Routing;
using EmbedIO.WebApi;
using MauiApp1.Data.Models;
using MauiApp1.Services;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace MauiApp1.Backend
{
    public class ApplyController : WebApiController
    {
        private readonly LocalWebServer _server;
        private readonly ApplyService _databaseService;

        public ApplyController(LocalWebServer server)
        {
            _server = server;
            _databaseService = ServiceHelper.GetService<ApplyService>();
        }

        [Route(HttpVerbs.Post, "/submit")]
        public async Task HandlePost()
        {
            //var json = await HttpContext.GetRequestBodyAsStringAsync();
            //Console.WriteLine("Received JSON: " + json);

            //// Optional: parse JSON and act
            //var doc = JsonDocument.Parse(json);
            //var jobTitle = doc.RootElement.GetProperty("jobTitle").GetString();

            //_server.RaiseApplicationRefresh();

            //await HttpContext.SendStringAsync("Received!", "text/plain", System.Text.Encoding.UTF8);

            try
            {
                using var reader = new StreamReader(HttpContext.OpenRequestStream());
                var body = await reader.ReadToEndAsync();

                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true,
                    Converters =
                    {
                        new JsonStringEnumConverter(JsonNamingPolicy.CamelCase)
                    }
                };

                var jobApp = JsonSerializer.Deserialize<JobApplication>(body, options);

                if (jobApp is null)
                {
                    await HttpContext.SendStringAsync("Invalid payload", "text/plain", System.Text.Encoding.UTF8);
                    return;
                }
                await _databaseService.SaveOrUpdateJobAsync(jobApp);
                _server.RaiseApplicationRefresh();
            }
            catch (JsonException jsonEx)
            {
                Console.WriteLine("JSON deserialization error: " + jsonEx.Message);
                await HttpContext.SendStringAsync("Malformed JSON", "text/plain", System.Text.Encoding.UTF8);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Server error: " + ex.Message);
                await HttpContext.SendStringAsync("Server error", "text/plain", System.Text.Encoding.UTF8);
            }
        }

        [Route(HttpVerbs.Get, "/ping")]
        public string Ping() => "pong";
    }

}