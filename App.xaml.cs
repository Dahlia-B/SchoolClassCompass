namespace SchoolClassCompass;
public partial class App : Application
{
    public App()
    {
        InitializeComponent();

        // Don't set MainPage directly as it's deprecated
        // MainPage = new MainPage();
    }

    protected override Window CreateWindow(IActivationState? activationState)
    {
        // Create and configure window with proper dispatcher handling
        var window = new Window(new MainPage());

        // Ensure we have proper dispatcher context for the window
        Microsoft.Maui.Controls.Application.Current.Dispatcher?.Dispatch(() => {
            // Configure window properties if needed
            // window.Title = "School Class Compass";
        });

        return window;
    }
}