using FluentAssertions;
using StringCalculaterExercise;
namespace StringCalculaterTests
{
    public class Tests
    {
        private readonly StringCalculater _stringCalculater;
        private int _result;
        public Tests()
        {
            _stringCalculater = new StringCalculater();
        }
        [Theory]
        [InlineData("", 0)] // empty string 
        [InlineData("3", 3)] // one number 
        [InlineData("1,5", 6)] // 2 numbers 
        [InlineData("1,2,3,4,5,6", 21)] // unknown amount of numbers 
        public void addShouldReturnSum(string numbers, int expected)
        {
            //Act
            _result = _stringCalculater.add(numbers);
            //Assert
            _result.Should().Be(expected);
        }
    }
}