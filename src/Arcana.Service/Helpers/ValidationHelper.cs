using System.Text.RegularExpressions;

namespace Arcana.Service.Helpers;

public static class ValidationHelper
{
    public static bool IsPasswordHard(string password)
    {
        // Check if the password is at least 8 characters long
        if (password.Length < 8) return false;

        // Check if the password contains at least one uppercase letter
        if (!password.Any(char.IsUpper)) return false;

        // Check if the password contains at least one lowercase letter
        if (!password.Any(char.IsLower)) return false;

        // Check if the password contains at least one digit
        if (!password.Any(char.IsDigit)) return false;

        return true;
    }

    public static bool IsPhoneValid(string phone)
    {
        string pattern = @"^\+998\d{9}$";

        return Regex.IsMatch(phone, pattern);
    }

    public static bool IsEmailValid(string email)
    {
        string pattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";

        return Regex.IsMatch(email, pattern);
    }
}
