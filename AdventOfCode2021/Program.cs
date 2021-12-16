using System.Diagnostics;
using System.Reflection;
using System.Text.RegularExpressions;

using AdventOfCode2021;

var solutionClassRegex = new Regex(@"^Day(\d{2})Part(\d)$");

string GetId(Type type) => type.Namespace.Substring(type.Namespace.LastIndexOf(".") + 1) + type.Name;

string GetInputFile(Type type) => solutionClassRegex!.Replace(GetId(type), "data/day$1/input");

var solutions = Assembly.GetExecutingAssembly()
    .GetTypes()
    .Where(type => type.IsClass
        && !type.IsAbstract
        && type.IsAssignableTo(typeof(ISolution)))
    .ToDictionary(type => GetId(type).ToLower());

var solutionSet = solutions.Keys.ToHashSet();
var unknownArgs = args.ToHashSet().Except(solutionSet);

if (unknownArgs.Any())
{
    Console.Error.WriteLine($"Unrecognized argument{ (unknownArgs.Count() > 1 ? "s" : "") }: { string.Join(", ", unknownArgs) }, please choose from these: { string.Join(", ", solutionSet.OrderBy(_ => _)) }!");

    return 1;
}

var daysToExecute = args.Any()
    ? solutionSet.Intersect(args).ToArray()
    : solutions.Keys.ToArray();

foreach (var day in daysToExecute.OrderBy(_ => _))
{
    var solutionClass = solutions[day];

    Debug.WriteLine($"Reading input for {day}.");

    var inputFile = GetInputFile(solutionClass);

    if (!File.Exists(inputFile))
    {
        Console.Error.WriteLine($"Input file for { day }: { inputFile } not found!");
        return 2;
    }

    var input = await File.ReadAllLinesAsync(inputFile);

    Debug.WriteLine($"Executing {day}.");
#nullable disable
    var solution = (ISolution)Activator.CreateInstance(solutionClass);
#nullable restore

    try
    {
        var result = solution!.Apply(input);

        if (result is ValueTask<ulong> t) Console.WriteLine(await t);
        else Console.WriteLine(result);

        Debug.WriteLine($"Executing {day} was a success.");
    }
    catch (Exception e)
    {
        Console.Error.WriteLine($"Error while executing { day }: { e }");
        return 3;
    }
}

return 0;
