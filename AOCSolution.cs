using System.Diagnostics;

namespace AOC2024
{
    public abstract class AOCSolution
    {
        protected readonly Stopwatch _stopwatch = new Stopwatch();

        public abstract int Day { get; }

        public void Solve()
        {
            Console.WriteLine("Part 1:");
            _stopwatch.Restart();
            Console.WriteLine("Solution: " + PartOne());
            _stopwatch.Stop();
            Console.WriteLine($"Elapsed: {_stopwatch.Elapsed}");

            Console.WriteLine("Part 2:");
            _stopwatch.Restart();
            Console.WriteLine("Solution: " + PartTwo());
            _stopwatch.Stop();
            Console.WriteLine($"Elapsed: {_stopwatch.Elapsed}");
        }

        public abstract string PartOne();

        public abstract string PartTwo();

        protected string[] GetInput()
        {
            return Helper.GetInput(Day);
        }
    }
}