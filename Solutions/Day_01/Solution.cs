namespace Solutions.Day_01;

public static class Solution
{
    public static int GetResult(string input) => GetBiggest(GetConversion(input));

    private static int GetBiggest(List<List<int>> listOfInventories)
    {
        var candidate = 0;
        var results = new LinkedList<int>();

        for (var i = 0; i < listOfInventories.Count; i++)
        {
            candidate = 0;

            if (listOfInventories[i] != null)
                for (var j = 0; j < listOfInventories[i]!.Count; j++)
                    candidate += listOfInventories[i]![j];

            results.AddLast(new LinkedListNode<int>(candidate));
        }

        return results.OrderByDescending(x => x).First();
    }

    private static List<List<int>> GetConversion(string input)
    {
        var lines = input.Split("\n", StringSplitOptions.TrimEntries);

        var inventories = new List<List<int>>();
        var lastIndex = 0;

        while (lastIndex < lines.Length)
        {
            inventories.Add(new List<int>());

            for (int i = lastIndex; i < lines.Length; i++)
            {
                lastIndex++;

                if (string.IsNullOrEmpty(lines[i]) || string.IsNullOrWhiteSpace(lines[i]))
                    break;

                inventories[inventories.IndexOf(inventories.Last())].Add(Convert.ToInt32(lines[i]));
            }
        }

        return inventories;
    }
}
