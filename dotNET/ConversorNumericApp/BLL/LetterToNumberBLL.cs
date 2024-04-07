using System.Text.RegularExpressions;

namespace Jcvalera.Core.BLL
{
    public class LetterToNumberBLL
    {
        public long InLetter(string letterNumber)
        {
            var number = ToNumber(letterNumber);

            return number;
        }

        public long ToNumber(string numberString)
        {
            var numbers = Regex.Matches(numberString, @"\w+").Cast<Match>()
                 .Select(m => m.Value.ToLowerInvariant())
                 .Where(v => numberTable.ContainsKey(v))
                 .Select(v => numberTable[v]);

            long acc = 0;
            long total = 0L;

            foreach (var n in numbers)
            {
                if (n >= 1000)
                {
                    total += (acc * n);
                    acc = 0;
                }
                else if (n >= 100)
                {
                    acc = n;
                }
                else acc += n;
            }

            return (total + acc) * (numberString.StartsWith("minus", StringComparison.InvariantCultureIgnoreCase) ? -1 : 1);
        }

        private static Dictionary<string, long> numberTable = new Dictionary<string, long>
        {
            {"y", 0}, {"cero", 0},
            {"uno", 1}, {"un", 1},
            {"dos", 2}, {"tres", 3}, {"cuatro", 4}, {"cinco", 5}, {"seis", 6}, {"siete", 7}, {"ocho", 8}, {"nueve", 9}, {"diez", 10},
            {"once", 11}, {"doce", 12}, {"trece", 13}, {"catorce", 14}, {"quince", 15}, {"dieciseis", 16}, {"diecisiete", 17}, {"dieciocho", 18}, {"diecinueve", 19},
            {"veinte", 20}, {"veinti", 20},
            {"treinta", 30}, {"cuarenta", 40}, {"cincuenta", 50}, {"sesenta", 60}, {"setenta", 70}, {"ochenta", 80}, {"noventa", 90},
            {"cien", 100}, {"ciento", 100},
            {"doscientos", 200}, {"trescientos", 300}, {"cuatrocientos", 400}, {"quinientos", 500}, {"seiscientos", 600}, {"setecientos", 700}, {"ochocientos", 800}, {"novecientos", 900},
            {"mil", 1000},
            //{"un millon", 1000000},
            {"millon", 1000000}, {"millones", 1000000},
            {"billones",1000000000},
            {"trillones",1000000000000},
            {"cuatrillones",1000000000000000},
            {"quintilliones",1000000000000000000},
        };
    }
}
