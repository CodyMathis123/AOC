using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AOC2024.Day1
{
    internal class Day1Solution : AOCSolution
    {
        public override int Day => 1;

        public override void Solve()
        {
            _stopwatch.Start();
            var lines = GetInput();

            List<int> left = new(lines.Length);
            List<int> right = new(lines.Length);

            // Part 1
            foreach (var line in lines)
            {
                var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    left.Add(int.Parse(parts[0]));
                    right.Add(int.Parse(parts[1]));
                }
            }
            left.Sort();
            right.Sort();

            var totalDistance = 0;

            for (int i = 0; i < left.Count; i++)
            {
                totalDistance += Math.Abs(right[i] - left[i]);
            }

            Console.WriteLine("Part 1:");
            Console.WriteLine(totalDistance);

            // Part 2
            var totalSimilarity = 0;
            foreach (int number in left)
            {
                totalSimilarity += number * right.Count(n => n == number);
            }
            Console.WriteLine("Part 2:");
            Console.WriteLine(totalSimilarity);

            _stopwatch.Stop();

            Console.WriteLine("Total Runtime:");
            Console.WriteLine(_stopwatch.Elapsed);

        }
    }
}
