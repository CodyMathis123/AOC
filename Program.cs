using System.Diagnostics;
using System.Reflection;
using AOC2024;


var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day1\input.txt");
var lines = Helper.GetInput(1);
var stopwatch = new Stopwatch();
stopwatch.Start();

List<int> left = new(lines.Length);
List<int> right = new(lines.Length);

// Part 1
foreach (var line in lines)
{
    var parts = line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
    if (parts.Length == 2)
    {
        left.Add(int.Parse(parts[0]));
        right.Add(int.Parse(parts[1]));
    }
}
left.Sort();
right.Sort();

var totalDistance = 0;

for (int i = 0; i < left.Count; i++)
{
    totalDistance += Math.Abs(right[i] - left[i]);
}

Console.WriteLine("Part 1:");
Console.WriteLine(totalDistance);

// Part 2
var totalSimilarity = 0;
foreach (int number in left)
{
    totalSimilarity += number * right.Count(n => n == number);
}
Console.WriteLine("Part 2:");
Console.WriteLine(totalSimilarity);

stopwatch.Stop();

Console.WriteLine("Total Runtime:");
Console.WriteLine(stopwatch.Elapsed);


// Day 2
filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day2\input.txt");
lines = Helper.GetInput(2);
stopwatch.Restart();
var safeCount = 0;
var unsafeLines = new List<string>();
foreach(string line in lines)
{
    var report = line.Split([' ']).Select(int.Parse).ToList();
    var orderedDictionary = new Dictionary<int, int>();
    var step = 0;
    foreach (var pair in report)
    {
        orderedDictionary.Add(step, pair);
        step++;
    }

    var direction = orderedDictionary[0] < orderedDictionary[1] ? "Increasing" : "Decreasing";
    if (orderedDictionary.All((Func<KeyValuePair<int, int>, bool>)Safe(report, direction)))
    {
        safeCount++;
    }
    else
    {
        unsafeLines.Add(line);
    }
}
Console.WriteLine("Day2");
Console.WriteLine("Part 1:");
Console.WriteLine(safeCount);
stopwatch.Stop();

Console.WriteLine("Total Runtime:");
Console.WriteLine(stopwatch.Elapsed);
stopwatch.Restart();
foreach (string line in unsafeLines)
{
    var report = line.Split([' ']).Select(int.Parse).ToList();
    var orderedDictionary = new Dictionary<int, int>();
    var step = 0;
    foreach (var pair in report)
    {
        orderedDictionary.Add(step, pair);
        step++;
    }


    for (int i = 0; i < orderedDictionary.Count; i++)
    {
        report = line.Split([' ']).Select(int.Parse).ToList();
        report.RemoveAt(i);
        var oneRemoved = orderedDictionary.Where(b => b.Key != i).ToDictionary();
        var reindex = new Dictionary<int, int>();
        var restep = 0;
        foreach (var newpair in oneRemoved)
        {
            reindex.Add(restep, newpair.Value);
            restep++;
        }
        var direction = reindex[0] < reindex[1] ? "Increasing" : "Decreasing";
        if (reindex.All((Func<KeyValuePair<int, int>, bool>)Safe(report, direction)))
        {
            safeCount++;
            break;
        }

    }
}
Console.WriteLine("Day2");
Console.WriteLine("Part 2:");
Console.WriteLine(safeCount);
stopwatch.Stop();

Console.WriteLine("Total Runtime:");
Console.WriteLine(stopwatch.Elapsed);

static Func<KeyValuePair<int, int>, bool> Safe(List<int> report, string direction)
{
    return e =>
    {
        var myIndex = e.Key;
        if (myIndex == 0) { return true; }
        var prevValue = report[myIndex - 1];
        var diff = Math.Abs(e.Value - prevValue);
        if (diff == 0)
        {
            return false;
        }
        var alwaysIncreasing = e.Value > prevValue && diff <= 3;
        var alwaysDecreasing = e.Value < prevValue && diff <= 3;
        return (alwaysDecreasing && direction == "Decreasing") || (alwaysIncreasing && direction == "Increasing");
    };
}