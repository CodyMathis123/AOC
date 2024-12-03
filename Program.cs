using AOC2024;

var daysToExecute = new List<int>();
if (args.Length > 0)
{
    for (int i = 0; i < args.Length; i++)
    {
        daysToExecute.Add(int.Parse(args[i]));
    }
}

var solutions = typeof(Program).Assembly.GetTypes().Where(t => !t.IsAbstract && typeof(AOCSolution).IsAssignableFrom(t)).ToArray();

var days = solutions
    .Where(type =>
        type.GetConstructor(Type.EmptyTypes) != null &&
         !type.IsAbstract && typeof(AOCSolution).IsAssignableFrom(type))
    .Select(type => Activator.CreateInstance(type) as AOCSolution)
    .OrderBy(c => c?.Day);
foreach (var day in days)
{
    if (daysToExecute.Count == 0 || daysToExecute.Contains(day!.Day))
    {
        Console.WriteLine("--------------------------------------");
        Console.WriteLine($"Day {day!.Day}");
        day.Solve();
        Console.WriteLine("--------------------------------------");
    }
}