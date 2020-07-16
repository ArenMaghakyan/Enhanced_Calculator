using System;

namespace Enhanced_Calculator
{
    class Calculator
    {
        private readonly Message _message = new Message();
        public int Calculate(string input)
        {
            int result;
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

            if (!int.TryParse(input, out result))
            {
                _message.ShowError("Expression is not numeric");
                throw new ArgumentException("");
            }

            return result;
        }
    }
}
