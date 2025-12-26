var grid = File.ReadAllLines("input/day06.txt").Select(l => l.AsEnumerable().ToArray()).ToArray();

long result = 0;
var rows = grid.Length;
var cols = grid[0].Length;

for (var j = 0; j < cols; j++)
{
    var op = grid[^1][j];
    if (op is ' ')
        continue;

    var opEnd = grid[^1].AsSpan()[(j + 1)..].IndexOfAny(['+', '*']);
    opEnd = opEnd is -1 ? cols : j + opEnd;

    List<long> nums = [];
    for (var jj = j; jj < opEnd; jj++)
    {
        var num = 0;
        for (var i = 0; i < rows - 1; i++)
        {
            if (int.TryParse($"{grid[i][jj]}", out var digit))
                num = digit + num * 10;
        }
        nums.Add(num);
    }

    var calc = op switch
    {
        '*' => nums.Aggregate(1L, (current, next) => current * next),
        '+' => nums.Aggregate(0L, (current, next) => current + next),
        _ => 0,
    };

    result += calc;
}

Console.WriteLine($"{result}");
