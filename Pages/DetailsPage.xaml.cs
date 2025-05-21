using Microsoft.Maui.ApplicationModel; 

namespace SchoolClassCompass.Pages
{
    public partial class DetailsPage : ContentPage
    {
        public DetailsPage()
        {
            InitializeComponent();
        }

        // Example method that updates UI safely
        void UpdateLabel()
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                MyLabel.Text = "Updated safely on UI thread!";
            });
        }
    }
}