using System.Text.RegularExpressions;

namespace my_personal_csharp.Models;

public static partial class BetterString
{
    private static readonly string mcOrMacPattern = @"(mac|mc)([^aeiouAEIOU]{1})";
    private static readonly string[] specificNames = { "dicaprio", "distefano", "lebron", "labrie" };
    private static readonly string[] prepositions = {
        "di", "da", "das", "do", "dos", "de", "e", "von", "van", "le", "la", "du", "des", "del", "della", "der", "al"
    };

    private static string RemoveExtraSpaces(this string inputString) => MyRegex().Replace(inputString.Trim(), " ");
    private static string GetOnlyNumbers(this string inputString) => MyRegex1().Replace(inputString, "");
    
    private static bool IsPreposition(string value) => prepositions.Contains(value.ToLower());
    private static bool StartsWithOApostrophe(string value)
    {
        string twoFirst = value[..2].ToUpper();
        string[] twoO = { "O'", "O’" };
        return value.Length > 1 && twoO.Contains(twoFirst);
    }
    
    private static bool IsOneOFSpecificNames(string value) => specificNames.Contains(value.ToLower());
    private static bool StartsWithMcOrMac(string value, int min)
    {
        if (value.Length <= min)
            return false;
        
        string valueLower = value[..min].ToLower();
        return Regex.IsMatch(valueLower, mcOrMacPattern);
    }

    private static string GetFormattedName(string item, int index)
    {
        if (index > 0 && IsPreposition(item))
            return item.ToLower();
        
        if (StartsWithOApostrophe(item))
            return item[..3].ToUpper() + item[3..].ToLower();
        
        if (IsOneOFSpecificNames(item) || StartsWithMcOrMac(item, 3))
        {
            char zero            = char.ToUpper(item[0]);
            char one             = char.ToLower(item[1]);
            char two             = char.ToUpper(item[2]);
            char[] threeAndBeyond= item[3..].ToLower().ToCharArray();
            char[] finalArray = new[] { zero, one, two }.Concat(threeAndBeyond).ToArray();
            return new string(finalArray);
        }
        
        
        if (StartsWithMcOrMac(item, 4))
        {
            char zero            = char.ToUpper(item[0]);
            char[] oneTwo          = item[1..3].ToLower().ToCharArray();
            char three           = char.ToUpper(item[3]);
            char[] fourAndBeyond   = item[4..].ToLower().ToCharArray();
            char[] finalArray = new[] { zero }.Concat(oneTwo).Concat(new[] { three }).Concat(fourAndBeyond).ToArray();
            return new string(finalArray);
        }
            
        return char.ToUpper(item[0]) + item[1..].ToLower();
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
            onlyNumbers = onlyNumbers[^maxLength..];

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

    [GeneratedRegex("\\s+")]
    private static partial Regex MyRegex();
    [GeneratedRegex("[^0-9]")]
    private static partial Regex MyRegex1();
}