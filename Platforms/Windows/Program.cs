using Microsoft.UI.Xaml;

namespace SchoolClassCompass;

public static class Program
{
    [STAThread]
    static void Main(string[] args)
    {
        Microsoft.UI.Xaml.Application.Start(p => new App());
    }
}
