using System.Text.RegularExpressions;

namespace D4Scratchcards;

public partial class Scratchcards
{
    public static int Solve(string[] args)
    {
        var totalScore = 0;
        
        var cardRegex = CardRegex();
        var numberRegex = NumberRegex();
        
        for (var i = 0; i < args.Length; i++)
        {
            var points = 0;
            var matches = cardRegex.Matches(args[i]);
            
            var winningNumbers = numberRegex.Matches(matches[0].Groups[1].Value).Select(m => int.Parse(m.Value)).ToArray();
            var myNumbers = numberRegex.Matches(matches[0].Groups[2].Value).Select(m => int.Parse(m.Value)).ToArray();

            for (var n = 0; n < myNumbers.Length; n++)
            {
                if (!winningNumbers.Contains(myNumbers[n])) continue;
                points = points == 0 ? 1 : points * 2;
            }

            totalScore += points;
        }

        return totalScore;
    }

    [GeneratedRegex(@"(?<=:)\s*(\d+(?:\s+\d+)*)\s*\|\s*(\d+(?:\s+\d+)*)")]
    private static partial Regex CardRegex();
    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberRegex();
}