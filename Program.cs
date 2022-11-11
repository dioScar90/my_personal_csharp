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