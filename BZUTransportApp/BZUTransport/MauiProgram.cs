namespace BZUTransport
{
    using BZUTransport.ConfigurationExtensions;
    using Microsoft.Extensions.Logging;
    using MetroLog.MicrosoftExtensions;
    using Microsoft.Extensions.DependencyInjection;
    using BZUTransport.RequestValidations.LoginRequest;

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