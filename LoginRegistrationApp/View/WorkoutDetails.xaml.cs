using WODWarriors.ViewModel;
using System.Windows.Input;

namespace WODWarriors.View;

public partial class WorkoutDetails : ContentPage
{
	public WorkoutDetails(WorkoutDetailsViewModel viewModel)
	{

		InitializeComponent();
		BindingContext = viewModel;
	}

}
