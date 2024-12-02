using System.Diagnostics;
using System.Reflection;
using AOC2024;

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
lines = Helper.GetInput(2);
stopwatch.Restart();
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

Console.WriteLine("Day2");
Console.WriteLine("Part 1:");
Console.WriteLine(safeCount);
stopwatch.Stop();

Console.WriteLine("Total Runtime:");
Console.WriteLine(stopwatch.Elapsed);
stopwatch.Restart();

foreach (string line in unsafeLines)
{
    var report = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
    if (IsSafeWithOneSkip(report))
    {
        safeCount++;
    }
}

Console.WriteLine("Day2");
Console.WriteLine("Part 2:");
Console.WriteLine(safeCount);
stopwatch.Stop();

Console.WriteLine("Total Runtime:");
Console.WriteLine(stopwatch.Elapsed);

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
