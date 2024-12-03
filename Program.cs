using AOC2024;

var daysToExecute = new List<int>();
if (args.Length > 0)
{
    for (int i = 0; i < args.Length; i++)
    {
        daysToExecute.Add(int.Parse(args[i]));
    }
}

var solutions = typeof(Program).Assembly.GetTypes().Where(t => !t.IsAbstract && typeof(AoCSolver).IsAssignableFrom(t)).ToArray();

var days = solutions
    .Where(type =>
        type.GetConstructor(Type.EmptyTypes) != null &&
         !type.IsAbstract && typeof(AoCSolver).IsAssignableFrom(type))
    .Select(type => Activator.CreateInstance(type) as AoCSolver)
    .OrderBy(c => c!.Day);
foreach (var day in days)
{
    if (daysToExecute.Count == 0 || daysToExecute.Contains(day!.Day))
    {
        Console.WriteLine();
        for (int i = 0; i < 100; i++) { Console.Write('-'); };
        Console.WriteLine();
        var daySolutions = day!.Solve();
        foreach (var daySolution in daySolutions)
        {
            Console.WriteLine(daySolution);
        }
        Console.WriteLine();
        for (int i = 0; i < 100; i++) { Console.Write('-'); };
    }
}
Helper.PrintChristmasTree(days.Count());