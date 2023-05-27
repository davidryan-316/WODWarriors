using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WODWarriors.Model;
using WODWarriors.ViewModel;

namespace Testing
{
    public class WorkoutViewModelTest
    {
        [Fact]
        public void Constructor_SelectedImagePropertyIsSet()
        {
            // Arrange
            string selectedImage = "chin_ups.jpg";

            // Act
            var viewModel = new WorkoutDetailsViewModel(selectedImage);

            // Assert
            Assert.Equal(selectedImage, viewModel.SelectedImage);
        }

        [Fact]
        public void Constructor_MovementPropertyIsSet()
        {
            // Arrange
            var expectedMovement = new Movement();

            // Act
            var viewModel = new WorkoutDetailsViewModel(expectedMovement);

            // Assert
            Assert.Equal(expectedMovement, viewModel.Movement);
        }
    }
}
