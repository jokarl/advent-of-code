using System.Text.RegularExpressions;

namespace D2CubeConundrum;

public partial class CubeConundrum
{
    private static readonly Dictionary<string, int> MaxColors = new()
    {
        { "red", 12 },
        { "green", 13 },
        { "blue", 14 }
    };
    
    public static int Solve(string[] args)
    {
        var gameSum = 0;
        var pattern = MyRegex();
        Parallel.ForEach(args, arg =>
        {
            var isGamePossible = true;
            foreach (Match match in pattern.Matches(arg))
            {
                var number = int.Parse(match.Groups["number"].Value);
                var color = match.Groups["color"].Value;
                if (number > MaxColors[color])
                {
                    isGamePossible = false;
                    break;
                };
            }

            if (isGamePossible) Interlocked.Add(ref gameSum, Convert.ToInt32(arg.Substring(5, arg.IndexOf(':') - 5)));
        });

        return gameSum;
    }

    [GeneratedRegex(@"\b(?<number>\d+)\s(?<color>red|blue|green)\b", RegexOptions.Compiled)]
    private static partial Regex MyRegex();
}