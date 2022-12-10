namespace Solutions.Day_04;

public static class Solution
{
    public static int GetMatchCount(string input)
    {
        var matchCount = 0;
        var rangesCollection = GetConversions(input);

        foreach (var ranges in rangesCollection)
            if (IsOneCompletelyWithinOther(ranges))
                matchCount++;

        return matchCount;
    }

    private static bool IsOneCompletelyWithinOther(Tuple<List<int>, List<int>> ranges)
    {
        var left = Enumerable.Range(ranges.Item1.First(), ranges.Item1.Count());
        var right = Enumerable.Range(ranges.Item2.First(), ranges.Item2.Count());

        return GetCountOfWithins(left, right) == right.Count() || (GetCountOfWithins(right, left) == left.Count());
    }

    private static int GetCountOfWithins(IEnumerable<int> container, IEnumerable<int> range)
    {
        var counter = 0;

        foreach (var item in range)
            if (container.Contains(item))
                counter++;

        return counter;
    }

    private static List<Tuple<List<int>, List<int>>> GetConversions(string input)
    {
        var opponentsCollection = new List<Tuple<List<int>, List<int>>>();

        var matrix = input
            .Split(Environment.NewLine).ToArray()
                .Select(line => line.Split(',', StringSplitOptions.TrimEntries))
                .ToArray();

        for (var i = 0; i < matrix.Length; i++)
        {
            List<int>? left = null;
            List<int>? right = null;

            var pair = matrix[i];

            while (left is null && right is null)
            {
                foreach (var range in pair)
                {
                    var start = Convert.ToInt32(Char.GetNumericValue(range.First()));
                    var count = Convert.ToInt32(Char.GetNumericValue(range.Last()) - (start - 1));

                    var digits = new List<int>(Enumerable.Range(start, count));

                    _ = left is null ? left = digits : right = digits;
                }
            }

            opponentsCollection.Add(Tuple.Create<List<int>, List<int>>(left!, right!));
        }

        return opponentsCollection;
    }
}
