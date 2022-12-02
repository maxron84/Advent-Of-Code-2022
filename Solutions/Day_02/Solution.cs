namespace Solutions.Day_02;

public static class Solution
{
    public static int GetWinnerResult(string input) => GetTotalResults(GetConversions(input)).Max();

    private static int[] GetTotalResults(List<Hand> hands)
    {
        int totalOwn = 0, totalOpponent = 0;

        foreach (var hand in hands)
        {
            var handResults = GetHandResults(hand);

            totalOwn += handResults.First();
            totalOpponent += handResults.Last();
        }

        return new[] { totalOwn, totalOpponent };
    }

    private static int[] GetHandResults(Hand hand)
    {
        if (hand.Own == hand.Opponent)
        {
            hand.Own += 3;
            hand.Opponent += 3;

            return new[] { hand.Own, hand.Opponent };
        }

        if ((hand.Own == 1 && hand.Opponent == 3) || (hand.Own == 2 && hand.Opponent == 1) || (hand.Own == 3 && hand.Opponent == 2))
            hand.Own += 6;
        else
            hand.Opponent += 6;

        return new[] { hand.Own, hand.Opponent };
    }

    private static List<Hand> GetConversions(string input)
    {
        var hands = new List<Hand>();

        var matrix = input
            .Split("\n".ToArray())
            .Select(line => line.Split(' ', StringSplitOptions.RemoveEmptyEntries))
            .ToArray();

        for (var i = 0; i < matrix.Length; i++)
        {
            hands.Add(new Hand
            {
                Own = matrix[i].First() == "A" ? /*Rock*/ 1 : matrix[i].First() == "B" ? /*Paper*/ 2 : /*Scissors*/ 3,
                Opponent = matrix[i].Last() == "X" ? /*Rock*/ 1 : matrix[i].Last() == "Y" ? /*Paper*/ 2 : /*Scissors*/ 3
            });
        }

        return hands;
    }
}

internal record Hand
{
    public int Own { get; set; }
    public int Opponent { get; set; }
}
