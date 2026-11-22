using GameTemplateMAUI.Sessions;
using Microsoft.Extensions.Logging;
using GameTemplateMAUI.ViewModels;
using GameTemplateMAUI.Pages;
using TwoKnightsGame;

namespace GameTemplateMAUI
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

            builder.Services.AddTransient<GameEngine>();
            builder.Services.AddTransient<ISession, LocalSession>();

            builder.Services.AddTransient<MainPage>();
            builder.Services.AddTransient<MainPageViewModel>();

            builder.Services.AddTransient<GamePage>();
            builder.Services.AddTransient<GameViewModel>();
#if DEBUG
            builder.Logging.AddDebug();
#endif

            return builder.Build();
        }
    }
}
