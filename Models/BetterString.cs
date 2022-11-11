using System.Text.RegularExpressions;

namespace my_personal_csharp.Models
{
    public static class BetterString
    {
        private static string RemoveSpaces(string strToRemoveSpaces)
        {
            return Regex.Replace(strToRemoveSpaces.Trim(), @"\s+", " ");
        }

        public static string FormatName(string notFormattedName)
        {
            const string REGEX_TO_COMPARE = @"(mac|mc)([^aeiouAEIOU]{1})";
            string formattedName = String.Empty;
            string nameWithoutExtraSpaces = RemoveSpaces(notFormattedName);
            string[] arrNames = nameWithoutExtraSpaces.Split(" ");
            string[] artigosEPreposicoes = {
                "di", "da", "das", "do", "dos", "de", "e", "von", "van", "le", "la", "du", "des", "del", "della", "der"
            };

            foreach(var name in arrNames)
            {
                if (arrNames.First() != name && artigosEPreposicoes.Contains(name.ToLower()))
                {
                    formattedName += name.ToLower();
                }
                else
                {
                    if (name.Substring(0, 2).ToUpper() == "O'")
                    {
                        formattedName += name.Substring(0, 3).ToUpper() + name.Substring(3).ToLower();
                    }
                    else if (name.Length > 3 && Regex.IsMatch(name.Substring(0, 3).ToLower(), REGEX_TO_COMPARE))
                    {
                        char[] chars = { char.ToUpper(name[0]), char.ToLower(name[1]), char.ToUpper(name[2]) };
                        formattedName += new string(chars) + name.Substring(3).ToLower();
                    }
                    else if (name.Length > 4 && Regex.IsMatch(name.Substring(0, 4).ToLower(), REGEX_TO_COMPARE))
                    {
                        formattedName += char.ToUpper(name[0]) + name.Substring(1, 2).ToLower() + char.ToUpper(name[3]) + name.Substring(4).ToLower();
                    }
                    else
                    {
                        formattedName += char.ToUpper(name[0]) + name.Substring(1).ToLower();
                    }
                }

                formattedName += arrNames.Last() == name ? "" : " ";
            }
            
            return formattedName;
        }

        public static string FormatCpf(string notFormattedCpf)
        {
            string cpfWithoutExtraSpaces = RemoveSpaces(notFormattedCpf);
            string cpfAux = String.Empty;
            string formattedCpf = String.Empty;

            for (int i = cpfWithoutExtraSpaces.Length-1, j = 0; i >= 0 && j < 11; i--) {
                int num;
                if (int.TryParse(cpfWithoutExtraSpaces[i].ToString(), out num)) {
                    cpfAux = cpfWithoutExtraSpaces[i].ToString() + cpfAux;
                    j++;
                }
            }

            cpfAux = cpfAux.PadLeft(11, '0');
            formattedCpf = cpfAux.Substring(0, 3) + '.' + cpfAux.Substring(3, 3) + '.' + cpfAux.Substring(6, 3) + '-' + cpfAux.Substring(9);
            
            return formattedCpf;
        }

        public static string FormatCnpj(string notFormattedCnpj)
        {
            string cnpjWithoutExtraSpaces = RemoveSpaces(notFormattedCnpj);
            string cnpjAux = String.Empty;
            string formattedCnpj = String.Empty;

            for (int i = cnpjWithoutExtraSpaces.Length-1, j = 0; i >= 0 && j < 14; i--) {
                int num;
                if (int.TryParse(cnpjWithoutExtraSpaces[i].ToString(), out num)) {
                    cnpjAux = cnpjWithoutExtraSpaces[i].ToString() + cnpjAux;
                    j++;
                }
            }

            cnpjAux = cnpjAux.PadLeft(14, '0');
            formattedCnpj = cnpjAux.Substring(0, 2) + '.' + cnpjAux.Substring(2, 3) + '.' + cnpjAux.Substring(5, 3) + '/' + cnpjAux.Substring(8, 4) + '-' + cnpjAux.Substring(12);
            
            return formattedCnpj;
        }
    }
}