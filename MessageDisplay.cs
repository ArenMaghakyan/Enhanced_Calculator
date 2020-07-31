using System;

namespace Enhanced_Calculator
{
    class MessageDisplay
    {
        public void SetAppHeader()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Input expression and press Enter. Only simple operation is supported (+, -, /, *)");
            Console.WriteLine("To exit, input char x and press Enter");
            Console.ResetColor();
        }
        public void ShowError(string errorMessage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(errorMessage);
            Console.ResetColor();
        }

        public void ShowInfo(string infoMessage)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine(infoMessage);
            Console.ResetColor();
        }

        public void ShowClosingInfo()
        {
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("Sorry to see you leaving (");
            Console.ResetColor();
        }
    }
}
