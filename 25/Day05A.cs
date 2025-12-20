var input = File.ReadAllText("input/day05.txt");
var split = input.Split("\n\n");

var fresh = split[0]
    .Split('\n')
    .Select(fl =>
    {
        var sep = fl.IndexOf('-');
        var start = long.Parse(fl[..sep]);
        var end = long.Parse(fl[(sep + 1)..]);

        return new { Start = start, End = end };
    })
    .ToList();

var avaiable = split[1].Split('\n').Select(long.Parse);

var result = avaiable.Count(a => fresh.Any(fr => a >= fr.Start && a <= fr.End));

Console.WriteLine($"{result}");
