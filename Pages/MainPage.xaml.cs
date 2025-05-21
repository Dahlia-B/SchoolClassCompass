using Microsoft.Maui.ApplicationModel;

namespace SchoolClassCompass.Pages
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        // Event handler for the "Get Started" button click
        private void OnGetStartedClicked(object sender, EventArgs e)
        {
            // Update the label text safely on the UI thread
            MainThread.BeginInvokeOnMainThread(() =>
            {
                MyLabel.Text = "Let's get started!";
            });
        }
    }
}