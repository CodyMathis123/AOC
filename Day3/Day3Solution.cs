using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AOC2024.Day3
{
    internal class Day3Solution : AoCSolver
    {
        private readonly string[] _lines;
        private readonly string _mulPattern = @"mul\(\d+,\d+\)";
        private readonly string _doPattern = @"do\(\)";
        private readonly string _doNotPattern = @"don't\(\)";
        private readonly string _numberPattern = @"\d+";
        private readonly SortedList<int, string> _instructions = new SortedList<int, string>();

        public override int Day => 3;

        public Day3Solution()
        {
            _lines = GetInput();
        }

        public override Solution PartOne()
        {
            _stopwatch.Restart();
            var total = 0;
            var oneLine = string.Join(string.Empty, _lines);
            var mulMatches = Regex.Matches(oneLine, _mulPattern);
            foreach (Capture match in mulMatches)
            {
                _instructions.Add(match.Index, match.Value);
                var numbers = Regex.Matches(match.ToString(), _numberPattern);
                total += int.Parse(numbers[0].Value) * int.Parse(numbers[1].Value);
            }
            var doMatches = Regex.Matches(oneLine, _doPattern);
            foreach (Capture match in doMatches)
            {
                _instructions.Add(match.Index, match.Value);
            }
            var doNotMatches = Regex.Matches(oneLine, _doNotPattern);
            foreach (Capture match in doNotMatches)
            {
                _instructions.Add(match.Index, match.Value);
            }
            _stopwatch.Stop();
            return new Solution()
            {
                Part = 1,
                Day = this.Day,
                Elapsed = _stopwatch.Elapsed,
                Answer = total.ToString()
            };
        }

        public override Solution PartTwo()
        {
            _stopwatch.Restart();
            var total = 0;
            var calculate = true;
            foreach(var instruction in _instructions)
            {
                if (instruction.Value.Equals("do()"))
                {
                    calculate = true; continue;
                }
                if (instruction.Value.Equals("don't()"))
                {
                    calculate = false; continue;
                }
                if (calculate && instruction.Value.StartsWith("mul"))
                {
                    var numbers = Regex.Matches(instruction.Value.ToString(), _numberPattern);
                    total += int.Parse(numbers[0].Value) * int.Parse(numbers[1].Value);
                }
            }
            _stopwatch.Stop();
            return new Solution()
            {
                Part = 2,
                Day = this.Day,
                Elapsed = _stopwatch.Elapsed,
                Answer = total.ToString()
            };
        }
    }
}
