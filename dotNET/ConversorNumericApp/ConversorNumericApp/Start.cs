using Jcvalera.Core.BLL;
using static System.Console;

namespace Jcvalera.Conversor.App
{
    public class Start
    {
        public void RunApplication()
        {
            WriteLine("======================================================");
            WriteLine("=            Choose an option to use:                =");
            WriteLine("=                                                    =");
            WriteLine("=    1.- Convert number (integer) to letter.         =");
            WriteLine("=    2.- Convert number (integer) to roman number.   =");
            WriteLine("=    3.- Convert roman number to integer.            =");
            WriteLine("=    4.- Convert text number in a number (integer).  =");
            WriteLine("======================================================");
            WriteLine();

            WriteLine($">> Option: ");
            var option = ReadLine();
            WriteLine();
            WriteLine($">> Option selected: {option}");
            WriteLine();

            switch (Convert.ToInt32(option))
            {
                case 1:
                    /*
                    * Convert number (integer) to letter.
                    */
                    WriteLine(">> Enter a number: ");
                    int num2text = Convert.ToInt32(ReadLine());

                    var toLetter = new NumToLetterBLL();
                    var inLetter = toLetter.InLetter(num2text);

                    WriteLine();
                    WriteLine("** The number in letter is: ");
                    WriteLine($"** {inLetter}");
                    WriteLine();

                    break;
                case 2:
                    /*
                     * Convert number integer to roman format
                     */
                    WriteLine(">> Enter a number: ");
                    var num2Roman = Convert.ToInt32(ReadLine());
                    WriteLine();

                    var toRoman = new NumToRomanBLL();
                    var inRoman = toRoman.InRoman(num2Roman);

                    WriteLine("** The number in roman format is: ");
                    WriteLine(inRoman);

                    break;
                case 3:
                    /*
                     * Convert number roman to number
                     */

                    WriteLine(">> Enter a roman number: ");

                    var roman2num = ReadLine();

                    if (string.IsNullOrEmpty(roman2num))
                        WriteLine("Please enter a valid roman number");
                    else
                    {
                        string[] romanLetter = { roman2num };

                        var letter2Roman = new LetterToRomanBLL();
                        var romanNumber = letter2Roman.ConvertRomanNumber(romanLetter);

                        WriteLine();
                        WriteLine("**The roman number is: ");
                        WriteLine(string.Join(" ", romanNumber));
                        WriteLine();
                    }

                    break;
                case 4:
                    /*
                     * Convert letter to number
                     */
                    WriteLine(">> Type a number in letter: ");
                    var numLetter = ReadLine();

                    var isNumeric = int.TryParse(numLetter, out _);

                    if (string.IsNullOrEmpty(numLetter) || isNumeric)
                        WriteLine("Please, enter a number in letter. ");
                    else
                    {
                        var toNumber = new LetterToNumberBLL();
                        //var number = toNumber.InLetter(numLetter.ToUpper());
                        var num = toNumber.InLetter(numLetter);

                        WriteLine();
                        WriteLine("** The number letter to number is: ");
                        WriteLine(num);
                    }
                    break;
                default:
                    WriteLine("Option not valid.");
                    break;
            }

        }

        public bool ContinueProgram()
        {
            WriteLine();
            WriteLine(">> Would you like continue? (Y/N): ");
            ForegroundColor = ConsoleColor.Red;
            WriteLine("Note: Any other key that answer to the question, will be taken as 'N'. ");

            ForegroundColor = ConsoleColor.Green;
            var continu = ReadLine();

            bool isContinue = true;
            var isNumeric = int.TryParse(continu, out _);
            if (string.IsNullOrEmpty(continu) || isNumeric || continu.ToLower() == "n")
            {
                isContinue = false;
                return isContinue;
            }
            
            return isContinue;
        }
    }
}
