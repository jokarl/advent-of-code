using System.Text.RegularExpressions;
using D1Trebuchet;

namespace Tests;

public class TrebuchetTests
{
    private const int ExpectedResult = 54304;

    [Fact]
    public void Linq()
    {
        var input = File.ReadLines("Data/Trebuchet.txt").ToArray();
        var result = Trebuchet.Linq(input);
        Assert.Equal(ExpectedResult, result);
    }
}