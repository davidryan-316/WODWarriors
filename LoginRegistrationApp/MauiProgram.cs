using Microsoft.Extensions.Logging;
using WODWarriors.ViewModel;
using WODWarriors.Services;
using WODWarriors.View;
using WODWarriors.ViewModel;

namespace WODWarriors;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});
        builder.Services.AddTransient<DetailsPage>();
        builder.Services.AddTransient<DetailsViewModel>();

        builder.Services.AddTransient<MovementService>();
        builder.Services.AddTransient<ExerciseApiService>();

        builder.Services.AddTransient<MainPage>();
        builder.Services.AddTransient<MainViewModel>();                

        builder.Services.AddSingleton<WorkoutDetailsViewModel>();
        builder.Services.AddSingleton<WorkoutDetails>();

        builder.Services.AddTransient<LoginPage>();
        builder.Services.AddTransient<LoginViewModel>();

        builder.Services.AddTransient<RegistrationPage>();
        builder.Services.AddTransient<RegistrationViewModel>();

        builder.Services.AddTransient<ModifyUserPage>();
        builder.Services.AddTransient<ModifyUserViewModel>();

        builder.Services.AddTransient<CalorieCalculatorPage>();
        builder.Services.AddTransient<CalorieCalculatorViewModel>();

        builder.Services.AddTransient<About>();
        builder.Services.AddTransient<Privacy>();

        //builder.Services.AddTransient<AboutViewModel>();





        return builder.Build();
	}
}
