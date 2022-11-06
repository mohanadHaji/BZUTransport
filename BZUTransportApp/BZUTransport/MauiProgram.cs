namespace BZUTransport
{
    using Microsoft.AspNetCore.Components.WebView.Maui;
    using BZUTransport.Data;
    using Microsoft.Extensions.Logging;
    using MetroLog.MicrosoftExtensions;

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
            builder.Services.AddSingleton<WeatherForecastService>();

            return builder.Build();
        }
    }

}