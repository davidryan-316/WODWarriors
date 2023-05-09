using WODWarriors.ViewModel;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Controls.Xaml;

namespace WODWarriors.View;

public partial class CalorieCalculatorPage : ContentPage
{
	public CalorieCalculatorPage(CalorieCalculatorViewModel viewModel)
	{
		InitializeComponent();
		BindingContext = viewModel;	

	}
}