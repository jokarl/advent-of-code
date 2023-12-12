using System.Text.RegularExpressions;
using D2CubeConundrum;

namespace Tests;

public class CubeConundrumTests
{
    private const int ExpectedResult = 2720;
    private const int ExpectedResultPart2 = 71535;

    [Fact]
    public void Solve()
    {
        var input = File.ReadLines("Data/CubeConundrum.txt").ToArray();
        var result = CubeConundrum.Solve(input);
        Assert.Equal(ExpectedResult, result);
    }

    [Fact]
    public void Solve_part2()
    {
        var input = File.ReadLines("Data/CubeConundrum.txt").ToArray();
        var result = CubeConundrum.Solve_part2(input);
        Assert.Equal(ExpectedResultPart2, result);
    }

    [Fact]
    public void Asdf()
    {
        var input = "Game 1: 1 red, 5 blue, 10 green; 5 green, 6 blue, 12 red; 4 red, 10 blue, 4 green";
        var pattern = @"\b(?<number>\d+)\s(?<color>red|blue|green)\b";
        foreach (Match match in Regex.Matches(input, pattern))
        {
            var number = match.Groups["number"].Value;
            var color = match.Groups["color"].Value;
            Console.WriteLine($"Number: {number}, Color: {color}");
        }
    }
}