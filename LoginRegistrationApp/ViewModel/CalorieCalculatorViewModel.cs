using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WODWarriors.ViewModel
{
    public partial class CalorieCalculatorViewModel : ObservableObject
    {
        private double? _age;
        private double? _weight;
        private double? _height;
        private string _gender;
        private string _activityLevel;
        private double? _caloriesNeeded;

        public CalorieCalculatorViewModel()
        {
            Age = null;
            Weight = null;
            Height = null;
            CaloriesNeeded = null;
        }

        public double? Age
        {
            get => _age;
            set => SetProperty(ref _age, value);
        }

        public double? Weight
        {
            get => _weight;
            set => SetProperty(ref _weight, value);
        }

        public double? Height
        {
            get => _height;
            set => SetProperty(ref _height, value);
        }
        public string Gender
        {
            get => _gender;
            set => SetProperty(ref _gender, value);
        }
        public string[] GenderOptions { get; } = new[] { "Male", "Female" };

        public string ActivityLevel
        {
            get => _activityLevel;
            set => SetProperty(ref _activityLevel, value);
        }
        public string[] ActivityLevelOptions { get; } = new[] { "Sedentary", "Lightly Active", "Moderately Active", "Very Active", "Extra Active" };

        public double? CaloriesNeeded
        {
            get => _caloriesNeeded.HasValue? (double?)Math.Round((decimal)_caloriesNeeded.Value,1): null;
            private set => SetProperty(ref _caloriesNeeded, value);
        }

        [RelayCommand]
        async Task Calculate()
        {
            await Task.Delay(50);

            if (string.IsNullOrEmpty(Gender))
            {
                throw new InvalidOperationException("Please select a gender.");
            }

            if (string.IsNullOrEmpty(ActivityLevel))
            {
                throw new InvalidOperationException("Please select an activity level.");
            }

            if (Age <= 0 || Weight <= 0 || Height <= 0)
            {
                throw new InvalidOperationException("Please enter valid values for age, weight, and height.");
            }

            // Harris-Benedict equation males
            if (Gender == "Male")
            {
                if (ActivityLevel == "Sedentary")
                {
                    CaloriesNeeded = (double)(1.2 * (66.5 + (13.75 * Weight) + (5.003 * Height) - (6.75 * Age)));
                }
                else if (ActivityLevel == "Lightly Active")
                {
                    CaloriesNeeded = (double)(1.375 * (66.5 + (13.75 * Weight) + (5.003 * Height) - (6.75 * Age)));
                }
                else if (ActivityLevel == "Moderately Active")
                {
                    CaloriesNeeded = (double)(1.55 * (66.5 + (13.75 * Weight) + (5.003 * Height) - (6.75 * Age)));
                }
                else if (ActivityLevel == "Very Active")
                {
                    CaloriesNeeded = (double)(1.725 * (66.5 + (13.75 * Weight) + (5.003 * Height) - (6.75 * Age)));
                }
                else if (ActivityLevel == "Extra Active")
                {
                    CaloriesNeeded = (double)(1.9 * (66.5 + (13.75 * Weight) + (5.003 * Height) - (6.75 * Age)));
                }
            }
            // Harris-Benedict equation females

            else if (Gender == "Female")
            {
                if (ActivityLevel == "Sedentary")
                {
                    CaloriesNeeded = (double)(1.2 * (655.1 + (9.563 * Weight) + (1.850 * Height) - (4.676 * Age)));
                }
                else if (ActivityLevel == "Lightly Active")
                {
                    CaloriesNeeded = (double)(1.375 * (655.1 + (9.563 * Weight) + (1.850 * Height) - (4.676 * Age)));
                }
                else if (ActivityLevel == "Moderately Active")
                {
                    CaloriesNeeded = (double)(1.55 * (655.1 + (9.563 * Weight) + (1.850 * Height) - (4.676 * Age)));
                }
                else if (ActivityLevel == "Very Active")
                {
                    CaloriesNeeded = (double)(1.725 * (655.1 + (9.563 * Weight) + (1.850 * Height) - (4.676 * Age)));
                }
                else if (ActivityLevel == "Extra Active")
                {
                    CaloriesNeeded =  (double)(1.9 * (655.1 + (9.563 * Weight) + (1.850 * Height) - (4.676 * Age)));
                }
            }
        }
    }
}


