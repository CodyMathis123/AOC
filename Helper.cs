using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024
{
    public class Helper
    {
        public static string[] GetInput(int day)
        {
            var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), $@"Day{day}\input.txt");
            return File.ReadAllLines(filePath);
        }
    }
}
