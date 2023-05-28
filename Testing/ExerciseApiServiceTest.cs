using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WODWarriors.Services;

namespace Testing
{
    public class ExerciseApiServiceTest
    {
        private readonly ExerciseApiService _apiService;

        public ExerciseApiServiceTest()
        {
            _apiService = new ExerciseApiService();
        }

        [Fact]
        public async Task GetWorkoutDetailsAsync_ValidMuscle_ReturnsBodyPartList()
        {
            // Arrange
            string muscle = "legs";
           

            // Act
            var result = await _apiService.GetWorkoutDetailsAsync(muscle);

            // Assert
            Assert.NotNull(result);              

          
        }
    }
}
