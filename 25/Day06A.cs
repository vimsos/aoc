var input = File.ReadAllLines("input/day06.txt");
var grid = input
    .Select(l => l.Split(null).Where(s => !string.IsNullOrWhiteSpace(s)).ToArray())
    .ToArray();

long result = 0;
var rows = grid.Length;
var cols = grid[0].Length;

for (var j = 0; j < cols; j++)
{
    var op = grid[^1][j];
    var calc = op switch
    {
        "*" => Enumerable
            .Range(0, rows - 1)
            .Select(i => long.Parse(grid[i][j]))
            .Aggregate((long)1, (current, next) => current * next),
        "+" => Enumerable
            .Range(0, rows - 1)
            .Select(i => long.Parse(grid[i][j]))
            .Aggregate((long)0, (current, next) => current + next),
        _ => 0,
    };
    result += calc;
}

Console.WriteLine($"{result}");
