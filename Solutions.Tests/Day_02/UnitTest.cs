namespace Solutions.Tests.Day_02;

public class UnitTest
{
    [Theory]
    [MemberData(nameof(GetTestData))]
    public Task Can_GetWinnerResult(string input, int expected)
    {
        // Given is MemberData

        // When
        var actual = Solutions.Day_02.Solution.GetWinnerResult(input);

        // Then
        Assert.Equal(expected, actual);

        return Task.CompletedTask;
    }

    public static IEnumerable<object[]> GetTestData()
    {
        // Case 1 from example
        var input = """
            A Y
            B X
            C Z
            """;
        var expected = 15;

        yield return new object[] { input, expected };

        // Case 2 single hand
        input = """
            A Y
            """;
        expected = 8;

        yield return new object[] { input, expected };

        // Case 3 only draws
        input = """
            A X
            B Y
            C Z
            """;
        expected = 15;

        yield return new object[] { input, expected };
    }
}
