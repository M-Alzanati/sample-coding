using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Example.CodingTask.Utilities.Helper
{
    public class HashService : IHashService
    {
        private readonly byte[] _salt;

        public HashService(string salt)
        {
            _salt = Encoding.UTF8.GetBytes(salt);
        }

        public Task<string> HashText(string plainText)
        {
            using var sha512 = new SHA512Managed();

            var bytesOfText = Encoding.UTF8.GetBytes(plainText);

            var saltedValue = new byte[bytesOfText.Length + _salt.Length];

            bytesOfText.CopyTo(saltedValue, 0);
            _salt.CopyTo(saltedValue, bytesOfText.Length);

            var result = sha512.ComputeHash(saltedValue);

            return Task.FromResult(Convert.ToBase64String(result));
        }
    }
}
