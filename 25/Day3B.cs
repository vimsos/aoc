var banks = File.ReadAllLines("input/day03.txt");

const int BATTERY_COUNT = 12;

var result = banks.Sum(b =>
{
    var ordered = b.Select((j, i) => new { Jolt = int.Parse(j.ToString()), Position = i })
        .OrderByDescending(jp => jp.Jolt)
        .ThenBy(jp => jp.Position)
        .ToList();

    long jolt = 0;
    var position = BATTERY_COUNT;
    var digit = new { Jolt = 0, Position = -1 };

    while (position > 0)
    {
        digit = ordered.First(jp =>
            jp.Position > digit.Position && jp.Position < b.Length - position + 1
        );
        jolt = jolt * 10 + digit.Jolt;
        position--;
    }

    return jolt;
});

Console.WriteLine($"{result}");
