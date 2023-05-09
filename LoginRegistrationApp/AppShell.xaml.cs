using WODWarriors.View;
using WODWarriors.ViewModel;

namespace WODWarriors;

public partial class AppShell : Shell
{
	public AppShell()
	{
		InitializeComponent();

        
        Routing.RegisterRoute(nameof(LoginPage), typeof(LoginPage));
        Routing.RegisterRoute(nameof(RegistrationPage), typeof(RegistrationPage));
        Routing.RegisterRoute(nameof(ModifyUserPage), typeof(ModifyUserPage));
        Routing.RegisterRoute(nameof(DetailsPage), typeof(DetailsPage));
        Routing.RegisterRoute(nameof(WorkoutDetails), typeof(WorkoutDetails));
        Routing.RegisterRoute(nameof(CalorieCalculatorPage), typeof(CalorieCalculatorPage));
        Routing.RegisterRoute(nameof(About), typeof(About));
        Routing.RegisterRoute(nameof(Privacy), typeof(Privacy));




    }
}
