// See https://aka.ms/new-console-template for more information
using Jcvalera.Conversor.App;
using static System.Console;

BackgroundColor = ConsoleColor.Black;
ForegroundColor = ConsoleColor.Green;

WriteLine("******************************************************");
WriteLine("*                                                    *");
WriteLine("*              Welcome to conversor App              *");
WriteLine("*                                                    *");
WriteLine("******************************************************");
WriteLine();

while (true)
{
    var start = new Start();
    start.RunApplication();

    var isContinue = start.ContinueProgram();
    if (!isContinue)
        return 0;
    else
        Clear();
}