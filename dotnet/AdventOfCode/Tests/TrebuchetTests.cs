using System.Text.RegularExpressions;
using D1Trebuchet;

namespace Tests;

public class TrebuchetTests
{
    private const int ExpectedResult = 54304;
    private const int ExpectedResultPart2 = 54418;

    [Fact]
    public void Solve()
    {
        var input = File.ReadLines("Data/Trebuchet.txt").ToArray();
        var result = Trebuchet.Solve(input);
        Assert.Equal(ExpectedResult, result);
    }
    
    [Fact]
    public void Solve_part2()
    {
        var input = File.ReadLines("Data/Trebuchet.txt").ToArray();
        var result = Trebuchet.Solve_part2(input);
        Assert.Equal(ExpectedResultPart2, result);
    }

    [Fact]
    public void Part2_regex()
    {
        const string input = "sgeightwo3";
        const string regex = @"(?:\d+)|(?=one)|(?=eight)";

        var matches = Regex.Matches(input, regex);
    }
}