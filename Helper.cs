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
    }
}