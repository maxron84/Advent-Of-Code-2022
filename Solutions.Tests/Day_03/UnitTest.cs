namespace Solutions.Tests.Day_03;

public class UnitTest
{
    [Theory]
    [MemberData(nameof(GetTestData))]
    public Task Can_GetSumOfCommonPriorities(string input, int expected)
    {
        // Given is MemberData

        // When
        var actual = Solutions.Day_03.Solution.GetSumOfCommonPriorities(input);

        // Then
        Assert.Equal(expected, actual);

        return Task.CompletedTask;
    }

    public static IEnumerable<object[]> GetTestData()
    {
        // Case 1 from example
        var input = """
            vJrwpWtwJgWrhcsFMMfFFhFp
            jqHRNqRjqzjGDLGLrsFMfFZSrLrFZsSL
            PmmdzqPrVvPwwTWBwg
            wMqvLMZHhHMvwLHjbvcjnnSBnvTQFn
            ttgJtRGJQctTZtZT
            CrZsJsPPZsGzwwsLwLmpwMDw
        """;
        var expected = 157;

        yield return new object[] { input, expected };
    }
}
