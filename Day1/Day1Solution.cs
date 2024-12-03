namespace AOC2024.Day1
{
    internal class Day1Solution : AoCSolver
    {
        public override int Day => 1;
        private readonly string[] _lines;
        private List<int>? _left;
        private List<int>? _right;

        public Day1Solution()
        {
            _lines = GetInput();
        }

        public override Solution PartOne()
        {
            _stopwatch.Restart();
            _left = new(_lines.Length);
            _right = new(_lines.Length);

            foreach (var line in _lines)
            {
                var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
                if (parts.Length == 2)
                {
                    _left.Add(int.Parse(parts[0]));
                    _right.Add(int.Parse(parts[1]));
                }
            }
            _left.Sort();
            _right.Sort();

            var totalDistance = 0;

            for (int i = 0; i < _left.Count; i++)
            {
                totalDistance += Math.Abs(_right[i] - _left[i]);
            }
            _stopwatch.Stop();
            return new Solution()
            {
                Elapsed = _stopwatch.Elapsed,
                Day = this.Day,
                Part = 1,
                Answer = totalDistance.ToString(),
            };
        }

        public override Solution PartTwo()
        {
            _stopwatch.Restart();
            var totalSimilarity = 0;
            foreach (int number in _left!)
            {
                totalSimilarity += number * _right!.Count(n => n == number);
            }
            _stopwatch.Stop();
            return new Solution()
            {
                Elapsed = _stopwatch.Elapsed,
                Day = this.Day,
                Part = 2,
                Answer = totalSimilarity.ToString(),
            };
        }
    }
}