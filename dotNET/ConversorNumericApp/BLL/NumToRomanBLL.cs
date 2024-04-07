using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jcvalera.Core.BLL
{
    public class NumToRomanBLL
    {
        static Rule[] Rules = new Rule[]
        {
            new Rule(1000, "M"),
            new Rule(900, "CM"),
            new Rule(500, "D"),
            new Rule(400, "CD"),
            new Rule(100, "C"),
            new Rule(90, "XC"),
            new Rule(50, "L"),
            new Rule(40, "XL"),
            new Rule(10, "X"),
            new Rule(9, "IX"),
            new Rule(5, "V"),
            new Rule(4, "IV"),
            new Rule(1, "I"),
        };

        public string InRoman(int number)
        {
            var romanise = Romanise(number);

            return romanise;
        }

        public string Romanise(int num)
        {
            if (num == 0)
                return ""; // Recursion termination

            foreach (var rule in Rules) // Rules are in descending order
                if (rule.N <= num)
                    return rule.Symbol + Romanise(num - rule.N); // Recurse 

            // If this line is reached then n < 0
            throw new ArgumentOutOfRangeException("n must be greater than or equal to 0");
        }

    }

    class Rule
    {
        public int N { get; set; }

        public string Symbol { get; set; }

        public Rule(int n, string symbol)
        {
            N = n;
            Symbol = symbol;
        }
    }
}
