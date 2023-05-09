using WODWarriors.ViewModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace WODWarriors.View;
public partial class ModifyUserPage : ContentPage
{
    public ModifyUserPage(ModifyUserViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}
