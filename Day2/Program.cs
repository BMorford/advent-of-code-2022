// Part 1
IEnumerable<(string, string)> input = File.ReadLines("./input.txt")
    .Select(x =>
    {
        string[] parts = x.Split(" ");
        return (parts[0], parts[1]);
    });

static int GetScore((string, string) line) {
    int score = 0;
    score += line switch
    {
        ("A", "X") => 3,
        ("A", "Y") => 6,
        ("A", "Z") => 0,
        ("B", "X") => 0,
        ("B", "Y") => 3,
        ("B", "Z") => 6,
        ("C", "X") => 6,
        ("C", "Y") => 0,
        ("C", "Z") => 3,
        _ => throw new InvalidDataException()
    };

    score += line.Item2 switch
    {
        "X" => 1,
        "Y" => 2,
        "Z" => 3,
        _ => throw new InvalidDataException()
    };
    
    return score;
}

Console.WriteLine(input.Sum(x => GetScore(x)));


// Part 2
static string GetPlay((string, string) line)
{
    return line switch
    {
        ("A", "X") => "Z",
        ("A", "Y") => "X",
        ("A", "Z") => "Y",
        ("B", "X") => "X",
        ("B", "Y") => "Y",
        ("B", "Z") => "Z",
        ("C", "X") => "Y",
        ("C", "Y") => "Z",
        ("C", "Z") => "X",
        _ => throw new InvalidDataException()
    };
}

Console.WriteLine(input.Sum(x => GetScore((x.Item1, GetPlay(x)))));