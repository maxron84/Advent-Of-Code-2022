namespace Solutions.Day_03;

public static class Solution
{
    private static StringBuilder sb = new StringBuilder();

    public static int GetSum(string input)
    {
        var result = 0;
        var lines = GetAllLines(input);

        foreach (var line in lines)
            result += GetCommonPriority(GetCompartments(line));

        return result;
    }

    private static List<string> GetAllLines(string input) => input.Split("\n", StringSplitOptions.TrimEntries).ToList();

    private static Tuple<char[], char[]> GetCompartments(string line)
    {
        var compartmentOne = line.Substring(0, line.Length / 2).Trim().ToCharArray();
        var compartmentTwo = line.Substring(line.Length / 2, line.Length / 2).Trim().ToCharArray();

        return Tuple.Create<char[], char[]>(compartmentOne, compartmentTwo);
    }

    private static int GetCommonPriority(Tuple<char[], char[]> opponents)
    {
        int priority = opponents.Item1.Intersect(opponents.Item2).FirstOrDefault();

        return priority >= 96 ? priority - 96 : priority - 38;
    }
}