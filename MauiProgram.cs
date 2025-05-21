using Microsoft.Maui;
using Microsoft.Maui.Hosting;
using CommunityToolkit.Maui;

namespace SchoolClassCompass;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<App>() // Register the main application class
            .UseMauiCommunityToolkit() // Use the Community Toolkit for MAUI
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
            });

        return builder.Build();
    }
}