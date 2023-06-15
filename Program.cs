using my_personal_csharp.Models;

string[] nameExamples = {
    " vincent VAN gogh",
    " diogo dE lIMA SCARMAGNANI",
    "DIOGO L. SCARMAGNANI",
    " edwin     VAN DER SAR     ",
    " luiz philippe de orleans e bragança",
    " roBERt o’doNNElL ",
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
foreach (var (position, name) in nameExamples.Select((item, i) => (++i, item)))
{
    string idx = position.ToString().PadLeft(2, '0');
    string formattedName = name.FormatName();
    Console.WriteLine($"Name #{idx}: {formattedName}.");
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
foreach (var (position, cpf) in cpfExamples.Select((item, i) => (++i, item)))
{
    string idx = position.ToString().PadLeft(2, '0');
    string formattedCpf = cpf.FormatCpf();
    Console.WriteLine($"CPF #{idx}: {formattedCpf}.");
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
foreach (var (position, cnpj) in cnpjExamples.Select((item, i) => (++i, item)))
{
    string idx = position.ToString().PadLeft(2, '0');
    string formattedCnpj = cnpj.FormatCnpj();
    Console.WriteLine($"CNPJ #{idx}: {formattedCnpj}.");
}

Console.WriteLine("\n\n----------------------------------------------------------------\n\n");

