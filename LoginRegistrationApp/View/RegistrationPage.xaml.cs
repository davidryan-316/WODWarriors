using WODWarriors.ViewModel;
using Microsoft.Maui.Controls;

namespace WODWarriors.View;
public partial class RegistrationPage : ContentPage
{ 
    public RegistrationPage(RegistrationViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
