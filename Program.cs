using AOC2024;

var solutions = typeof(Program).Assembly.GetTypes().Where(t => !t.IsAbstract && typeof(AOCSolution).IsAssignableFrom(t)).ToArray();

var commands = solutions
    .Where(type =>
        type.GetConstructor(Type.EmptyTypes) != null &&
         !type.IsAbstract && typeof(AOCSolution).IsAssignableFrom(type))
    .Select(type => Activator.CreateInstance(type) as AOCSolution)
    .OrderBy(c => c.Day);
foreach (var command in commands)
{
    command?.Solve();
}