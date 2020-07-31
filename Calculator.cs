using System;

namespace Enhanced_Calculator
{
    class Calculator
    {
        private readonly Validator _validator = new Validator();

        public double Calculate(string input)
        {

            _validator.ValidateInput(input);
            return Calc(input);

        }

        private double Calc(string input)
        {
            string[] expCollection = input.Split('+');
            if (expCollection.Length > 1)
            {
                return Addition(expCollection);
            }

            expCollection = input.Split('-');
            if (expCollection.Length > 1)
            {
                return Subtraction(expCollection);
            }

            expCollection = input.Split('/');
            if (expCollection.Length > 1)
            {
                return Division(expCollection);
            }

            expCollection = input.Split('*');
            if (expCollection.Length > 1)
            {
                return Multiplication(expCollection);
            }

            return ConvertInputToNumber(input);
        }

        private double Addition(string[] expCollection)
        {
            var result = 0.00;
            foreach (string exp in expCollection)
            {
                result += Calc(exp);
            }
            return result;
        }

        private double Subtraction(string[] expCollection)
        {
            var result = Calc(expCollection[0]);
            for (int i = 1; i < expCollection.Length; i++)
            {
                result -= Calc(expCollection[i]);
            }
            return result;
        }

        private double Division(string[] expCollection)
        {
            var result = Calc(expCollection[0]);
            for (int i = 1; i < expCollection.Length; i++)
            {
                result /= Calc(expCollection[i]);
            }
            return result;
        }

        private double Multiplication(string[] expCollection)
        {
            var result = 1.00;
            foreach (string exp in expCollection)
            {
                result *= Calc(exp);
            }
            return result;
        }

        private double ConvertInputToNumber(string str)
        {
            _validator.ValidateToBeNumber(str);

            double.TryParse(str, out var num);
            return num;

        }

    }
}
