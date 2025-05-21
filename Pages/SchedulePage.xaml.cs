using SchoolClassCompass.PageModels;
namespace SchoolClassCompass.Pages;

public partial class SchedulePage : ContentPage
{
    public SchedulePage()
    {
        InitializeComponent();
        BindingContext = new SchedulePageModel();    
    }
}
