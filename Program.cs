using my_personal_csharp.Models;
using System.Text.RegularExpressions;

string[] nameExamples = {
    " vincent VAN gogh",
    " diogo dE lIMA SCARMAGNANI",
    "DIOGO L. SCARMAGNANI",
    " edwin     VAN DER SAR     ",
    " luiz philippe de orleans e bragança",
    " roBERt o'doNNElL ",
    "affonso   deLLA    mÔnica    ",
    "randall mccoy",
    "james labrie",
    "   BRUCE     MCLAREN  ",
    "  lebron james ",
    "JIMMY maccarthy   ",
    "  MARCELLO     DA   ROCHA    MACARTHY   ",
    "charles de gaulle",
    "   leonardo  dicaprio"
};

Console.WriteLine("Examples of names:");
for (int i = 0, j = 1; i < nameExamples.Length; i++, j++)
{
    string numWithZeroOnLeft = j.ToString().PadLeft(2, '0');
    string formattedName = nameExamples[i].FormatName();
    Console.WriteLine($"Name {numWithZeroOnLeft}: {formattedName}.");
}

Console.WriteLine("\n\n----------------------------------------------------------------\n\n");

string[] cpfExamples = {
    "12345678909",
    "  351356135354",
    "  35321        351 31351 351  ",
    " 9873348",
    "351aasdf351968.. 8354   ",
    "755.805.273.49"
};

Console.WriteLine("Examples of CPF's:");
for (int i = 0, j = 1; i < cpfExamples.Length; i++, j++)
{
    string numWithZeroOnLeft = j.ToString().PadLeft(2, '0');
    string formattedCpf = cpfExamples[i].FormatCpf();
    Console.WriteLine($"CPF {numWithZeroOnLeft}: {formattedCpf}.");
}

Console.WriteLine("\n\n----------------------------------------------------------------\n\n");

string[] cnpjExamples = {
    "12345678909",
    " 46    379 400.0001.50  ",
    " 9873348",
    " 11 273 485 0002 94",
    "351aasdf351968.. 8354   ",
    "755.805.273.49"
};

Console.WriteLine("Examples of CNPJ's:");
for (int i = 0, j = 1; i < cnpjExamples.Length; i++, j++)
{
    string numWithZeroOnLeft = j.ToString().PadLeft(2, '0');
    string formattedCnpj = cnpjExamples[i].FormatCnpj();
    Console.WriteLine($"CNPJ {numWithZeroOnLeft}: {formattedCnpj}.");
}

Console.WriteLine("\n\n----------------------------------------------------------------\n\n");

