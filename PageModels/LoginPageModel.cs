using CommunityToolkit.Mvvm.ComponentModel;

namespace SchoolClassCompass.PageModels;

public partial class LoginPageModel : ObservableObject
{
    [ObservableProperty]
    private string username = null!;

    [ObservableProperty]
    private string password = null!;

    [ObservableProperty]
    private string loginError = null!;

    // Use 'Username', 'Password', 'LoginError' in your code, NOT the fields
}