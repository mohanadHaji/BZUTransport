namespace BZUTransport.ConfigurationExtensions
{
    using Microsoft.Extensions.Configuration;
    using System.Reflection;

    public static class AppSettingsConfigurationExtensions
    {
        public static void AddAppSettings(this MauiAppBuilder builder)
        {
            var a = Assembly.GetExecutingAssembly();
            using var stream = a.GetManifestResourceStream("BZUTransport.Properties.appsettings.json");

            var config = new ConfigurationBuilder()
                        .AddJsonStream(stream)
                        .Build();


            builder.Configuration.AddConfiguration(config);
        }
    }
}
