namespace AOC2024.Day5
{
    internal class Day5Solution : AoCSolver
    {
        public override int Day => 5;

        private readonly string[] _lines;
        private readonly Dictionary<int, List<int>> _rules = new Dictionary<int, List<int>>();
        private readonly List<List<int>> _unordered = new List<List<int>>();

        public Day5Solution()
        {
            _lines = GetInput();
        }

        public override Solution PartOne()
        {
            _stopwatch.Restart();
            // The top section is the 'rules'
            // each line indicates that if page x is in the list at the bottom, it must precede y
            // i.e. if we have 37|69 and a page list of 1,4,6,37,56,69 this is valid
            // Once we have all the 'update' at the bottom that are valid we need the sum of the 'middle' numbers

            var preProcessedRules = _lines.Where(x => x.Contains('|'));
            foreach (var rule in preProcessedRules)
            {
                var s = rule.Split('|');
                var x = int.Parse(s[0]);
                var y = int.Parse(s[1]);
                if (_rules.ContainsKey(x)) { _rules[x].Add(y); }
                else { _rules[x] = new List<int>() { y }; }
            }

            var preProcessedUpdates = _lines.Where(x => x.Contains(','));

            var solution = 0;
            foreach (var line in preProcessedUpdates)
            {
                var s = line.Split(",").Select(s => int.Parse(s)).ToList();
                var isOrdered = IsOrdered(s);
                if (isOrdered)
                {
                    var middlePage = s.ElementAt((s.Count - 1) / 2);
                    solution += middlePage;
                }
                else
                {
                    _unordered.Add(s);
                }
            }

            _stopwatch.Stop();

            return new Solution()
            {
                Answer = solution.ToString(),
                Day = this.Day,
                Part = 1,
                Elapsed = _stopwatch.Elapsed
            };
        }

        private bool IsOrdered(List<int> list)
        {
            foreach (var rule in _rules)
            {
                if (list.Contains(rule.Key))
                {
                    var keyLocation = list.IndexOf(rule.Key);
                    if (!rule.Value.All(v => !list.Contains(v) || list.IndexOf(v) > keyLocation)) { return false; }
                }
            }
            return true;
        }

        public override Solution PartTwo()
        {
            _stopwatch.Restart();
            var solution = 0;

            foreach (var unordered in _unordered)
            {
                var ordered = unordered.ToList();
                while (!IsOrdered(ordered))
                {
                    for (var i = 0; i < ordered.Count; i++)
                    {
                        if (_rules.ContainsKey(ordered[i]))
                        {
                            var keyLocation = ordered.IndexOf(ordered[i]);
                            var rule = _rules[ordered[i]];
                            foreach (var r in rule)
                            {
                                if (ordered.Contains(r) && ordered.IndexOf(r) < keyLocation)
                                {
                                    var temp = ordered[i];
                                    ordered[i] = ordered[ordered.IndexOf(r)];
                                    ordered[ordered.IndexOf(r)] = temp;
                                }
                            }
                        }
                    }
                }
                var middlePage = ordered.ElementAt((ordered.Count - 1) / 2);
                solution += middlePage;
            }

            _stopwatch.Stop();

            return new Solution()
            {
                Answer = solution.ToString(),
                Day = this.Day,
                Part = 2,
                Elapsed = _stopwatch.Elapsed
            };
        }
    }
}