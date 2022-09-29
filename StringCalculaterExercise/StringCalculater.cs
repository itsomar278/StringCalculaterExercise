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
            if (numbers.Length == 0)
            {
                return 0;
            }
            else
            {
                int[] nums = FormatAndParse(numbers);
                return nums.Sum();
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
            foreach (int num in numbersArray)
            {
                if (num < 0)
                {
                    throw new ArgumentException($"negatives not allowed : {num}");
                }
            }
            return numbersArray.Where(x=> x < 1000).ToArray();
        }

    }
}