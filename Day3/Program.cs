// Part 1
IEnumerable<string> input = File.ReadLines("./input.txt");

int sum = 0;
IEnumerable<(string, string)> packs = input.Select(x => (x[..(x.Length / 2)], x[(x.Length / 2)..]));
foreach ((string, string) pack in packs)
{
    IEnumerable<char> matches = pack.Item1.Intersect(pack.Item2);
    sum += matches.Sum(x => x < 97 ? x % 32 + 26 : x % 32);
}
Console.WriteLine(sum);

// Part 2
int sum2 = 0;
IEnumerable<string[]> groups = input.Chunk(3);
foreach(string[] group in groups)
{
    char intersection = group.Skip(1).Aggregate(new HashSet<char>(group.First()), (a, b) =>
    {
        a.IntersectWith(b);
        return a;
    }).Single();
    sum2 += intersection < 97 ? intersection % 32 + 26 : intersection % 32;
}

Console.WriteLine(sum2);