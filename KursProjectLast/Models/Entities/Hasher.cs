using System.Text;
using XSystem.Security.Cryptography;

namespace KursProjectLast.Models.Entities
{
    public static class Hasher
    {
        public static string HashPassword(string text)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(text);
            SHA256Managed hashstring = new SHA256Managed();
            byte[] hash = hashstring.ComputeHash(bytes);
            string hashString = string.Empty;
            foreach (byte x in hash)
            {
                hashString += String.Format("{0:x2}", x);
            }
            return hashString;
        }
    }
}
