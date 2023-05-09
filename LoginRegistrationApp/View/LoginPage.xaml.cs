using WODWarriors.ViewModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace WODWarriors.View;
public partial class LoginPage : ContentPage
{
    public LoginPage(LoginViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}

