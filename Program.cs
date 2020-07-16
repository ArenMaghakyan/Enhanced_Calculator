using System;

namespace Enhanced_Calculator
{
    internal class Program
    {
        private static int Main(string[] args)
        {
            Message message = new Message();
            Validator validator = new Validator();
            Calculator calculator = new Calculator();

            message.SettingAppHeader();

            while (true)
            {
                var input = Console.ReadLine();

                if (input == "x")
                {
                    message.ClosingText();
                    break;
                }

                var isValid = validator.ValidateInput(input);

                if (isValid)
                {
                    var result = calculator.Calculate(input);
                    Console.WriteLine(result);
                }
            }

            return 0;
        }
    }
}