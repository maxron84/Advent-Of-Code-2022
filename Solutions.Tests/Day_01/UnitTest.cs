namespace Solutions.Tests.Day_01;

public class UnitTest
{
    [Theory]
    [MemberData(nameof(GetTestData))]
    public Task Can_GetBiggestInventory(string input, int expected)
    {
        // Given is MemberData

        // When
        int actual = Solutions.Day_01.Solution.GetResult(input);

        // Then
        Assert.Equal(expected, actual);

        return Task.CompletedTask;
    }

    public static IEnumerable<object[]> GetTestData()
    {
        var givenInput = """
            1000
            2000
            3000

            4000

            5000
            6000

            7000
            8000
            9000

            10000
            """;
        var expectedResult = 24_000;

        yield return new object[] { givenInput, expectedResult };
    }
}
