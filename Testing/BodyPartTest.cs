using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WODWarriors.Model;

namespace UnitTests
{
    public class BodyPartTest
    {
        [Fact]
        public void BodyPart_Properties_Should_Be_Set_Correctly()
        {
            // Arrange
            string name = "Legs";
            string type = "Lower Body";
            string muscle = "Quadriceps";
            string equipment = "Barbell";
            string difficulty = "Intermediate";
            string instructions = "Perform squats with proper form.";

            // Act
            var bodyPart = new BodyPart
            {
                name = name,
                type = type,
                muscle = muscle,
                equipment = equipment,
                difficulty = difficulty,
                instructions = instructions
            };

            // Assert
            Assert.Equal(name, bodyPart.name);
            Assert.Equal(type, bodyPart.type);
            Assert.Equal(muscle, bodyPart.muscle);
            Assert.Equal(equipment, bodyPart.equipment);
            Assert.Equal(difficulty, bodyPart.difficulty);
            Assert.Equal(instructions, bodyPart.instructions);
        }
    }
}

