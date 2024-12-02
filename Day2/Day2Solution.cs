namespace AOC2024.Day2
{
    internal class Day2Solution : AOCSolution
    {
        public override int Day => 2;

        public override void Solve()
        {
            var lines = GetInput();

            _stopwatch.Start();
            var safeCount = 0;
            var unsafeLines = new List<string>();

            foreach (string line in lines)
            {
                var report = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                if (IsSafe(report))
                {
                    safeCount++;
                }
                else
                {
                    unsafeLines.Add(line);
                }
            }

            Console.WriteLine("Part 1:");
            Console.WriteLine(safeCount);
            _stopwatch.Stop();
            Console.WriteLine($"Elapsed: {_stopwatch.Elapsed}");

            _stopwatch.Restart();
            foreach (string line in unsafeLines)
            {
                var report = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                if (IsSafeWithOneSkip(report))
                {
                    safeCount++;
                }
            }

            Console.WriteLine("Part 2:");
            Console.WriteLine(safeCount);

            _stopwatch.Stop();
            Console.WriteLine($"Elapsed: {_stopwatch.Elapsed}");

            static bool IsSafe(List<int> report)
            {
                bool increasing = true;
                bool decreasing = true;

                for (int i = 1; i < report.Count; i++)
                {
                    int diff = report[i] - report[i - 1];
                    if (diff == 0 || Math.Abs(diff) > 3)
                    {
                        return false;
                    }
                    if (diff < 0)
                    {
                        increasing = false;
                    }
                    if (diff > 0)
                    {
                        decreasing = false;
                    }
                }

                return increasing || decreasing;
            }

            static bool IsSafeWithOneSkip(List<int> report)
            {
                for (int i = 0; i < report.Count; i++)
                {
                    var modifiedReport = new List<int>(report);
                    modifiedReport.RemoveAt(i);
                    if (IsSafe(modifiedReport))
                    {
                        return true;
                    }
                }
                return false;
            }
        }
    }
}
