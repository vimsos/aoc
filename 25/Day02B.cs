static IEnumerable<string> LongYield(long start, long end)
{
    for (var i = start; i <= end; i++)
        yield return i.ToString();
}

var input = File.ReadAllText("input/day02.txt");
var result = input
    .Split(',')
    .SelectMany(r =>
    {
        var separatorIndex = r.IndexOf('-');
        var start = long.Parse(r[..separatorIndex]);
        var end = long.Parse(r[(separatorIndex + 1)..]);

        return LongYield(start, end);
    })
    .Where(id =>
    {
        var id2 = $"{id[1..]}{id[..^1]}";

        return id2.Contains(id);
    })
    .Sum(long.Parse);

Console.WriteLine($"{result}");
