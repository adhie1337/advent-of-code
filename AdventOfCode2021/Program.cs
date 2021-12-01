using System.Diagnostics;
using System.Reflection;

var daysImplemented = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(_ => _.Namespace == "AdventOfCode2021.Days" && _.GetMethod("Execute", BindingFlags.Public|BindingFlags.Static) != null)
    .ToDictionary(_ => _.Name.ToLower());

var implementedSet = daysImplemented.Keys.ToHashSet();
var unknownArgs = args.ToHashSet().Except(implementedSet);

if (unknownArgs.Any())
{
    Console.Error.WriteLine($"Unrecognized argument{ (unknownArgs.Count() > 1 ? "s" : "") }: { string.Join(", ", unknownArgs) }, please choose from these: { string.Join(", ", implementedSet.OrderBy(_ => _)) }!");
    Environment.Exit(1);
}

var daysToExecute = args.Any()
    ? implementedSet.Intersect(args).ToArray()
    : daysImplemented.Keys.ToArray();

foreach (var day in daysToExecute.OrderBy(_ => _))
{
    Debug.WriteLine($"Executing {day}.");
    var r = daysImplemented[day].GetMethod("Execute")?.Invoke(null, new object?[0]);

    if (r is Task<string> task)
    {
        var errorMessageResult = await task;

        if (errorMessageResult is string errorMessage)
        {
            Console.Error.WriteLine(errorMessage);
            Environment.Exit(2);
        }
        else
        {
            Debug.WriteLine($"{day} executed.");
        }
    }
}
