using AdventOfCode.Puzzles;
using AdventOfCode.Puzzles.Data;
using Spectre.Console;

while (true)
{
    AnsiConsole.Clear();
    AnsiConsole.Write(new FigletText("Advent of Code 2023").Centered().Color(Color.Green));

    var puzzleSolvers = PuzzleSolverFactory.Build().ToList();
    var selectedDay = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Which [green]puzzle[/] you want to solve?")
            .PageSize(10)
            .AddChoices(puzzleSolvers.Select(x => $"Day {x.Day}").Concat(new[] { "Quit" })));

    if (selectedDay == "Quit")
    {
        AnsiConsole.WriteLine("Bye");
        break;
    }

    var selectedPart = AnsiConsole.Prompt(
        new SelectionPrompt<string>()
            .Title("Which [green]part[/] you want to solve?")
            .PageSize(10)
            .AddChoices("Part 1", "Part 2"));

    var selectedSolver = puzzleSolvers.Single(x => $"Day {x.Day}" == selectedDay);
    var fileData = new FileData(File.ReadAllLines($"Data/{selectedDay}.txt"));
    var result = selectedPart switch
    {
        "Part 1" => selectedSolver.SolvePartOne(fileData),
        "Part 2" => selectedSolver.SolvePartTwo(fileData),
        _ => throw new InvalidOperationException("Unknown part"),
    };

    AnsiConsole.Markup($"Your solution of Puzzle for [green]{selectedDay}[/], [green]{selectedPart}[/] is: [red]{result}[/].");
    Console.ReadKey();
}
