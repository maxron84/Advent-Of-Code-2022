namespace Solutions.Day_06;

public static class Solution
{
    private static StringBuilder _stringBuilder = new();

    public static int GetPositionOfCharacterAfterFirstMarker(string input, int subpartLength)
    {
        var index = subpartLength - 1;

        for (var i = index; i < input.Length - 1; i++)
        {
            _stringBuilder.Clear();

            for (var j = i - index; j <= i; j++)
                _stringBuilder.Append(input[j]);

            var substringNegative = _stringBuilder.ToString();

            if (substringNegative.Distinct().Count() == substringNegative.Length)
                return i + 1;
        }

        return -1;
    }
}
