var banks = File.ReadAllLines("input/day03.txt");
var result = banks.Sum(b =>
{
    var ordered = b.Select((j, i) => new { Jolt = int.Parse(j.ToString()), Position = i })
        .OrderByDescending(jp => jp.Jolt)
        .ThenBy(jp => jp.Position);

    var firstDigit = ordered.First(jp => jp.Position < b.Length - 1);
    var secondDigit = ordered.First(jp => jp.Position > firstDigit.Position);

    var jolt = firstDigit.Jolt * 10 + secondDigit.Jolt;
    return jolt;
});

Console.WriteLine($"{result}");
