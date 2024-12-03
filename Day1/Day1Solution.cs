namespace AOC2024.Day1
{
    internal class Day1Solution : AOCSolution
    {
        public override int Day => 1;
        private readonly string[] _lines;
        private List<int>? _left;
        private List<int>? _right;

        public Day1Solution()
        {
            _lines = GetInput();
        }

        public override string PartOne()
        {
            _left = new(_lines.Length);
            _right = new(_lines.Length);

            // Part 1
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
            return totalDistance.ToString();
        }

        public override string PartTwo()
        {
            var totalSimilarity = 0;
            foreach (int number in _left)
            {
                totalSimilarity += number * _right.Count(n => n == number);
            }
            return totalSimilarity.ToString();
        }
    }
}