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

            TestInit();

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

            void TestInit()
            {

                message.ShowInfo("\r\nTest cases\r\n");

                var case1 = calculator.Calculate("10/2+65-40");
                var case1Result = 30;
                if (case1.CompareTo(case1Result) == 0)
                {
                    message.ShowInfo("Correct output 10/2+65-40 = 30");
                }
                else
                {
                    message.ShowError("Something, went wrong. Should be 10/2+65-40 = 30");
                }


                var case2 = calculator.Calculate("15.5-5.5");
                var case2Result = 10;
                if (case2.CompareTo(case2Result) == 0)
                {
                    message.ShowInfo("Correct output 15.5-5.5 = 10");
                }
                else
                {
                    message.ShowError("Something, went wrong. Should be 15.5-5.5 = 10");
                }

                var case3 = calculator.Calculate("10-564+457*46+ 445/5+456");
                var case3Result = 21013;
                if (case3.CompareTo(case3Result) == 0)
                {
                    message.ShowInfo("Correct output 10-564+457*46+ 445/5+456 = 21013");
                }
                else
                {
                    message.ShowError("Something, went wrong. Should be 10-564+457*46+ 445/5+456 = 21013");
                }

                message.ShowInfo("\r\n");

            }


            return 0;
        }
    }
}