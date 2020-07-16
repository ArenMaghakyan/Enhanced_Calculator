using System.Linq;
using System.Text.RegularExpressions;

namespace Enhanced_Calculator
{
    class Validator
    {
        private readonly Regex _validationRegex = new Regex("^[0-9+*-/.]+$");
        private readonly Regex _divisionByZeroRegex = new Regex("/0");
        private readonly Message _message = new Message();  

        public bool ValidateInput(string input)
        {
            if (string.IsNullOrEmpty(input))
            {
                _message.ShowError("Expression can't be empty! Check once more\r\n");
                return false;
            }

            var isForbiddenSymbol = !_validationRegex.IsMatch(input);

            if (isForbiddenSymbol)
            {
                _message.ShowError("Forbidden symbol detected. Use only following symbols [0-9+-/*]\r\n");
                return false;
            }

            var isDividedToZero = _divisionByZeroRegex.IsMatch(input);

            if (isDividedToZero)
            {
                _message.ShowError("Division to Zero is not allowed\r\n");
                return false;
            }

            var lastSymbolNotANumber = !char.IsDigit(input.Last());

            if (lastSymbolNotANumber)
            {
                _message.ShowError("Format is not correct. Please check last char and resubmit\r\n");
                return false;
            }

            var firstSymbolNotANumber = !char.IsDigit(input.First());

            if (firstSymbolNotANumber)
            {
                _message.ShowError("Format is not correct. Please check first char and resubmit\r\n");
                return false;
            }

            return true;
        }
    }
}
