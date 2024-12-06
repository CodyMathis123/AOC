namespace AOC2024.Day6
{
    internal class Day6Solution : AoCSolver
    {
        public override int Day => 6;

        private readonly string[] _lines;
        private readonly double[,] _matrix;
        private readonly int _width;
        private readonly int _height;
        private readonly List<Coord> _grid = new List<Coord>();

        private class Coord
        {
            public Coord()
            {
                ID = Guid.NewGuid();
            }
            public Coord(int x, int y) : this()
            {
                X = x;
                Y = y;
            }

            public Coord(int x, int y, bool canVisit, bool isStart = false) : this(x, y)
            { CanVisit = canVisit; IsStart = isStart; }

            public Coord(Coord movedTo) : this(movedTo.X, movedTo.Y, movedTo.CanVisit, movedTo.IsStart)
            {
                VisitedCount = movedTo!.VisitedCount;
            }

            public Guid ID { get; }
            public int X { get; set; } 
            public int Y { get; set; }
            public int VisitedCount = 0;
            public bool CanVisit { get; set; } = false;
            public bool IsStart { get; set; } = false;
        }

        public Day6Solution()
        {
            _lines = GetInput();
            _width = _lines[0].Length;
            _height = _lines.Length;

            _matrix = new double[_height, _width];
            for (int i = 0; i < _height; i++)
            {
                var line = _lines[i];
                for (int j = 0; j < _width; j++)
                {
                    _matrix[i, j] = line[j];
                    if (line[j].Equals('^'))
                    {
                        _grid.Add(new Coord(j, i, true, true));
                    }
                    else if (line[j].Equals('#'))
                    {
                        _grid.Add(new Coord(j, i, false));
                    }
                    else
                    {
                        _grid.Add(new Coord(j, i, true));
                    }
                }
            }
        }

        public override Solution PartOne()
        {
            _stopwatch.Restart();
            var stepStack = new Stack<Coord>();

            var direction = Direction.up;
            Coord start = _grid.First(g => g.IsStart);
            start.VisitedCount++;
            stepStack.Push(start);
            while (NextPositionExists(stepStack.Peek(), direction))
            {
                stepStack.Push(NextCoord(stepStack.Peek(), direction));

                if (!stepStack.Peek().CanVisit)
                {
                    stepStack.Pop();
                    direction = ChangeDirection(direction);
                }
                else
                {
                    stepStack.Peek().VisitedCount++;
                }
            };
           

            _stopwatch.Stop();

            return new Solution()
            {
                Answer = stepStack.DistinctBy(d => d.ID).Count().ToString(),
                Day = this.Day,
                Part = 1,
                Elapsed = _stopwatch.Elapsed
            };
        }

        public override Solution PartTwo()
        {
            _stopwatch.Restart();

            _stopwatch.Stop();

            return new Solution()
            {
                Answer = string.Empty,
                Day = this.Day,
                Part = 1,
                Elapsed = _stopwatch.Elapsed
            };
        }

        private enum Direction
        {
            up, right, down, left
        }

        private Direction ChangeDirection(Direction direction)
        {
            return (int)direction + 1 > 3 ? Direction.up : direction + 1;
        }

        private Coord NextCoord(Coord currentLocation, Direction direction)
        {
            switch (direction)
            {
                case Direction.up:
                    return _grid.First(g => g.X == currentLocation.X && g.Y == currentLocation.Y - 1);

                case Direction.right:
                    return _grid.First(g => g.X == currentLocation.X + 1 && g.Y == currentLocation.Y);

                case Direction.down:
                    return _grid.First(g => g.X == currentLocation.X && g.Y == currentLocation.Y + 1);

                case Direction.left:
                    return _grid.First(g => g.X == currentLocation.X - 1 && g.Y == currentLocation.Y);
            }

            return currentLocation;
        }

        private bool NextPositionExists(Coord currentLocation, Direction direction)
        {
            var x = currentLocation.X;
            var y = currentLocation.Y;
            switch (direction)
            {
                case Direction.up:
                    y--;
                    break;

                case Direction.right:
                    x++;
                    break;

                case Direction.down:
                    y++;
                    break;

                case Direction.left:
                    x--;
                    break;
            }
            return x >= 0 && x < _width && y >= 0 && y < _height;
        }

        private bool? CanMove(Coord currentLocation, Direction direction)
        {
            return NextCoord(currentLocation, direction)?.CanVisit;
        }

    }
}