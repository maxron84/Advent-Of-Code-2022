namespace Solutions.Tests.Day_05;

public class UnitTest
{
    [Theory]
    [MemberData(nameof(GetTestData))]
    public Task Can_GetAllTopCrates(string input, string expected)
    {
        // Given is MemberData

        // When
        var actual = Solutions.Day_05.Solution.GetAllTopCrates(input);
        // Then
        Assert.Equal(expected, actual);

        return Task.CompletedTask;
    }

    public static IEnumerable<object[]> GetTestData()
    {
        // Case 1 from example
        var input = """
                [D]    
            [N] [C]    
            [Z] [M] [P]
             1   2   3 

            move 1 from 2 to 1
            move 3 from 1 to 3
            move 2 from 2 to 1
            move 1 from 1 to 2
            """;
        var expected = "CMZ";

        yield return new object[] { input, expected };
    }
}
