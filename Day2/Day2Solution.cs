﻿namespace AOC2024.Day2
{
    internal class Day2Solution : AoCSolver
    {
        public override int Day => 2;
        private readonly string[] _lines;
        private readonly List<string> _unsafeLines = new List<string>();
        private int _safeCount = 0;

        public Day2Solution()
        {
            _lines = GetInput();
        }

        public override Solution PartOne()
        {
            _stopwatch.Restart();
            foreach (string line in _lines)
            {
                var report = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                if (IsSafe(report))
                {
                    _safeCount++;
                }
                else
                {
                    _unsafeLines.Add(line);
                }
            }
            _stopwatch.Stop();
            return new Solution()
            {
                Elapsed = _stopwatch.Elapsed,
                Day = this.Day,
                Part = 1,
                Answer = _safeCount.ToString(),
            };
        }

        public override Solution PartTwo()
        {
            _stopwatch.Restart();
            foreach (string line in _unsafeLines)
            {
                var report = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
                if (IsSafeWithOneSkip(report))
                {
                    _safeCount++;
                }
            }
            _stopwatch.Stop();
            return new Solution()
            {
                Elapsed = _stopwatch.Elapsed,
                Day = this.Day,
                Part = 2,
                Answer = _safeCount.ToString(),
            };
        }

        private static bool IsSafe(List<int> report)
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

        private static bool IsSafeWithOneSkip(List<int> report)
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