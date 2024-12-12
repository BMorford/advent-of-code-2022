// Part 1
IEnumerable<(string, string)> input = File.ReadLines("./input.txt").Select(x =>
{
    string[] parts = x.Split(",");
    return (parts[0], parts[1]);
});

int fullOverlapCount = 0;
foreach((string, string) line in input)
{
    List<int> parts1 = line.Item1
        .Split("-")
        .Select(x => int.Parse(x))
        .ToList();
    List<int> parts2 = line.Item2
        .Split("-")
        .Select(x => int.Parse(x))
        .ToList();

    HashSet<int> range1 = Enumerable.Range(parts1[0], parts1[1] - parts1[0] + 1).ToHashSet();
    HashSet<int> range2 = Enumerable.Range(parts2[0], parts2[1] - parts2[0] + 1).ToHashSet();

    HashSet<int> overlap = range1.Intersect(range2).ToHashSet();

    if (overlap.SetEquals(range1) || overlap.SetEquals(range2))
    {
        fullOverlapCount++;
    }
}
Console.WriteLine(fullOverlapCount);

// Part 2
int overlapCount = 0;
foreach ((string, string) line in input)
{
    List<int> parts1 = line.Item1
        .Split("-")
        .Select(x => int.Parse(x))
        .ToList();
    List<int> parts2 = line.Item2
        .Split("-")
        .Select(x => int.Parse(x))
        .ToList();

    if (parts1[0] <= parts2[1] && parts2[0] <= parts1[1])
    {
        overlapCount++;
    }
}
Console.WriteLine(overlapCount);
