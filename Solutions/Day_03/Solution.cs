namespace Solutions.Day_03;

// Solution out of my head
public static class Solution
{
    public static int GetSumOfCommonPriorities(string input)
    {
        var result = 0;
        var lines = GetAllLines(input);

        foreach (var line in lines)
            result += GetCommonPriority(GetCompartments(line));

        return result;
    }

    private static List<string> GetAllLines(string input) => input.Split(Environment.NewLine, StringSplitOptions.TrimEntries).ToList();

    private static Tuple<string, string> GetCompartments(string line)
    {
        var compartmentOne = line.Substring(0, line.Length / 2);
        var compartmentTwo = line.Substring(line.Length / 2, line.Length / 2);

        return Tuple.Create<string, string>(compartmentOne, compartmentTwo);
    }

    private static int GetCommonPriority(Tuple<string, string> compartments)
    {
        int priority = compartments.Item1.Intersect(compartments.Item2).FirstOrDefault();

        return priority > 96 ? priority - 96 : priority - 38;
    }
}

// Solution as optimized on classlevel by ChatGPT using the following chat input:
/*
    "Please optimize the following class in C#: _inserted class above this comment_"
*/
public static class Solution_ChatGPT
{
    public static int GetSumOfCommonPriorities(string input)
    {
        var lines = input.Split(Environment.NewLine, StringSplitOptions.TrimEntries);
        var result = 0;

        foreach (var line in lines)
        {
            var compartmentOne = line.Substring(0, line.Length / 2);
            var compartmentTwo = line.Substring(line.Length / 2, line.Length / 2);

            var common = compartmentOne.Intersect(compartmentTwo).FirstOrDefault();

            result += common > 96 ? common - 96 : common - 38;
        }

        return result;
    }
}
