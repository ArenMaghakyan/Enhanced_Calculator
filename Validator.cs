using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace Enhanced_Calculator
{
    class Validator
    {
        private readonly Regex _validationRegex = new Regex("^[0-9+*-/.]+$");
        private readonly Regex _divisionByZeroRegex = new Regex("/0");
        //private readonly Regex _firstLastSymbolRegex = new Regex("/^[0-9].*[0-9]$");

        public void ValidateInput(string input)
        {

            ValidateNullOrEmpty(input);

            ValidateForbiddenSymbol(input);

            ValidateDividedToZero(input);

            ValidateFirstLastSymbol(input);

        }

        public void ValidateToBeNumber(string str)
        {
            if (!double.TryParse(str, out _))
            {
                throw new ArgumentException("Expression is not numeric\r\n");
            }
        }

        private void ValidateNullOrEmpty(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                throw new ArgumentException("Expression can't be empty! Check once more\r\n");
            }
        }

        private void ValidateForbiddenSymbol(string str)
        {
            if (!_validationRegex.IsMatch(str))
            {
                throw new ArgumentException("Forbidden symbol detected. Use only following symbols [0-9+-/*]\r\n");
            }
        }

        private void ValidateDividedToZero(string str)
        {
            if (_divisionByZeroRegex.IsMatch(str))
            {
                throw new ArgumentException("Division to Zero is not allowed\r\n");
            }
        }

        private void ValidateFirstLastSymbol(string str)
        {

            if (!char.IsDigit(str.First()))
            {
                throw new ArgumentException("Format is not correct. Please check first char and resubmit\r\n");
            }

            if (!char.IsDigit(str.Last()))
            {
                throw new ArgumentException("Format is not correct. Please check last char and resubmit\r\n");
            }

            //if (_firstLastSymbolRegex.IsMatch(str))
            //{
            //    throw new ArgumentException("Format is not correct. Please check first/last char and resubmit\r\n");
            //}
        }

    }
}
