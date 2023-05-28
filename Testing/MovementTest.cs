using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WODWarriors.Model;

namespace UnitTests
{
    public class MovementTest
    {
        [Fact]
        public void Movement_Properties_Should_Be_Set_Correctly()
        {
            // Arrange
            string name = "Squat";
            string image = "barbell_full_squat.jpg";
            string title = "Squat Exercise";
            string description = "Target the quads and core stability";

            // Act
            var movement = new Movement
            {
                Name = name,
                Image = image,
                Title = title,
                Description = description
            };

            // Assert
            Assert.Equal(name, movement.Name);
            Assert.Equal(image, movement.Image);
            Assert.Equal(title, movement.Title);
            Assert.Equal(description, movement.Description);
        }
        [Fact]
        public void Movement_For_Null_Values()
        {
            // Arrange
            string? name = null;
            string? image = null;
            string? title = null;
            string? description = null;

            // Act
            var movement = new Movement
            {
                Name = name,
                Image = image,
                Title = title,
                Description = description
            };

            // Assert
            Assert.Null(movement.Name);
            Assert.Null(movement.Image);
            Assert.Null(movement.Title);
            Assert.Null(movement.Description);
        }

        [Fact]
        public void Movement_For_Empty_Values()
        {
            // Arrange
            string name = string.Empty;
            string image = string.Empty;
            string title = string.Empty;
            string description = string.Empty;

            // Act
            var movement = new Movement
            {
                Name = name,
                Image = image,
                Title = title,
                Description = description
            };

            // Assert
            Assert.Equal(name, movement.Name);
            Assert.Equal(image, movement.Image);
            Assert.Equal(title, movement.Title);
            Assert.Equal(description, movement.Description);
        }
    }
}
