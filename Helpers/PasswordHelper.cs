using System;
using System.Text;

namespace AuthorsBooksApp.Helpers
{
    public static class PasswordHelper
    {

        public static bool IsPasswordValid(string password, string storedHash)
        {
            if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(storedHash))
            {
                return false;
            }

            string passwordHash = Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
            return passwordHash == storedHash;
        }

        public static string HashPassword(string password)
        {
            if (string.IsNullOrEmpty(password))
            {
                throw new ArgumentException("Password cannot be null or empty.", nameof(password));
            }
            return Convert.ToBase64String(Encoding.UTF8.GetBytes(password));
        }
    }
}