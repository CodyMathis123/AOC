using System.Diagnostics;
using System.Reflection;

var stopwatch = new Stopwatch();
stopwatch.Start();

var filePath = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), @"Day1\input.txt");
var lines = File.ReadAllLines(filePath);

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
Console.WriteLine(stopwatch.ElapsedMilliseconds);
