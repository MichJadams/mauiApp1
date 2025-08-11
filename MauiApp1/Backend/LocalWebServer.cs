using EmbedIO;
using EmbedIO.WebApi;

namespace MauiApp1.Backend
{
    public class LocalWebServer
    {
        private WebServer? _server;
        public bool IsRunning => _server != null;

        public event EventHandler? ApplicationRefreshRequested;

        public void Start()
        {
            if (IsRunning) return;

            _server = new WebServer(o => o
                    .WithUrlPrefix("http://localhost:9696")
                    .WithMode(HttpListenerMode.EmbedIO))
                .WithWebApi("/api", m => m.WithController(()=> new ApplyController(this)));

            _server.RunAsync();
        }

        public void StopAsync()
        {
            if (_server != null)
            {
                _server.Dispose();
                _server = null;
            }
        }
        public void RaiseApplicationRefresh()
        {
            ApplicationRefreshRequested?.Invoke(this, EventArgs.Empty);
        }
    }
}
