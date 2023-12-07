using System.Text.RegularExpressions;
using D4Scratchcards;

namespace Tests;

public class ScratchcardsTests
{
    private const int KeyExpectedResult = 24848;
    
    [Fact]
    public void Solve()
    {
        var input = File.ReadLines("Data/Scratchcards.txt").ToArray();
        var result = Scratchcards.Solve(input);
        Assert.Equal(KeyExpectedResult, result);
    }

    [Fact]
    public void Solve_key()
    {
        var input = File.ReadLines("Data/Scratchcards.Key.txt").ToArray();
        var result = Scratchcards.Solve(input);
        Assert.Equal(KeyExpectedResult, result);
    }

    [Fact]
    public void Regex_input()
    {
        var input = "Card   1: 13  4 61 82 80 41 31 53 50  2 | 38 89 26 79 94 50  2 74 31 92 80 41 13 97 61 82 68 45 64 39  4 53 90 84 54";
        var pattern = @"(?<=:)\s*(\d+(?:\s+\d+)*)\s*\|\s*(\d+(?:\s+\d+)*)";
        var matches = Regex.Matches(input, pattern);

        matches[0].Groups[1].Value.Should().Be("13  4 61 82 80 41 31 53 50  2");
        matches[0].Groups[2].Value.Should().Be("38 89 26 79 94 50  2 74 31 92 80 41 13 97 61 82 68 45 64 39  4 53 90 84 54");
    }

    [Fact]
    public void Regex_number()
    {
        var input = "41 48 83 86 17";
        var pattern = @"\d+";

        var matches = Regex.Matches(input, pattern);

        matches.Select(m => int.Parse(m.Value)).Should().ContainInOrder(41, 48, 83, 86, 17);
    }
}