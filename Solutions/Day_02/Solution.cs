namespace Solutions.Day_02;

public static class Solution
{
    public static int GetWinnerResult(string input)
    {
        var result = GetTotalResults(GetConversions(input));

        return Int32.Max(result.Item1, result.Item2);
    }

    private static Tuple<int, int> GetTotalResults(List<Tuple<int, int>> hands)
    {
        int totalOwn = 0, totalOpponent = 0;

        foreach (var hand in hands)
        {
            var handResults = GetHandResults(hand);

            totalOwn += handResults.Item1;
            totalOpponent += handResults.Item2;
        }

        return Tuple.Create<int, int>(totalOwn, totalOpponent);
    }

    private static Tuple<int, int> GetHandResults(Tuple<int, int> hand)
    {
        int own = hand.Item1, opponent = hand.Item2, difference = own - opponent;

        if (difference == 0)
        {
            own += 3;
            opponent += 3;

            return Tuple.Create<int, int>(own, opponent);
        }

        _ = difference == -2 || difference == 1 ? own += 6 : opponent += 6;

        return Tuple.Create<int, int>(own, opponent);
    }

    private static List<Tuple<int, int>> GetConversions(string input)
    {
        var hands = new List<Tuple<int, int>>();

        var matrix = input
            .Split(Environment.NewLine).ToArray()
                .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
                .ToArray();

        for (var i = 0; i < matrix.Length; i++)
        {
            hands.Add(Tuple.Create<int, int>
            (
                matrix[i].First() == "A" ? /*Rock*/ 1 : matrix[i].First() == "B" ? /*Paper*/ 2 : /*Scissors*/ 3,
                matrix[i].Last() == "X" ? /*Rock*/ 1 : matrix[i].Last() == "Y" ? /*Paper*/ 2 : /*Scissors*/ 3
            ));
        }

        return hands;
    }
}
