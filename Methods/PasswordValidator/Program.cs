using System;

namespace PasswordValidator
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int passMinValue = 6;
            int passMaxValue = 10;

            string password = Console.ReadLine();
            bool isValid = true;

            if (!PasswordLenghtValidator(password, passMinValue, passMaxValue))
            {
                Console.WriteLine($"Password must be between {passMinValue} and {passMaxValue} characters");
                isValid = false;
            }

            if (!PassNumericalValidator(password))
            {
                Console.WriteLine("Password must consist only of letters and digits");
                isValid = false;

            }

            if (!PassNumberOfDigitsValidator(password))
            {
                Console.WriteLine("Password must have at least 2 digits");
                isValid = false;
            }

            if (isValid)
            {
                Console.WriteLine("Password is valid");
            }
        }

        static bool PasswordLenghtValidator(string password, int passMinValue, int passMaxValue)
        {
            int passLenght = password.Length;
            if (passLenght <= passMaxValue && passLenght >= passMinValue)
            {
                return true;
            }
            return false;
        }

        static bool PassNumericalValidator(string password)
        {
            foreach (char ch in password)
            {
                if (!Char.IsLetterOrDigit(ch))
                {
                    return false;
                }
            }
            return true;
        }

        static bool PassNumberOfDigitsValidator(string password)
        {
            int numberOfDigits = 0;

            foreach (var item in password)
            {
                if (Char.IsDigit(item))
                {
                    numberOfDigits++;
                }
            }

            if (numberOfDigits >= 2)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
