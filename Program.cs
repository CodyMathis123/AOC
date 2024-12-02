using AOC2024;

var solutions = typeof(Program).Assembly.GetTypes().Where(t => !t.IsAbstract && typeof(AOCSolution).IsAssignableFrom(t)).ToArray();

var days = solutions
    .Where(type =>
        type.GetConstructor(Type.EmptyTypes) != null &&
         !type.IsAbstract && typeof(AOCSolution).IsAssignableFrom(type))
    .Select(type => Activator.CreateInstance(type) as AOCSolution)
    .OrderBy(c => c?.Day);
foreach (var day in days)
{
    day?.Solve();
}