using System.Text.RegularExpressions;

namespace PartThree;

public class NumericalExpression(long number)
{
    private static readonly List<string> digits = new List<string>
        { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine" };

    private static readonly List<string> tens = new List<string>
    {
        "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "Nineteen"
    };

    private static readonly List<string> tenMultiples = new List<string>
        { "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };

    private static readonly List<string> units = new List<string> { "Thousand", "Million", "Billion" };


    public override string ToString()
    {
        return NumberToWords(number);
    }

    public static string NumberToWords(long number)
    {
        string result = "";
        string numberString = number.ToString();
        List<int> parts = new List<int>();

        for (int i = numberString.Length - 1; i >= 0; i -= 3)
        {
            string threeDigits = i - 2 >= 0
                ? numberString.Substring(Math.Max(0, i - 2), 3)
                : numberString.Substring(0, numberString.Length % 3);

            parts.Add(int.Parse(threeDigits));
        }

        if (parts.Count > units.Count + 1)
        {
            return "Number is too big, not supported.";
        }

        for (int i = 0; i < parts.Count; i++)
        {
            int part = parts[i];
            string partStr = part.ToString();
            string partRes = "";
            bool tensFound = false;

            for (int j = 0; j < partStr.Length; j++)
            {
                int digit = int.Parse(partStr[j].ToString());
                switch (3 - partStr.Length + j)
                {
                    case 0:
                        if (digit > 0)
                            partRes = digits[digit] + " Hundred ";

                        break;
                    case 1:
                        if (digit == 1)
                        {
                            int secondDigit = int.Parse(partStr[j + 1].ToString());
                            partRes += tens[secondDigit];
                            if (i > 0)
                                partRes += " " + units[i - 1];

                            tensFound = true;
                        }
                        else if (digit > 1)
                            partRes += tenMultiples[digit - 2] + " ";

                        break;
                    case 2:
                        if (!tensFound)
                        {
                            partRes += digits[digit];
                            if (i > 0)
                                partRes += " " + units[i - 1];
                        }

                        break;
                }
            }

            result = partRes + " " + result;
        }

        return result;
    }

    public long GetValue()
    {
        return number;
    }

    public static long SumLetters(long number)
    {
        long sum = 0;

        for (long i = 0; i <= number; i++)
        {
            sum += Regex.Replace(NumberToWords(i), @"s", "").Length;
        }

        return sum;
    }

    public static long SumLetters(NumericalExpression numericalExpression)
    {
        // The OOP principle is overload, which is a part of the polymorphism principle.
        return SumLetters(numericalExpression.GetValue());
    }
}