namespace AOC2024.Day4
{
    internal class Day4Solution : AoCSolver
    {
        private readonly string[] _lines;
        private readonly List<XmasLetter> xmasLetters = new List<XmasLetter>();
        private List<XmasLetter>? _x;
        private List<XmasLetter>? _m;
        private List<XmasLetter>? _a;
        private List<XmasLetter>? _s;

        public override int Day => 4;

        public Day4Solution()
        {
            _lines = GetInput();
        }

        public override Solution PartOne()
        {
            _stopwatch.Restart();
            int rowIndex = 0;
            int colIndex = 0;
            foreach (var row in _lines)
            {
                foreach (var letter in row)
                {
                    xmasLetters.Add(new XmasLetter(colIndex, rowIndex, letter));
                    colIndex++;
                }

                rowIndex++;
                colIndex = 0;
            }
            _x = xmasLetters.Where(x => x.Letter == 'X').ToList();
            _m = xmasLetters.Where(x => x.Letter == 'M').ToList();
            _a = xmasLetters.Where(x => x.Letter == 'A').ToList();
            _s = xmasLetters.Where(x => x.Letter == 'S').ToList();

            var horizontalXmas = _x.Count(mas =>
            {
                return
                    (_m.Any(xas => xas.Row == mas.Row && xas.Column == mas.Column + 1) &&
                    _a.Any(xms => xms.Row == mas.Row && xms.Column == mas.Column + 2) &&
                    _s.Any(xma => xma.Row == mas.Row && xma.Column == mas.Column + 3));
            }
            ) + _x.Count(mas =>
            {
                return (_m.Any(xas => xas.Row == mas.Row && xas.Column == mas.Column - 1) &&
                    _a.Any(xms => xms.Row == mas.Row && xms.Column == mas.Column - 2) &&
                    _s.Any(xma => xma.Row == mas.Row && xma.Column == mas.Column - 3));
            }
            );
            var verticalXmas = _x.Count(mas =>
            {
                return
                    (_m.Any(xas => xas.Row == mas.Row + 1 && xas.Column == mas.Column) &&
                    _a.Any(xms => xms.Row == mas.Row + 2 && xms.Column == mas.Column) &&
                    _s.Any(xma => xma.Row == mas.Row + 3 && xma.Column == mas.Column));
            }
            ) + _x.Count(mas =>
            {
                return
                (_m.Any(xas => xas.Row == mas.Row - 1 && xas.Column == mas.Column) &&
                _a.Any(xms => xms.Row == mas.Row - 2 && xms.Column == mas.Column) &&
                _s.Any(xma => xma.Row == mas.Row - 3 && xma.Column == mas.Column));
            }
            );
            var diagonalXmas = _x.Count(mas =>
            {
                return
                    (_m.Any(xas => xas.Row == mas.Row + 1 && xas.Column == mas.Column + 1) &&
                    _a.Any(xms => xms.Row == mas.Row + 2 && xms.Column == mas.Column + 2) &&
                    _s.Any(xma => xma.Row == mas.Row + 3 && xma.Column == mas.Column + 3));
            }
            ) + _x.Count(mas =>
            {
                return
                    (_m.Any(xas => xas.Row == mas.Row - 1 && xas.Column == mas.Column - 1) &&
                    _a.Any(xms => xms.Row == mas.Row - 2 && xms.Column == mas.Column - 2) &&
                    _s.Any(xma => xma.Row == mas.Row - 3 && xma.Column == mas.Column - 3));
            }) + _x.Count(mas =>
            {
                return
                    (_m.Any(xas => xas.Row == mas.Row - 1 && xas.Column == mas.Column + 1) &&
                    _a.Any(xms => xms.Row == mas.Row - 2 && xms.Column == mas.Column + 2) &&
                    _s.Any(xma => xma.Row == mas.Row - 3 && xma.Column == mas.Column + 3));
            }
            ) + _x.Count(mas =>
            {
                return
                    (_m.Any(xas => xas.Row == mas.Row + 1 && xas.Column == mas.Column - 1) &&
                    _a.Any(xms => xms.Row == mas.Row + 2 && xms.Column == mas.Column - 2) &&
                    _s.Any(xma => xma.Row == mas.Row + 3 && xma.Column == mas.Column - 3));
            }
            );

            _stopwatch.Stop();

            return new Solution()
            {
                Part = 1,
                Day = this.Day,
                Elapsed = _stopwatch.Elapsed,
                Answer = (horizontalXmas + verticalXmas + diagonalXmas).ToString()
            };
        }

        public override Solution PartTwo()
        {
            _stopwatch.Restart();

            var scenario1 = _a.Count(a =>
            {
                return _m.Any(mas => mas.Row == a.Row - 1 && mas.Column == a.Column - 1) &&
                        _m.Any(mas => mas.Row == a.Row - 1 && mas.Column == a.Column + 1) &&
                        _s.Any(mas => mas.Row == a.Row + 1 && mas.Column == a.Column - 1) &&
                        _s.Any(mas => mas.Row == a.Row + 1 && mas.Column == a.Column + 1);
            }
            );

            var scenario2 = _a.Count(a =>
            {
                return _m.Any(mas => mas.Row == a.Row - 1 && mas.Column == a.Column - 1) &&
                        _m.Any(mas => mas.Row == a.Row + 1 && mas.Column == a.Column - 1) &&
                        _s.Any(mas => mas.Row == a.Row - 1 && mas.Column == a.Column + 1) &&
                        _s.Any(mas => mas.Row == a.Row + 1 && mas.Column == a.Column + 1);
            }
            );

            var scenario3 = _a.Count(a =>
            {
                return _m.Any(mas => mas.Row == a.Row - 1 && mas.Column == a.Column + 1) &&
                        _m.Any(mas => mas.Row == a.Row + 1 && mas.Column == a.Column + 1) &&
                        _s.Any(mas => mas.Row == a.Row + 1 && mas.Column == a.Column - 1) &&
                        _s.Any(mas => mas.Row == a.Row - 1 && mas.Column == a.Column - 1);
            }
            );

            var scenario4 = _a.Count(a =>
            {
                return _m.Any(mas => mas.Row == a.Row + 1 && mas.Column == a.Column - 1) &&
                        _m.Any(mas => mas.Row == a.Row + 1 && mas.Column == a.Column + 1) &&
                        _s.Any(mas => mas.Row == a.Row - 1 && mas.Column == a.Column - 1) &&
                        _s.Any(mas => mas.Row == a.Row - 1 && mas.Column == a.Column + 1);
            }
            );

            _stopwatch.Stop();

            return new Solution()
            {
                Part = 2,
                Day = this.Day,
                Elapsed = _stopwatch.Elapsed,
                Answer = (scenario1 + scenario2 + scenario3 + scenario4).ToString()
            };
        }
    }
}