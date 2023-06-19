

namespace Lab03ReviewTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {

                Console.WriteLine(Products());
                Console.WriteLine(AvgNumber());
                Stars();
                Console.WriteLine(MaxFrequantedNumber(new int[] { 4, 2, 2, 4, 3, 4, 2, 1, 3 }));
                Console.WriteLine(MaxValue(new int[] { 5, 25, 99, 123, 78, 96, 555, 108, 4 }));
                Console.Write("enter a word to add to words.txt file please : ");
                WriteToFile(Console.ReadLine());
                ReadFromFile();
                Console.Write("enter a word to delete from words.txt : ");
                DeleteFromFile(Console.ReadLine());
                string[] arr = WordLength();
                for (int i = 0; i < arr.Length; i++)
                {
                    Console.Write(arr[i]);
                }
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static int Products()
        {
            Console.Write("please enter 3 numbers with a space between them:");
            string userInput = Console.ReadLine();
            int[] userInt = new int[3];
            string[] userInputArray = userInput.Split(" ");

            if (userInputArray.Length < 3)
            {
                return 0;
            }
            for (int i = 0; i < userInt.Length; i++)
            {
                if (int.TryParse(userInputArray[i], out userInt[i]))
                { }
                else
                {
                    userInt[i] = 1;
                }
            }
            return userInt[0] * userInt[1] * userInt[2];
        }

        public static int AvgNumber()
        {
            Console.Write("enter a number between 2-10\n\n");
            int userInput = Convert.ToInt32(Console.ReadLine());
            int sum = 0;
            if (userInput < 2 || userInput > 10)
            {
                throw new Exception("number less than 2 or bigger than 10");
            }
            for (int i = 0; i < userInput; i++)
            {
                Console.Write($"{i + 1} of {userInput} - Enter a number: ");
                sum += Convert.ToInt32(Console.ReadLine());
            }
            return sum / userInput;
        }

        public static void Stars()
        {
            int star = 1;
            int space = 4;
            for (int i = 0; i < 9; i++)
            {
                for (int j = 0; j < space; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < star; k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
                if (i >= 4)
                {
                    star -= 2;
                    space++;
                }
                else
                {
                    star += 2;
                    space--;
                }
            }
        }

        public static int MaxFrequantedNumber(int[] arr)
        {
            // [1, 2, 2, 3, 3, 3, 4]
            int mostFrequent = arr[0];
            int highestCount = 1;

            for (int i = 0; i < arr.Length; i++)
            {
                int currentCount = 1;
                for (int j = i + 1; j < arr.Length; j++)
                {
                    if (arr[j] == arr[i])
                    {
                        currentCount++;
                    }
                }
                if (currentCount > highestCount)
                {
                    highestCount = currentCount;
                    mostFrequent = arr[i];
                }
            }

            return mostFrequent;
        }

        public static int MaxValue(int[] arr)
        {
            if (arr.Length == 0 || arr == null)
            {
                return 0;
            }
            int max = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i] > max)
                    max = arr[i];
            }
            return max;
        }

        public static void WriteToFile(string input)
        {
            string path = "../../../words.txt";
            File.AppendAllText(path, input);
        }

        public static void ReadFromFile()
        {
            string path = "../../../words.txt";
            Console.WriteLine(File.ReadAllText(path));

        }

        public static void DeleteFromFile(string input)
        {
            string path = "../../../words.txt";
            string[] lines = File.ReadAllLines(path);
            for (int i = 0; i < lines.Length; i++)
            {
                if (lines[i] == input)
                {
                    lines[i] = string.Empty;
                }
            }
            File.WriteAllLines(path, lines);
        }

        public static string[] WordLength()
        {
            Console.WriteLine("Enter a sentence:");
            string userInput = Console.ReadLine();
            if (userInput != null)
            {
                string[] arr = userInput.Split(' ');
                for (int i = 0; i < arr.Length; i++)
                {
                    arr[i] = $"{arr[i]}: {arr[i].Length}";
                }
                return arr;
            }
            return new string[0]; // Return an empty array if userInput is null
        }
    }
}