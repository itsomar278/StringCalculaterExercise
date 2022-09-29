using System.Text;

namespace StringCalculaterExercise
{
    public class StringCalculater
    {
        public static void Main()
        {

        }
        public int Add(string numbers)
        {
            if (string.IsNullOrEmpty(numbers))
            {
                return 0;
            }
            else
            {
                if (numbers.Contains(',') || numbers.Contains('\n'))
                {
                    int[] nums = FormatAndParse(numbers);
                    foreach (int num in nums)
                    {
                        if (num < 0)
                        {
                            throw new ArgumentException($"negatives not allowed : {num}");
                        }
                    }
                    return nums.Where(num => num < 1000).Sum();
                }
                else
                {
                    if (int.Parse(numbers) > 1000)
                    {
                        return 0;
                    }
                    else
                    {
                        return int.Parse(numbers);
                    }
                }
            }
        }

        public int[] FormatAndParse(string numbers)
        {
            StringBuilder delimiter= new StringBuilder();
            if (numbers.Contains("//"))
            {
                int x = numbers.IndexOf("\n");
                
                for (int i = 2; i < numbers.IndexOf("\n"); i++)
                {
                    char c = numbers[i];
                    delimiter.Append(c);
                }
               numbers = numbers.Remove(0, numbers.IndexOf("\n")+1);
            }
            else
            {
                delimiter.Append(",");
            }
            numbers = numbers.Replace("\n", delimiter.ToString());
            int[] numbersArray = Array.ConvertAll(numbers.Trim().Split(delimiter.ToString()), int.Parse);
            return numbersArray;
        }

    }
}