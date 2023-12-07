using System.Text.RegularExpressions;
using D1Trebuchet;
using D3GearRatios;

namespace Tests;

public class GearRatiosTests
{
    private const int ExpectedResult = 559667;
    private const int KeyExpectedResult = 4361;

    [Fact]
    public void Solve()
    {
        var input = File.ReadLines("Data/GearRatios.txt").ToArray();
        var result = GearRatios.Solve(input);
        Assert.Equal(ExpectedResult, result);
    }

    [Fact]
    public void Solve_key()
    {
        var input = File.ReadLines("Data/GearRatios.Key.txt").ToArray();
        var result = GearRatios.Solve(input);
        Assert.Equal(KeyExpectedResult, result);
    }

    [Fact]
    public void Number_pattern()
    {
        const string input =
            "...766.......821.547.....577......................................387.....................56..........446.793..........292..................";
        var pattern = @"(\d+)";

        foreach (Match match in Regex.Matches(input, pattern))
        {
            Assert.IsType<int>(int.Parse(match.Value));
        }
    }

    [Fact]
    public void Symbol_pattern()
    {
        const string input =
            @"............""...............%...../.....981..........627..../..........-.....623......610..-..............*..................16......891.....";
        const string pattern = @"(?:[-!$%^&*()_+#|~=`@{}\[\]:"";'<>?,\/])";

        var matches = Regex.Matches(input, pattern);

        Assert.Equal(7, matches.Count);
    }

    [Fact]
    public void Merge_pattern()
    {
        const string input =
            @"............""...............%...../.....981..........627..../..........-.....623......610..-..............*..................16......891.....";
        const string pattern = @"(?:\d+)|(?:[-!$%^&*()_+#|~=`@{}\[\]:"";'<>?,\/])";

        foreach (Match match in Regex.Matches(input, pattern))
        {
            var groups = match.Groups;
            var groupZeroSuccess = match.Groups[0].Success;
            var groupOneSuccess = match.Groups[1].Success;
        }
    }
}