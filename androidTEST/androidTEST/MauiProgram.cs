using Microsoft.Extensions.Logging;
using androidTEST.ViewModels;
using androidTEST.Views;

namespace androidTEST;

public static class MauiProgram
{

    public static string NextPage = nameof(LoginPage);
    public static string UserID = "INITIALID";
    public static bool DeepLink = false;
    public static ImageSource PhotoData = "";

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

        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<LoginViewModel>();
        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainViewModel>();
        builder.Services.AddTransient<MenuPage>();
        builder.Services.AddTransient<MenuViewModel>();
        builder.Services.AddTransient<PhotoPage>();
        builder.Services.AddTransient<PhotoViewModel>();


#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
