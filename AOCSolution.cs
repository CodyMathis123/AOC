using System.Diagnostics;

namespace AOC2024
{
    internal abstract class AOCSolution
    {
        protected readonly Stopwatch _stopwatch = new Stopwatch();

        public abstract int Day { get; }

        public abstract void Solve();

        protected string[] GetInput()
        {
            return Helper.GetInput(Day);
        }
    }
}