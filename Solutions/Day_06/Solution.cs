namespace Solutions.Day_06;

// FEATURING COMPARISON BETWEEN OWN & CHATGPT SOLUTION!
public static class Solution
{
    // Solution out of my head, complexity O(n²)
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

    // Solution generated with ChatGPT using the following chat input, complexity is O(n)
    //Please create a method in C# which receives a large string containing random characters and a desired substring length as parameter.
    //Get the first occurance of a substring of the input string containing only distinct characters.
    //Return the position of the character right after the matching substring as an integer.
    public static int GetPositionOfCharacterAfterFirstMarker_ChatGPT(string input, int substringLength)
    {
        for (int i = 0; i < input.Length - substringLength + 1; i++)
        {
            string currentSubstring = input.Substring(i, substringLength);

            if (currentSubstring.Distinct().Count() == substringLength)
                return i + substringLength;
        }

        return -1;
    }
}
