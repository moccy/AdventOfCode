namespace Y2023D01;

public class Solver
{
    public static int SolvePart1(string[] lines)
    {
        var sum = 0;
    
        foreach (var line in lines)
        {
            var digits = line.Where(x => char.IsDigit(x));
            if (digits.Count() > 0)
            {
                var value = $"{digits.First()}{digits.Last()}";
                sum += int.Parse(value);
            }
        }
    
        return sum;
    }
    
    public static int SolvePart2(string[] lines)
    {
        var sum = 0;
    
        var digitDict = new Dictionary<string, int>() {
            { "one", 1 },
            { "two", 2 },
            { "three", 3 },
            { "four", 4 },
            { "five", 5 },
            { "six", 6 },
            { "seven", 7 },
            { "eight", 8 },
            { "nine", 9 },
        };
    
        foreach (var line in lines)
        {
            var digits = new SortedDictionary<int, int>();
    
            foreach (var pair in digitDict)
            {
                for (var i = line.IndexOf(pair.Key); i > -1; i = line.IndexOf(pair.Key, i + 1))
                {
                    digits[i] = digitDict[pair.Key];
                }
            }
    
            for (var i = 0; i < line.Length; i++)
            {
                if (!char.IsDigit(line[i])) continue;
                digits[i] = int.Parse(line[i].ToString());
            }
    
            var value = $"{digits.First().Value}{digits.Last().Value}";
            sum += int.Parse(value);
        }
    
        return sum;
    }
}