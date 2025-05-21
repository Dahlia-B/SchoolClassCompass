using Microsoft.Maui.ApplicationModel;

namespace SchoolClassCompass.Pages
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        // Example method that updates the label safely on the UI thread
        void UpdateLabel()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                MyLabel.Text = "Updated safely on UI thread!";
            });
        }
    }
}