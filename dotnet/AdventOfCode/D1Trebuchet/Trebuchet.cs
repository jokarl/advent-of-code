namespace D1Trebuchet;

public class Trebuchet
{
    public static int Solve(string[] args)
    {
        return args
            .Select(arg => arg.Where(char.IsDigit).ToArray())
            .Where(digits => digits.Length != 0)
            .Select(digits => int.Parse("" + digits.First() + digits.Last()))
            .Sum();
    }

    private static readonly Dictionary<string, int> Dict = new()
    {
        { "one", 1 },
        { "two", 2 },
        { "three", 3 },
        { "four", 4 },
        { "five", 5 },
        { "six", 6 },
        { "seven", 7 },
        { "eight", 8 },
        { "nine", 9 }
    };

    public static int Solve_part2(string[] args)
    {
        return args
            .Select(Convert)
            .Where(digits => digits.Length != 0)
            .Select(digits => int.Parse("" + digits.First() + digits.Last()))
            .Sum();
    }

    private static char[] Convert(string arg)
    {
        // Create a char array with the same length as the input string
        // Keep the original indexes here, so we can insert the digits at the correct index
        var chars = new char[arg.Length];

        // First find all digits, insert them into the array with the index they were found at
        for (var i = 0; i < arg.Length; i++)
        {
            if (char.IsDigit(arg[i]))
            {
                chars[i] = arg[i];
            }
        }

        // Iterate all valid number strings that we can replace
        foreach (var e in Dict)
        {
            // If the input string does not contain the number string, skip it
            //if (!arg.Contains(e.Key)) continue;

            // Find the first index
            var index = arg.IndexOf(e.Key, StringComparison.Ordinal);
            chars[index] = char.Parse(e.Value.ToString());
            // Use the first index to keep progressing through the string
            for (var i = index; i < arg.Length; i++)
            {
                var next = arg.IndexOf(e.Key, i, StringComparison.Ordinal);
                if (next == -1) continue;
                chars[next] = char.Parse(e.Value.ToString());
            }
        }

        var convert = chars.Where(c => c != '\0').ToArray();
        return convert;
    }
}