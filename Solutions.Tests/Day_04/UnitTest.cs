namespace Solutions.Tests.Day_04;

public class UnitTest
{
    [Theory]
    [MemberData(nameof(GetTestData))]
    public Task Can_GetMatchCount(string input, int expected)
    {
        // Given is MemberData

        int actual = Solutions.Day_04.Solution.GetMatchCount(input);

        // Then
        Assert.Equal(expected, actual);

        return Task.CompletedTask;
    }

    public static IEnumerable<object[]> GetTestData()
    {
        // Case 1 from example
        var input = """
        2-4,6-8
        2-3,4-5
        5-7,7-9
        2-8,3-7
        6-6,4-6
        2-6,4-8
        """;
        var expected = 2;

        yield return new object[] { input, expected };

        // Case 2 from example but modified
        input = """
        1-9,2-8
        3-6,4-5
        5-8,6-7
        1-2,2-3
        """;
        expected = 3;

        yield return new object[] { input, expected };
    }
}
