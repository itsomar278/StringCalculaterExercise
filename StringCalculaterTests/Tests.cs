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
        [InlineData("1\n2,3", 6)] // new lines between numbers 
        [InlineData("1, 5 , 1200 ", 6)] // numbers larger than 1000
        [InlineData(" 1200 ", 0)] // one number larger than 1000
        public void AddShouldReturnSum(string numbers, int expected)
        {
            //Act
            _result = _stringCalculater.Add(numbers);
            //Assert
            _result.Should().Be(expected);
        }
        [Theory]
        [InlineData("-1,5")] // negative number with default delimiter
        [InlineData("//;\n1;2;3;-4;5;6")] // negative number with specific delimiter
        [InlineData("//;\n1;2;3;-4;5\n6")] // negative number with specific delimiter and new lines between numbers
        public void AddShouldThrowException(string numbers)
        {
            //Act and Assert
            Action act = () => _stringCalculater.Add(numbers);
            //Assert
            act.Should().Throw<ArgumentException>();
        }
        [Theory]
        [InlineData("1\n2,3,4", new int[] { 1, 2, 3, 4 })] // default delimiter with new lines between numbers 
        [InlineData("//;\n1;2;3\n4;5;6", new int[] { 1, 2, 3, 4, 5, 6 })] // specifed delemiter with new lines between numbers
        [InlineData("//;\n1;2;3;4;5;6", new int[] { 1, 2, 3, 4, 5, 6 })] // specifed delemiter
        [InlineData("1,5,6", new int[] { 1, 5, 6 })] // default delimiter
        public void FormatAndParse_shouldReturn_ArrayOfIntegers(string numbers, int[] expected)
        {
            //Act
            int[] nums = _stringCalculater.FormatAndParse(numbers);
            //Assert
            nums.Should().Equal(expected);
        }
    }
}