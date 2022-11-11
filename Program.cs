using my_personal_csharp.Models;

string[] nameExamples = {
    " vincent VAN gogh",
    " diogo dE lIMA SCARMAGNANI",
    "DIOGO L. SCARMAGNANI",
    " edwin     VAN DER SAR     ",
    " luiz philippe de orleans e bragança",
    " roBERt o'doNNElL ",
    "affonso   deLLA    mÔnica    ",
    "randall mccoy",
    "   BRUCE     MCLAREN  ",
    "JIMMY maccarthy   ",
    "  MARCELLO     DA   ROCHA    MACARTHY   ",
    "charles de gaulle",
    "   leonardo  di caprio"
};

Console.WriteLine("Examples of names:");
for (int i = 0, j = 1; i < nameExamples.Length; i++, j++)
{
    string numWithZeroOnLeft = j.ToString().PadLeft(2, '0');
    string formattedName = BetterString.FormatName(nameExamples[i]);
    Console.WriteLine($"Name {numWithZeroOnLeft}: {formattedName}.");
}

Console.WriteLine("\n\n----------------------------------------------------------------\n\n");

string[] cpfExamples = {
    "12345678909",
    "  351356135354",
    "  35321        351 31351 351  ",
    " 9873348",
    "351aasdf351968.. 8354   ",
    "375.719.958.84"
};

Console.WriteLine("Examples of CPF's:");
for (int i = 0, j = 1; i < cpfExamples.Length; i++, j++)
{
    string numWithZeroOnLeft = j.ToString().PadLeft(2, '0');
    string formattedCpf = BetterString.FormatCpf(cpfExamples[i]);
    Console.WriteLine($"CPF {numWithZeroOnLeft}: {formattedCpf}.");
}