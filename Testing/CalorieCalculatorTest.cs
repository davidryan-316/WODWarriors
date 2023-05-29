using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WODWarriors.ViewModel;

namespace Testing
{
    public class CalorieCalculatorTest
    {
        [Fact]
        public void CalorieCalculator_ViewModelTest()
        {
            // Arrange
            var viewModel = new CalorieCalculatorViewModel();

            // Assert
            Assert.Null(viewModel.Age);
            Assert.Null(viewModel.Weight);
            Assert.Null(viewModel.Height);
            Assert.Null(viewModel.CaloriesNeeded);
        }

        [Fact]
        public async Task Calculate_Example_Test()
        {
            // Arrange
            var viewModel = new CalorieCalculatorViewModel();
            viewModel.Age = 31;
            viewModel.Weight = 75;
            viewModel.Height = 175;
            viewModel.Gender = "Male";
            viewModel.ActivityLevel = "Moderately Active";

            // Act
            await viewModel.Calculate();

            // Assert
            double expectedCalories = 1.55 * (66.5 + (13.75 * viewModel.Weight.Value) + (5.003 * viewModel.Height.Value) - (6.75 * viewModel.Age.Value));
            Assert.Equal(expectedCalories, viewModel.CaloriesNeeded.Value, 1);

        }
    }
}
