using System.Globalization;

namespace RomanNumeralAPI.Models;

public class Solution
{
    public int RomanToInt(string str)
    {
        if (string.IsNullOrWhiteSpace(str))
        {
            throw new ArgumentException("Entrada vazia ou nula.");
        }

        var values = new Dictionary<char, int>
        {
            { 'I', 1 },
            { 'V', 5 },
            { 'X', 10 },
            { 'L', 50 },
            { 'C', 100 },
            { 'D', 500 },
            { 'M', 1000 },
        };

        foreach (char ch in str)
            if (!values.ContainsKey(ch))
            {
                throw new ArgumentException($"Caractere inválido '{ch}' em numeral romano.");
            }

        int total = 0;
        for (int i = 0; i < str.Length; i++)
        {
            int current = values[str[i]];
            if (i + 1 < str.Length && current < values[str[i + 1]])
            {
                total -= current;
            }
            else
            {
                total += current;
            }
        }

        if (total < 1 || total > 3999)
        {
            throw new ArgumentOutOfRangeException(
                $"Valor {total} fora do intervalo suportado (1-3999)."
            );
        }

        return total;
    }

    public string RomanToIntFormatted(string str)
    {
        int number = RomanToInt(str);
        return number.ToString("N0", new CultureInfo("pt-BR"));
    }

    public string IntToRoman(int num)
    {
        if (num < 1 || num > 3999)
        {
            throw new ArgumentOutOfRangeException("Número deve estar entre 1 e 3.999.");
        }

        var map = new List<(int value, string symbol)>
        {
            (1000, "M"),
            (900, "CM"),
            (500, "D"),
            (400, "CD"),
            (100, "C"),
            (90, "XC"),
            (50, "L"),
            (40, "XL"),
            (10, "X"),
            (9, "IX"),
            (5, "V"),
            (4, "IV"),
            (1, "I"),
        };

        var result = new System.Text.StringBuilder();
        foreach (var (value, symbol) in map)
        {
            while (num >= value)
            {
                result.Append(symbol);
                num -= value;
            }
        }
        return result.ToString();
    }
}
