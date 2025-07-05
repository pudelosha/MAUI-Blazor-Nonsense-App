using MAUI_Blazor_Nonsense_App.Services;
using Microsoft.Extensions.Logging;
using Radzen;

namespace MAUI_Blazor_Nonsense_App
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
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            // Register Radzen components
            builder.Services.AddRadzenComponents();

            // Register platform-specific StepCounterService
            builder.Services.AddSingleton<IStepCounterService>(provider =>
            {
#if ANDROID
                return new StepCounterService();
#elif IOS
                return new StepCounterService();
#else
                return new DummyStepCounterService();
#endif
            });

            return builder.Build();
        }
    }
}
