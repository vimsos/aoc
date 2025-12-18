var map = File.ReadAllLines("input/day04.txt").Select(l => l.AsEnumerable().ToArray()).ToArray();

var rows = map.Length;
var cols = map[0].Length;
List<(int X, int Y)> directions =
[
    (-1, -1),
    (-1, 0),
    (-1, 1),
    (0, -1),
    (0, 1),
    (1, -1),
    (1, 0),
    (1, 1),
];

var count = 0;

for (var x = 0; x < rows; x++)
for (var y = 0; y < cols; y++)
{
    var c = map[x][y];

    if (c is not '@')
        continue;

    var adjacent = directions.Count(d =>
        x + d.X >= 0
        && x + d.X < rows
        && y + d.Y >= 0
        && y + d.Y < cols
        && map[x + d.X][y + d.Y] == '@'
    );

    if (adjacent < 4)
        count++;
}

Console.WriteLine($"{count}");
