using WODWarriors.ViewModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;
using System.Windows.Input;

namespace WODWarriors.View;
public partial class DetailsPage : ContentPage
{
    public DetailsPage(DetailsViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}