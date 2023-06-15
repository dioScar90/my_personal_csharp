using System.Text.RegularExpressions;

namespace my_personal_csharp.Models;

public static class BetterString
{
    private static readonly string mcOrMacPattern = @"(mac|mc)([^aeiouAEIOU]{1})";
    private static readonly string[] specificNames = { "dicaprio", "distefano", "lebron", "labrie" };
    private static readonly string[] prepositions =
        { "di", "da", "das", "do", "dos", "de", "e", "von", "van", "le", "la", "du", "des", "del", "della", "der", "al" };

    private static string RemoveExtraSpaces(this string inputString) => Regex.Replace(inputString.Trim(), @"\s+", " ");
    private static string GetOnlyNumbers(this string inputString) => Regex.Replace(inputString, "[^0-9]", "");
    
    private static bool IsPreposition(string value) => prepositions.Contains(value.ToLower());
    private static bool StartsWithOApostrophe(string value) => value.Length > 1 && new[] { "O'", "O’" }.Contains(value.Substring(0, 2).ToUpper());
    private static bool IsOneOFSpecificNames(string value) => specificNames.Contains(value.ToLower());
    private static bool StartsWithMcOrMac(string value, int min) =>
        value.Length > min && Regex.IsMatch(value.Substring(0, min).ToLower(), mcOrMacPattern);

    private static string GetFormattedName(string item, int index)
    {
        if (index > 0 && IsPreposition(item))
            return item.ToLower();
        
        if (StartsWithOApostrophe(item))
            return item.Substring(0, 3).ToUpper() + item.Substring(3).ToLower();
        
        if (IsOneOFSpecificNames(item) || StartsWithMcOrMac(item, 3))
            return new string(new[] { char.ToUpper(item[0]), char.ToLower(item[1]), char.ToUpper(item[2]) }) + item.Substring(3).ToLower();
        
        if (StartsWithMcOrMac(item, 4))
            return char.ToUpper(item[0]) + item.Substring(1, 2).ToLower() + char.ToUpper(item[3]) + item.Substring(4).ToLower();
            
        return char.ToUpper(item[0]) + item.Substring(1).ToLower();
    }

    public static string FormatName(this string inputValue)
    {
        string nameWithoutExtraSpaces = inputValue.RemoveExtraSpaces();

        string[] arrNames = nameWithoutExtraSpaces.Split(' ');
        string[] arrFormattedNames = arrNames.Select(GetFormattedName).ToArray();

        return string.Join(' ', arrFormattedNames);
    }

    private static string GetDocNumbersWithZeros(string inputValue, int maxLength)
    {
        string onlyNumbers = inputValue.GetOnlyNumbers();

        if (onlyNumbers.Length > maxLength)
            onlyNumbers = onlyNumbers.Substring(onlyNumbers.Length - maxLength);

        return onlyNumbers.PadLeft(maxLength, '0');
    }

    private static string ReplaceDocument(string input, string pattern, string replacement) => Regex.Replace(input, pattern, replacement);

    public static string FormatCpf(this string notFormattedCpf)
    {
        string cpfPattern = @"(\d{3})(\d{3})(\d{3})(\d{2})";
        string cpfReplacement = "$1.$2.$3-$4";

        string numbersWithZeros = GetDocNumbersWithZeros(notFormattedCpf, 11);
        string formattedCpf = ReplaceDocument(numbersWithZeros, cpfPattern, cpfReplacement);

        return formattedCpf;
    }

    public static string FormatCnpj(this string notFormattedCnpj)
    {
        string cnpjPattern = @"(\d{2})(\d{3})(\d{3})(\d{4})(\d{2})";
        string cnpjReplacement = "$1.$2.$3/$4-$5";

        string numbersWithZeros = GetDocNumbersWithZeros(notFormattedCnpj, 14);
        string formattedCnpj = ReplaceDocument(numbersWithZeros, cnpjPattern, cnpjReplacement);

        return formattedCnpj;
    }
}