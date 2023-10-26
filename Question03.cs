

using System;
using System.Text;
using System.Linq;

class PasswordGenerator
{
    static void Main(string[] args)
    {
        // Replace these values with your actual information
        string firstName = "Amna";
        string lastName = "Sajjad";
        string registrationNumber = "fa20-bcs-031";

        // Rule 1: Maximum length of 20
        int maxLength = 20;

        // Rule 2: At least 2 special characters
        string specialCharacters = "!@#$%^&*()_-+=<>?";

        // Rule 4: Initials of your first and last name
        string initials = (firstName[0].ToString() + lastName[0].ToString()).ToUpper();

        // Rule 5: Last two digits of your registration number
        string lastTwoDigits = new string(registrationNumber.Where(char.IsDigit).ToArray());
        lastTwoDigits = lastTwoDigits.Substring(Math.Max(0, lastTwoDigits.Length - 2));

        // Rule 3: At least 4 numbers (2 of them from your registration number)
        int remainingNumbers = 4 - lastTwoDigits.Length;
        string numbers = lastTwoDigits + "12" + new string('0', remainingNumbers);

        // Create a StringBuilder to build the password
        StringBuilder password = new StringBuilder();

        // Add the initials
        password.Append(initials);

        // Add 2 special characters
        Random random = new Random();
        for (int i = 0; i < 2; i++)
        {
            password.Append(specialCharacters[random.Next(specialCharacters.Length)]);
        }

        // Shuffle the numbers to ensure randomness
        numbers = new string(numbers.OrderBy(c => random.Next()).ToArray());

        // Add the numbers
        password.Append(numbers);

        // Generate the remaining part of the password with random characters
        int remainingLength = maxLength - password.Length;
        for (int i = 0; i < remainingLength; i++)
        {
            password.Append(specialCharacters[random.Next(specialCharacters.Length)]);
        }

        // Shuffle the password to make it more secure
        string shuffledPassword = ShufflePassword(password.ToString());

        Console.WriteLine("Generated Password: " + shuffledPassword);
    }

    // Function to shuffle the characters in the password
    static string ShufflePassword(string password)
    {
        char[] passwordArray = password.ToCharArray();
        Random random = new Random();
        for (int i = 0; i < passwordArray.Length; i++)
        {
            int j = random.Next(i, passwordArray.Length);
            char temp = passwordArray[i];
            passwordArray[i] = passwordArray[j];
            passwordArray[j] = temp;
        }
        return new string(passwordArray);
    }
}
