using System.Text.RegularExpressions;

namespace D3GearRatios;

public class GearRatios
{
    public static int Solve(string[] args)
    {
        // Create a two-dimensional jagged array for the numbers
        var numberGrid = new int[args.Length, args[0].Length];
        // Create a two-dimensional jagged array for the symbols
        var symbolIndexes = new Dictionary<int, List<int>>();

        var numberPattern = @"(\d+)";
        var symbolPattern = @"(?:[-!$%^&*()_+#|~=`@{}\[\]:"";'<>?,\/])";
        for (var y = 0; y < args.Length; y++)
        {
            foreach (Match m in Regex.Matches(args[y], numberPattern))
            {
                // First index is the row, second index is the column
                // Each index is a number, and if a cell has non-zero value, it is a potential part number
                for (var x = m.Index; x < m.Index + m.Length; x++) numberGrid[y, x] = int.Parse(m.Value);
            }

            foreach (Match m in Regex.Matches(args[y], symbolPattern))
            {
                // Keep track of all symbols and their indexes
                // The key is the row, and the list of values are the indexes of the symbols
                if (!symbolIndexes.TryGetValue(y, out var value)) symbolIndexes.Add(y, new List<int> { m.Index });
                else value.Add(m.Index);
            }
        }

        // Iterate through the number grid and symbol indexes
        var validPartsSum = 0;
        for (var y = 0; y < args.Length; y++)
        {
            if (!symbolIndexes.ContainsKey(y)) continue;
            for (var x = 0; x < symbolIndexes[y].Count; x++)
            {
                // For each row, iterate through the symbol indexes
                var index = symbolIndexes[y][x];

                // Rotate around the symbol, checking for numbers
                for (var iy = -1; iy <= 1; iy++)
                {
                    // Keep track of the numbers found in this rotation
                    // If a number is both diagonal and horizontal/vertical, it will be counted twice
                    var foundThisRotation = new HashSet<int>();
                    for (var ix = -1; ix <= 1; ix++)
                    {
                        var xCoord = index + ix;
                        var yCoord = y + iy;
                        Console.WriteLine($"Checking for number at {yCoord}, {xCoord}");
                        if (numberGrid[yCoord, xCoord] is not 0)
                        {
                            foundThisRotation.Add(numberGrid[yCoord, xCoord]);
                        }
                    }

                    validPartsSum += foundThisRotation.Sum();
                }
            }
        }

        return validPartsSum;
    }
}