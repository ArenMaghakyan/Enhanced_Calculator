using System;

namespace Enhanced_Calculator
{
    class Calculator
    {
        private readonly Message _message = new Message();
        public double Calculate(string input)
        {
            double result;
            string[] expCollection = input.Split('+');
            if (expCollection.Length > 1)
            {
                result = 0;
                foreach (string exp in expCollection)
                { 
                    result += Calculate(exp);
                }
                return result;
            }
            expCollection = input.Split('-');
            if (expCollection.Length > 1)
            {
                result = Calculate(expCollection[0]);
                for (int i = 1; i < expCollection.Length; i++)
                {
                    result -= Calculate(expCollection[i]);
                }
                return result;
            }
            expCollection = input.Split('/');
            if (expCollection.Length > 1)
            {
                result = Calculate(expCollection[0]);
                for (int i = 1; i < expCollection.Length; i++)
                {
                    result /= Calculate(expCollection[i]);
                }
                return result;
            }
            expCollection = input.Split('*');
            if (expCollection.Length > 1)
            {
                result = 1;
                foreach (string exp in expCollection)
                {
                    result *= Calculate(exp);
                }
                return result;
            }

            var isNotANumber = !double.TryParse(input, out result);
            if (isNotANumber)
            {
                _message.ShowError("Expression is not numeric\r\n");
                throw new ArgumentException("");
            }

            return result;
        }
    }
}
