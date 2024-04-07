using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcvalera.Core.BLL
{
    public class LetterToRomanBLL
    {
        private static readonly string[,] romanSymbols =
        {
            { "I", "1" },
            { "V", "5" },
            { "X", "10" },
            { "L", "50" },
            { "C", "100" },
            { "D", "500" },
            { "M", "1000" }
        };

        private static readonly string[,] predecessor =
        {
            { "IV", "4" },
            { "IX", "9" },
            { "XL", "40" },
            { "XC", "90" },
            { "CD", "400" },
            { "CM", "900" }
        };

        private static readonly string[] NotValidLetterRoman =
        {
            "A", "B", "E", "F", "G", "H", "J", "K", "N", "O", "P", "Q", "R", "S", "T", "U", "W", "Y", "Z",
            "0", "1", "2", "3", "4", "5", "6", "7", "8", "9"
        };

        public string[] ConvertRomanNumber(string[] words)
        {
            var elementList = new List<string>();

            for (int i = 0; i < words.Length; i++)
            {
                var word = words[i];
                var charArray = word.ToCharArray();
                var value = charArray.Where(x => NotValidLetterRoman.Contains(x.ToString()));

                if (!value.Any())
                {
                    var romanNumber = ParseRomans(words[i]);

                    var numToLetter = new NumToLetterBLL();
                    var romanLetter = numToLetter.InLetter(Convert.ToInt32(romanNumber));

                    var romanArray = romanLetter.Split(' ');
                    for (int j = 0; j < romanArray.Length; j++)
                        elementList.Add(romanArray[j]);
                }
                else
                    elementList.Add(words[i]);
            }

            var romanLetterArray = elementList.ToArray();

            return romanLetterArray;
        }


        public string ParseRomans(string romans)
        {
            var counter = 0;
            var pointer = 0;
            var sum = 0;

            while (pointer != predecessor.Length / 2)
            {
                if (romans.Contains(predecessor[pointer, 0]))
                {
                    sum += int.Parse(predecessor[pointer, 1]);
                    romans = romans.Replace(predecessor[pointer, 0], "");
                }

                pointer++;
            }

            counter = 0;
            pointer = 0;

            if (romans.Length > 0)
                while (counter != romans.Length)
                {
                    while (pointer != romanSymbols.Length / 2)
                    {
                        if (romans.Substring(counter, 1) == romanSymbols[pointer, 0]) sum += int.Parse(romanSymbols[pointer, 1]);
                        pointer++;
                    }

                    pointer = 0;
                    counter++;
                }

            return sum.ToString();
        }
    }
}
