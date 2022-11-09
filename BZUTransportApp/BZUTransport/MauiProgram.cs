namespace BZUTransport
{
    using BZUTransport.Data;
    using BZUTransport.ConfigurationExtensions;
    using Microsoft.Extensions.Logging;
    using MetroLog.MicrosoftExtensions;
    using Common.MongoDatabase.UserInfo;
    using Microsoft.Extensions.Options;
    using Microsoft.Extensions.DependencyInjection;
    using MongoDB.Driver;
    using Microsoft.Extensions.Configuration;

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
                });

            builder.Services.AddMauiBlazorWebView();
            builder.Logging.ClearProviders();
#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddConsoleLogger(_ => { });
#endif
            builder.Logging.AddTraceLogger(_ => { });
            builder.Logging.AddInMemoryLogger(_ => { });

            builder.AddAppSettings();
            builder.AddMongoDB();
            return builder.Build();
        }
    }

}