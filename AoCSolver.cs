using System.Diagnostics;

namespace AOC2024
{
    public abstract class AoCSolver
    {
        protected readonly Stopwatch _stopwatch = new Stopwatch();
        protected readonly List<Solution> _solutions = new List<Solution>();

        public abstract int Day { get; }

        public List<Solution> Solve()
        {
            _solutions.Clear();
            _solutions.Add(PartOne());
            _solutions.Add(PartTwo());
            return _solutions;
        }

        public abstract Solution PartOne();

        public abstract Solution PartTwo();

        protected string[] GetInput()
        {
            return Helper.GetInput(Day);
        }
    }
}