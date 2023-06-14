using System.Text.RegularExpressions;

namespace my_personal_csharp.Models;

public static class BetterString
{
    private static string REGEX_TO_COMPARE = @"(mac|mc)([^aeiouAEIOU]{1})";
    private static readonly string[] specificNames = { "dicaprio", "distefano", "lebron", "labrie" };
    private static readonly string[] prepositions =
        { "di", "da", "das", "do", "dos", "de", "e", "von", "van", "le", "la", "du", "des", "del", "della", "der", "al" };

    private static string RemoveSpaces(this string inputString) => Regex.Replace(inputString.Trim(), @"\s+", " ");
    private static string GetOnlyNumbers(this string inputString) => Regex.Replace(inputString, "[^0-9]", "");
    private static string GetFormattedCpf(this string inputString) =>
        inputString.Substring(0, 3) + '.' + inputString.Substring(3, 3) + '.' + inputString.Substring(6, 3) + '-' + inputString.Substring(9);
    private static string GetFormattedCnpj(this string inputString) =>
        inputString.Substring(0, 2) + '.' + inputString.Substring(2, 3) + '.' + inputString.Substring(5, 3) + '/' + inputString.Substring(8, 4) + '-' + inputString.Substring(12);

    private static bool IsPreposition(List<string> acc, string curr) => acc.Any() && prepositions.Contains(curr.ToLower());
    private static bool StartsWithOApostrophe(string curr) => curr.Length > 1 && curr.Substring(0, 2).ToUpper() == "O'";
    private static bool IsOneOFSpecificNames(string curr) => specificNames.Contains(curr.ToLower());
    private static bool StartsWithMc(string curr) => curr.Length > 3 && Regex.IsMatch(curr.Substring(0, 3).ToLower(), REGEX_TO_COMPARE);
    private static bool StartsWithMac(string curr) => curr.Length > 4 && Regex.IsMatch(curr.Substring(0, 4).ToLower(), REGEX_TO_COMPARE);

    public static string FormatName(this string notFormattedName)
    {
        string nameWithoutExtraSpaces = notFormattedName.RemoveSpaces();
        string[] arrNames = nameWithoutExtraSpaces.Split(" ");

        string formattedName = arrNames.Aggregate(new List<string>(), (acc, curr) => {
            if (IsPreposition(acc, curr))
            {
                string preposition = curr.ToLower();
                acc.Add(preposition);
                return acc;
            }

            if (StartsWithOApostrophe(curr))
            {
                string oApostrophe = curr.Substring(0, 3).ToUpper() + curr.Substring(3).ToLower();
                acc.Add(oApostrophe);
                return acc;
            }

            if (IsOneOFSpecificNames(curr))
            {
                char[] chars = { char.ToUpper(curr[0]), char.ToLower(curr[1]), char.ToUpper(curr[2]) };
                string specific = new string(chars) + curr.Substring(3).ToLower();
                acc.Add(specific);
                return acc;
            }

            if (StartsWithMc(curr))
            {
                char[] chars = { char.ToUpper(curr[0]), char.ToLower(curr[1]), char.ToUpper(curr[2]) };
                string withMc = new string(chars) + curr.Substring(3).ToLower();
                acc.Add(withMc);
                return acc;
            }

            if (StartsWithMac(curr))
            {
                string withMac = char.ToUpper(curr[0]) + curr.Substring(1, 2).ToLower() + char.ToUpper(curr[3]) + curr.Substring(4).ToLower();
                acc.Add(withMac);
                return acc;
            }
            
            string elseString = char.ToUpper(curr[0]) + curr.Substring(1).ToLower();
            acc.Add(elseString);
            return acc;
        }, result => string.Join(' ', result));
        
        return formattedName;
    }

    private static string GetDocNumbersWithZeros(string inputValue, int maxLength)
    {
        string onlyNumbers = inputValue.GetOnlyNumbers();

        if (onlyNumbers.Length > maxLength)
            onlyNumbers = onlyNumbers.Substring(onlyNumbers.Length - maxLength);

        return onlyNumbers.PadLeft(maxLength, '0');
    }

    public static string FormatCpf(this string notFormattedCpf)
    {
        string numbersWithZeros = GetDocNumbersWithZeros(notFormattedCpf, 11);
        string formattedCpf = numbersWithZeros.GetFormattedCpf();
        return formattedCpf;
    }

    public static string FormatCnpj(this string notFormattedCnpj)
    {
        string numbersWithZeros = GetDocNumbersWithZeros(notFormattedCnpj, 14);
        string formattedCnpj = numbersWithZeros.GetFormattedCnpj();
        return formattedCnpj;
    }
}