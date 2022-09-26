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
                    return nums.Sum();
                }
                else
                {
                    return int.Parse(numbers);
                }
            }
        }

        public int[] FormatAndParse(string numbers)
        {
            char delimiter;
            if (numbers.Contains("//"))
            {
                delimiter = (char)numbers[2];
                numbers = numbers.Remove(0, 4);
            }
            else
            {
                delimiter = ',';
            }
            numbers = numbers.Replace('\n', delimiter);
            int[] numbersArray = Array.ConvertAll(numbers.Trim().Split(delimiter), int.Parse);
            return numbersArray;
        }

    }
}