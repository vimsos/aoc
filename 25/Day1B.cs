var result = 0;
var position = 50;

var lines = File.ReadAllLines("input/day01.txt");
var moves = lines.Select(l => (l[0] == 'L' ? -1 : 1) * int.Parse(l[1..]));
foreach (var move in moves)
{
    var dialSign = Math.Sign(move);
    for (int dial = move; dial != 0; dial += -dialSign)
    {
        position += dialSign;
        if (position % 100 == 0)
            result++;
    }
}

Console.WriteLine($"{result}");
