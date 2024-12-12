// Part 1
IEnumerable<string> input = File.ReadLines("./input.txt");

int index = 0;
List<int> sums = new();
while (index < input.Count())
{
    IEnumerable<string> group = input.Skip(index).TakeWhile(x => x != string.Empty);
    index += group.Count() + 1;
    sums.Add(group.Select(x => int.Parse(x)).Sum());
}
Console.WriteLine(sums.Max());

// Part 2
Console.WriteLine(sums.OrderByDescending(x => x).Take(3).Sum());