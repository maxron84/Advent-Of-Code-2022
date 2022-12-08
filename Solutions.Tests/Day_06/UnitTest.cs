namespace Solutions.Tests.Day_06;

public class UnitTest
{
    [Theory]
    [MemberData(nameof(GetTestData))]
    public Task TestName()
    {
        // Given is MemberData

        // When

        // Then

        return Task.CompletedTask;
    }

    public static IEnumerable<object[]> GetTestData()
    {
        // Case 1 from example

        yield return new object[] { };
    }
}
