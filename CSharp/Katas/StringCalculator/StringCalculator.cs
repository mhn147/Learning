using System.Linq;

namespace StringCalculator;

public class StringCalculator
{
    public int Add(string numbers)
    {
        if (string.IsNullOrWhiteSpace(numbers))
        {
            return 0;
        }

        var delimiters = _getDelimiters(numbers);

        var numbersSplitted = numbers.Split(delimiters, StringSplitOptions.None);

        int sum = 0;
        var negativeNumbersString = string.Empty;

        int parsedNumber;
        foreach (var number in numbersSplitted)
        {
            if (int.TryParse(number, out parsedNumber))
            {
                if (parsedNumber >= 0)
                {
                    sum += parsedNumber;
                }
                else
                {
                    negativeNumbersString += $"{parsedNumber}, ";
                }
            }
        }

        if (!string.IsNullOrEmpty(negativeNumbersString))
        {
            var errorMessage = $"Negatives not allowed: {negativeNumbersString.Substring(0, negativeNumbersString.Length - 2)}";
            throw new ArgumentOutOfRangeException(errorMessage);
        }
        
        return sum;
    }

    private char[] _getDelimiters(string numbers)
    {
        var delimiters = new List<char>
        {
            ',', '\n'
        };

        var optionalDelimiter = _extractOptionalDelimiter(numbers);

        if (!string.IsNullOrEmpty(optionalDelimiter))
        {
            delimiters.Add(char.Parse(optionalDelimiter));
        }

        return delimiters.ToArray();
    }

    private string _extractOptionalDelimiter(string numbers)
    {
        // format: //[delimiter]\n....

        var numbersSplitted = numbers.Split("\n");

        if (numbersSplitted.Length == 0)
        {
            return null;
        }

        var delimiter = numbersSplitted[0];

        if (delimiter.Length < 3 || delimiter[0] != '/' || delimiter[1] != '/' ||
            string.IsNullOrEmpty(delimiter[2].ToString()))
        {
            return null;
        }

        return delimiter.Substring(2, 1);
    }
}