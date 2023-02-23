<?php
    class BetterString
    {
        private static function RemoveSpaces($strToRemoveSpaces)
        {
            return preg_replace('/\s+/', ' ', trim($strToRemoveSpaces));
        }

        public static function FormatName($notFormattedName)
        {
            $REGEX_TO_COMPARE = '/(mac|mc)([^aeiouAEIOU]{1})/';
            $formattedName = '';
            $nameWithoutExtraSpaces = self::RemoveSpaces($notFormattedName);
            $arrNames = explode(' ', $nameWithoutExtraSpaces);
            $specificNames = [
                "dicaprio", "distefano", "lebron", "labrie"
            ];
            $prepositions = [
                "di", "da", "das", "do", "dos", "de", "e", "von", "van", "le", "la", "du", "des", "del", "della", "der", "al"
            ];

            foreach($arrNames as $name)
            {
                if ($arrNames[0] != $name && in_array(strtolower($name), $prepositions))
                {
                    $formattedName .= strtolower($name);
                }
                else
                {
                    if (strtoupper(substr($name, 0, 2)) == "O'")
                    {
                        $formattedName .= strtoupper(substr($name, 0, 3)) . strtolower(substr($name, 3));
                    }
                    else if (in_array(strtolower($name), $specificNames))
                    {
                        $chars = [strtoupper($name[0]), strtolower($name[1]), strtoupper($name[2])];
                        $formattedName .= implode('', $chars) . strtolower(substr($name, 3));
                    }
                    else if (strlen($name) > 3 && preg_match($REGEX_TO_COMPARE, strtolower(substr($name, 0, 3))))
                    {
                        $chars = [strtoupper($name[0]), strtolower($name[1]), strtoupper($name[2])];
                        $formattedName .= implode('', $chars) . strtolower(substr($name, 3));
                    }
                    else if (strlen($name) > 4 && preg_match($REGEX_TO_COMPARE, strtolower(substr($name, 0, 4))))
                    {
                        $formattedName .= strtoupper($name[0]) . strtolower(substr($name, 1, 2)) . strtoupper($name[3]) . strtolower(substr($name, 4));
                    }
                    else
                    {
                        $formattedName .= strtoupper($name[0]) . strtolower(substr($name, 1));
                    }
                }

                $formattedName .= end($arrNames) == $name ? '' : ' ';
            }
            
            return $formattedName;
        }
    }

    $nameExamples = [
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
    ];

    echo "\nExamples of names:";
    for ($i = 0, $j = 1; $i < sizeof($nameExamples); $i++, $j++)
    {
        $numWithZeroOnLeft = str_pad($j, 2, '0', STR_PAD_LEFT);
        $formattedName = BetterString::FormatName($nameExamples[$i]);
        echo "\nName {$numWithZeroOnLeft}: {$formattedName}.";
    }