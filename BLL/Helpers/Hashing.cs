using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Helpers
{
    public static class Hashing
    {
        // Создание соли для хэширования
        public static byte[] GenerateSalt()
        {
            return Encoding.UTF8.GetBytes("Nik");
        }
        // Хэширование пароля
        public static string HashPassword(string password, byte[] salt) {

            byte[] passwordBytes = Encoding.UTF8.GetBytes(password);
            byte[] hashPassword = new byte[password.Length+salt.Length];
            for (int i = 0; i < passwordBytes.Length; i++)
                hashPassword[i] = passwordBytes[i];
            for (int i=0; i<salt.Length; i++ )
                hashPassword[passwordBytes.Length + i] = salt[i];
            var builder = new StringBuilder(hashPassword.Length);
            for (int i=0; i<hashPassword.Length; i++)
                builder.Append(hashPassword[i].ToString("X2"));
            return builder.ToString();
        }
        

    }
}
