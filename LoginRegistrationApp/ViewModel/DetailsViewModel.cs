using System;
using System.Collections.Generic;
using System.Linq;
using System.Collections.Generic;
using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
using System.Reflection;
using WODWarriors.Model;
using Newtonsoft.Json;
using WODWarriors.Services;
using WODWarriors.ViewModel;
using WODWarriors.View;
using System.Linq;

namespace WODWarriors.ViewModel;

public partial class DetailsViewModel : BaseViewModel
{
    public ObservableCollection<Movement> Products { get; } = new();
    readonly MovementService movementService;

    public ObservableCollection<BodyPart> Parts { get; } = new();

    readonly ExerciseApiService _exerciseApiService;
 

    public DetailsViewModel(MovementService movementService, ExerciseApiService _exerciseApiService)
    {
        this._exerciseApiService = _exerciseApiService;
        this.movementService = movementService;

    }
  
    [RelayCommand]
    async Task GetProductsAsync()
    {

        try
        {
            var Item = await movementService.GetProducts("exercise_menu.json");

            if (Products.Count > 0)
                Products.Clear();

            foreach (var iter in Item)

                Products.Add(iter);

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Unable to get Exercises: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
        finally
        {

        }
    }
    [RelayCommand]
    async Task GoToCalorieAsync()
    {
        await Shell.Current.GoToAsync(nameof(CalorieCalculatorPage));

    }

    [RelayCommand]
    async Task GoToWorkoutAsync(Movement movement)
    {
        await Task.Delay(100);
        if (movement is null)
            return;

        try
        {
            var muscleName = movement.Name;

            var bodyPartList = await _exerciseApiService.GetWorkoutDetailsAsync(muscleName);

            if (Parts.Count > 0)
                Parts.Clear();

            foreach (var bodyPart in bodyPartList)
            {
                Parts.Add(bodyPart);
            }

            // Create an instance of the WorkoutDetailsViewModel
            var workoutDetailsViewModel = new WorkoutDetailsViewModel(movement);

            // Set the Parts property
            workoutDetailsViewModel.Parts = Parts.ToList();

            // Navigate to the WorkoutDetails page
            await Shell.Current.Navigation.PushAsync(new WorkoutDetails(workoutDetailsViewModel));

        }
        catch (Exception ex)
        {
            Debug.WriteLine($"Cant load them: {ex.Message}");
            await Shell.Current.DisplayAlert("Error!", ex.Message, "OK");
        }
    }
   

}




