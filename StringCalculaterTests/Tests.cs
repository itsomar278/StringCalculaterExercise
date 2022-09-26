using FluentAssertions;
using StringCalculaterExercise;
namespace StringCalculaterTests
{
    public class Tests
    {
        private readonly StringCalculater _stringCalculater ;
        private int _result;
        private string _numbers;
        private int _expected; 
        public Tests()
        {
            _stringCalculater = new StringCalculater();
        }
        [Fact]
        public void emptyString_AddShouldReturnZero()
        {
            //Arrange
            _numbers = "";
            _expected = 0;
            //Act
            _result = _stringCalculater.add(_numbers);
            //Assert
            _result.Should().Be(_expected);
        }
        [Fact]
        public void oneNumberString_ShouldReturnTheSame()
        {
            //Arrange 
            _numbers = "3";
            _expected = int.Parse(_numbers);
            // Act 
            _result= _stringCalculater.add(_numbers);
            //Assert 
            _result.Should().Be(_expected);
        }
        [Fact]
        public void twoNumbersString_ShouldReturnSum()
        {
            //Arrange 
            _numbers = "1,3";
            string [] splittedNumbers = _numbers.Split(",");
            _expected = (int.Parse(splittedNumbers[0]) + int.Parse(splittedNumbers[1]));
            //Act 
            _result = _stringCalculater.add(_numbers);
            //Assert
            _result.Should().Be(_expected);
        }
    }
}