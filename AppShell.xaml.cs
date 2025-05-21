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

        // Method to display toast notifications
        public async Task DisplayToastAsync(string message)
        {
            // Using CommunityToolkit.Maui for toast notifications
            var toast = Toast.Make(message, ToastDuration.Short, 14);
            await toast.Show();
        }
    }
}