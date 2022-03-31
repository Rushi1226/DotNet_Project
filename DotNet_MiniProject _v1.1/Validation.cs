using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;


namespace DotNet_MiniProject
{
    class Validation
    {
        internal static bool isValidEmail(string emailaddress)
        {
            try
            {
                MailAddress m = new MailAddress(emailaddress);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }


        internal static bool isValidPassword(string password, out string ErrorMessage)
        {
            var input = password;
            ErrorMessage = string.Empty;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new Exception("Password should not be empty");
            }

            var hasNumber = new Regex(@"[0-9]+");
            var hasUpperChar = new Regex(@"[A-Z]+");
            var hasMiniMaxChars = new Regex(@".{8,15}");
            var hasLowerChar = new Regex(@"[a-z]+");
            var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

            if (!hasLowerChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one lower case letter";
                return false;
            }
            else if (!hasUpperChar.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one upper case letter";
                return false;
            }
            else if (!hasMiniMaxChars.IsMatch(input))
            {
                ErrorMessage = "Password should not be less than or greater than 12 characters";
                return false;
            }
            else if (!hasNumber.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one numeric value";
                return false;
            }

            else if (!hasSymbols.IsMatch(input))
            {
                ErrorMessage = "Password should contain At least one special case characters";
                return false;
            }
            else
            {
                return true;
            }
        }

        internal static bool isValidName(string nameInput)
        {
            bool isValid;
            if (string.IsNullOrEmpty(nameInput))
                isValid = false;
            else
            {
                //process 1
                isValid = Regex.IsMatch(nameInput, @"^[a-zA-Z]+$");

                //process 2
                foreach (char c in nameInput)
                {
                    if (!Char.IsLetter(c))
                        isValid = false;
                }

            }
            return isValid;
        }

        internal static bool isValidGender(string genderInput)
        {

            bool isValid;
            if(string.IsNullOrEmpty(genderInput))
                isValid = false;
            else
            {

                if (genderInput == "M" || genderInput == "F")
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                }
            }
            return isValid;

        }

        internal static bool isValidContact(string contactInput)
        {
            bool isValid;
            if (string.IsNullOrEmpty(contactInput))
                isValid = false;
            else
            {
                //process 1
                isValid = Regex.IsMatch(contactInput, "[7-9][0-9]{9}");
            }
            return isValid;
        }
    }
}
