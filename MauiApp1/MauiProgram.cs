using Microsoft.Extensions.Logging;
using Syncfusion.Maui.Core.Hosting;
using MauiApp1.Services;
using MauiApp1.Data;
using MauiApp1.TestData;
using MauiApp1.Backend;

namespace MauiApp1
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddDbContext<ApplyDbContext>();
            builder.Services.AddScoped<ApplyService>();
            builder.Services.AddSingleton<LocalWebServer>();
            builder.ConfigureSyncfusionCore();
#if DEBUG
            builder.Logging.AddDebug();
#endif
            var app = builder.Build();

#if DEBUG
            using var scope = app.Services.CreateScope();
            var db = scope.ServiceProvider.GetRequiredService<ApplyDbContext>();
            db.Database.EnsureDeleted();
            db.Database.EnsureCreated();
            TestDataSeeder.SeedTestData(db);
        
#endif
            return app;
        }
    }
}
