namespace Solutions.Day_03;

// FEATURING COMPARISON BETWEEN OWN & CHATGPT SOLUTION ON CLASS LEVEL!

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
// Generated explanation to this optimization:
/*
    In the original code, the GetAllLines method is used to split the input string into lines,
    but this can be done directly in the GetSumOfCommonPriorities method.
    Also, the GetCompartments method is used to split each line into two compartments,
    but this can also be done directly in the GetSumOfCommonPriorities method.
    Finally, the GetCommonPriority method is used to calculate the common priority of the two compartments,
    but this can also be done directly in the GetSumOfCommonPriorities method.
*/

// Refactored the generated class further by giving instructions to satisfy SRP.
// My point had to be made more and more clear 3 times consecutively in the same thread to generate an acceptable outcome like this:
/*
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

            // Use the GetCommonCharacters() method to get the common characters
            // between compartmentOne and compartmentTwo.
            var common = GetCommonCharacters(compartmentOne, compartmentTwo);

            if (common.Any())
            {
                // If there is at least one common character, we can use the 
                // Max() method to get the highest character value.
                var max = common.Max();

                result += CalculatePriority(max);
            }
        }

        return result;
    }

    private static int CalculatePriority(int characterValue)
    {
        // Calculate the priority of the given character value.
        return characterValue > 96 ? characterValue - 96 : characterValue - 38;
    }

    private static IEnumerable<char> GetCommonCharacters(string firstString, string secondString)
    {
        return firstString.Intersect(secondString);
    }
}
*/
// My inputs:
// 0: (Tried to refactor the last optimization before, the following prompts are based on that, but it doesn't really matter, since it did not change anything but a few semantics)
// 1: Please refactor your last refactored output now sensefully by using the single responsibility principle. (Did not refactor every occuring responsibility)
// 2: Please make the first method even more atomic to satisfy SRP. (Method generated but not used)
// 3: Please use the last method in the first method. (Generated method now actually used & SRP satisfied)
