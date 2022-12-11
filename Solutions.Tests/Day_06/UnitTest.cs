namespace Solutions.Tests.Day_06;

public class UnitTest
{
    [Theory]
    [MemberData(nameof(GetTestData))]
    public Task Can_GetPositionOfCharacterAfterFirstMarker(string input, int subpartLength, int expected)
    {
        // Given is MemberData

        // When
        var actual = Solutions.Day_06.Solution.GetPositionOfCharacterAfterFirstMarker(input, subpartLength); // Own solution
        // Then
        Assert.Equal(expected, actual);

        // When
        actual = Solutions.Day_06.Solution.GetPositionOfCharacterAfterFirstMarker_ChatGPT(input, subpartLength); // ChatGPT solution
        // Then
        Assert.Equal(expected, actual);

        return Task.CompletedTask;
    }

    public static IEnumerable<object[]> GetTestData()
    {
        var subpartLength = 4;

        // Case 1 from example 1
        var input = "mjqjpqmgbljsphdztnvjfqwrcgsmlb";
        var expected = 7;

        yield return new object[] { input, subpartLength, expected };

        // Case 2 from example 2
        input = "bvwbjplbgvbhsrlpgdmjqwftvncz";
        expected = 5;

        yield return new object[] { input, subpartLength, expected };

        // Case 3 from example 3
        input = "nppdvjthqldpwncqszvftbrmjlhg";
        expected = 6;

        yield return new object[] { input, subpartLength, expected };

        // Case 4 from example 4
        input = "nznrnfrfntjfmvfwmzdfjlvtqnbhcprsg";
        expected = 10;

        yield return new object[] { input, subpartLength, expected };

        // Case 5 from example 5
        input = "zcfzfwzzqfrljwzlrfnpqdbhtmscgvjw";
        expected = 11;

        yield return new object[] { input, subpartLength, expected };
    }

    [Theory]
    [MemberData(nameof(GetTestData_FromFiles))]
    public Task Can_GetPositionOfCharacterAfterFirstMarker_FromFiles(string input, int subpartLength)
    {
        // Given is MemberData

        // When
        var actual = Solutions.Day_06.Solution.GetPositionOfCharacterAfterFirstMarker(input, subpartLength);
        actual = Solutions.Day_06.Solution.GetPositionOfCharacterAfterFirstMarker_ChatGPT(input, subpartLength); // ChatGPT matches the outcome of my solution!

        // Then
        // Save returnvalues for comparison with dataprovider here...
        // 1: 1920
        // 2: 2334

        return Task.CompletedTask;
    }

    public static IEnumerable<object[]> GetTestData_FromFiles()
    {
        var input = File.ReadAllText(@".\Day_06\Input.txt");

        // Case 1 from part one of puzzle
        var subpartLength = 4;

        yield return new object[] { input, subpartLength };

        // Case 2 from part two of puzzle
        subpartLength = 14;

        yield return new object[] { input, subpartLength };
    }
}
