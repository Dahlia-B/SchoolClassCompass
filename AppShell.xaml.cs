using System.Threading.Tasks;
using Microsoft.Maui.Controls;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace SchoolClassCompass
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
        }

        // Static method to display toast notifications from anywhere in the app
        public static async Task DisplayToastAsync(string message)
        {
            var toast = Toast.Make(message, ToastDuration.Short, 14);
            await toast.Show();
        }
    }
}