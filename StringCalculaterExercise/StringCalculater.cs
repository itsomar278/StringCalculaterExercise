using System;
namespace StringCalculaterExercise
{
    public class StringCalculater
    {
        public static void Main()
        {

        }
        public int add(string numbers )
        {
            if(string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            else
            {
                if(numbers.Contains(","))
                {
                    numbers.Trim();
                    string[] numbersArray = numbers.Split(',');
                    int sum = 0; 
                    foreach (var item in numbersArray)
                    {
                        sum += int.Parse(item); 
                    }
                    return sum;
                }
                else
                {
                    return int.Parse(numbers);
                }
            }
        }
    }
}