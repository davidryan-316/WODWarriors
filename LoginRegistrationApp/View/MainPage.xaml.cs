using WODWarriors.ViewModel;
using WODWarriors.View;
using Microsoft.Maui.Controls;
using System.Windows.Input;

namespace WODWarriors;

public partial class MainPage : ContentPage
{
    public MainPage(MainViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}


