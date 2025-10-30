using App.BiblioX.Interfaces;
using App.BiblioX.Services;
using App.BiblioX.ViewModels;
using App.BiblioX.Views;
using Microsoft.Extensions.Logging;

namespace App.BiblioX
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
                    fonts.AddFont("MaterialIcons-Regular.ttf", "MaterialIcons-Regular");
                });

#if DEBUG
    		builder.Logging.AddDebug();
#endif
          
            // Injection des services
            builder.Services.AddSingleton<RestApiService>();
            builder.Services.AddSingleton<IGenreService, GenreService>();

            // Injection des ViewModels
            builder.Services.AddTransient<GenresViewModel>();

            // Injection des pages
            builder.Services.AddSingleton<MainPage>();

            return builder.Build();
        }
    }
}
