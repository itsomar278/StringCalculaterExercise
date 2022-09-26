using FluentAssertions;
using StringCalculaterExercise;
namespace StringCalculaterTests
{
    public class Tests
    {
        private readonly StringCalculater _stringCalculater ;
        public Tests()
        {
            _stringCalculater = new StringCalculater();
        }
        [Fact]
        public void emptyString_AddShouldReturnZero()
        {
            //Arrange
            string numbers = "";
            int result;
            //Act
            result = _stringCalculater.add(numbers);
            //Assert
            result.Should().Be(0);
        }
        [Fact]
        public void oneNumberString_ShouldReturnTheSame()
        {
            //Arrange 
            string numbers = "3";
            int result; 
            // Act 
            result= _stringCalculater.add(numbers);
            //Assert 
            result.Should().Be(int.Parse(numbers));
        }
        [Fact]
        public void twoNumbersString_ShouldReturnSum()
        {
            //Arrange 
            string numbers = "1,3";
            string [] splittedNumbers = numbers.Split(",");
            int result; 
            int expected = (int.Parse(splittedNumbers[0]) + int.Parse(splittedNumbers[1]));
            //Act 
            result = _stringCalculater.add(numbers);
            //Assert
            result.Should().Be(expected);
            
        }
    }
}