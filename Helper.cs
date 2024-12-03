using System.Reflection;

namespace AOC2024
{
    public class Helper
    {
        public static string[] GetInput(int day)
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location)!, $@"Day{day}\input.txt");
            return File.ReadAllLines(filePath);
        }

        public static void PrintChristmasTree(int height)
        {
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < height - i - 1; j++)
                {
                    Console.Write(" ");
                }
                for (int k = 0; k < (2 * i + 1); k++)
                {
                    Console.Write("*");
                }
                Console.WriteLine();
            }
            for (int i = 0; i < height - 1; i++)
            {
                Console.Write(" ");
            }
            Console.WriteLine("|");
        }

        internal static void PrintSeparator(string thing)
        {
            Console.WriteLine();
            for (int i = 0; i < 100; i++) { Console.Write(thing); };
            Console.WriteLine();
            Console.WriteLine();
        }
    }
}