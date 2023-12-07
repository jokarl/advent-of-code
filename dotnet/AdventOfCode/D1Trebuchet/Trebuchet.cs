namespace D1Trebuchet;

public class Trebuchet
{
    public static int Linq(string[] args)
    {
        return args
            .Select(arg => arg.Where(char.IsDigit).ToArray())
            .Where(digits => digits.Length != 0)
            .Select(digits => int.Parse("" + digits.First() + digits.Last()))
            .Sum();
    }
}