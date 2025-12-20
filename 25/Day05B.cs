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

while (fresh.Count > 1)
{
    var merged = false;
    for (var i = 0; i < fresh.Count; i++)
    for (var j = 0; j < fresh.Count; j++)
    {
        if (i == j)
            continue;

        var a = fresh[i];
        var b = fresh[j];

        var overlap = a.Start >= b.Start && a.Start <= b.End || a.End >= b.Start && a.End <= b.End;

        if (overlap)
        {
            fresh.Remove(a);
            fresh.Remove(b);
            fresh.Add(new { Start = long.Min(a.Start, b.Start), End = long.Max(a.End, b.End) });
            i = j = 0;
            merged = true;
        }
    }

    if (!merged)
        break;
}

var result = fresh.Sum(fr => fr.End - fr.Start + 1);

Console.WriteLine($"{result}");
