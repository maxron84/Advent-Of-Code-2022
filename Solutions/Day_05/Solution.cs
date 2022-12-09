namespace Solutions.Day_05;

public static class Solution
{
    private static StringBuilder _stringBuilder = new();
    private static List<Stack<string>> _crateStacks = new();
    private static List<List<int>> _codesForProcedures = new();

    public static string GetAllTopCrates(string input)
    {
        if (input.Contains("\r\n"))
            input = input.Replace("\r\n", TerminationBearer.NEWLINEHARDCODED);

        var dataParts = GetDataParts(input, TerminationBearer.EMPTYLINEHARDCODED);

        _crateStacks = GetAllCrateStacks(dataParts.First());
        _codesForProcedures = GetCodesForAllProcedures(dataParts.Last());

        foreach (var code in _codesForProcedures)
            DoMoveCrates(_crateStacks, code);

        foreach (var crateStack in _crateStacks)
            _stringBuilder.Append(crateStack.First());

        return _stringBuilder.ToString();
    }

    private static Task DoMoveCrates(IEnumerable<Stack<string>> crates, IEnumerable<int> code)
    {
        int amount = code.ElementAt(0), source = code.ElementAt(1) - 1, destination = code.ElementAt(2) - 1;

        for (var i = 0; i < amount; i++)
        {
            crates.ElementAt(destination).Push(crates.ElementAt(source).Peek());
            crates.ElementAt(source).Pop();
        }

        return Task.CompletedTask;
    }

    private static List<string> GetDataParts(string input, string separator) => input.Split(separator).ToList();

    private static List<Stack<string>> GetAllCrateStacks(string dataPart)
    {
        var result = new List<Stack<string>>();
        var lines = dataPart.Split(TerminationBearer.NEWLINEHARDCODED).ToArray();

        Array.Reverse(lines);

        var formatMatrix = GetFormattedLines(lines)
            .Select(formatLine => formatLine.Split("_"))
            .ToList();

        for (var i = 0; i < formatMatrix.Count() - 1; i++)
        {
            var stack = new Stack<string>();

            foreach (var line in formatMatrix)
                if (!string.IsNullOrEmpty(line[i]))
                    stack.Push(line[i]);

            result.Add(stack);
        }

        return result;
    }

    public static List<string> GetFormattedLines(IEnumerable<string> lines)
    {
        var result = new List<string>();

        foreach (var line in lines)
        {
            var formatLine = Regex.Replace(line, @"[^A-Za-z0-9 -]", ""); // All: Remove any non-alphanumeric characters
            formatLine = Regex.Replace(formatLine, @"\s+", "_"); // All: Replace whitespace near remaining characters with _ and remove the rest

            if (line == lines.First())
                formatLine = formatLine.Substring(1, formatLine.Length - 2); // First: Remove leading and trailing whitespaces

            result.Add(formatLine);
        }

        return result;
    }

    private static List<List<int>> GetCodesForAllProcedures(string dataPart)
    {
        var result = new List<List<int>>();

        var lines = dataPart.Split(TerminationBearer.NEWLINEHARDCODED.ToArray());

        foreach (var line in lines)
        {
            var candidates = line.Split(" ");
            var codes = new List<int>();

            for (var i = 1; i < candidates.Length; i++)
                if (i % 2 != 0)
                    codes.Add(Int32.Parse(candidates[i]));

            result.Add(codes);
        }

        return result;
    }
}
