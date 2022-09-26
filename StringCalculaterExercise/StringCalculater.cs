using System;
using System.Linq;

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
                    numbers = numbers.Replace('\n', ',');
                    int[] numbersArray = Array.ConvertAll(numbers.Trim().Split(','), int.Parse); 
                    return numbersArray.Sum(); 
                }
                else
                {
                    return int.Parse(numbers);
                }
            }
        }
    }
}