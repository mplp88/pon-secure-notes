using Microsoft.Extensions.Options;
using Pon.SecureNotes.Application.Interfaces.Services;
using Pon.SecureNotes.Application.Options;
using System.Security.Cryptography;
using System.Text;

namespace Pon.SecureNotes.Application.Services
{
    public class CryptoService(IOptions<CryptoOptions> options) : ICryptoService
    {
        private readonly byte[] _key = Convert.FromBase64String(options.Value.CryptoKey);

        public string Decrypt(string cipherText)
        {
            var full = Convert.FromBase64String(cipherText);
            var iv = full.Take(16).ToArray();
            var cipher = full.Skip(16).ToArray();

            using var aes = Aes.Create();
            aes.Key = _key;
            aes.IV = iv;

            var decryptor = aes.CreateDecryptor();
            var bytes = decryptor.TransformFinalBlock(cipher, 0, cipher.Length);

            return Encoding.UTF8.GetString(bytes);
        }

        public string Encrypt(string plainText)
        {
            using var aes = Aes.Create();
            aes.Key = _key;
            aes.GenerateIV();

            var encryptor = aes.CreateEncryptor();
            var bytes = Encoding.UTF8.GetBytes(plainText);
            var cipher = encryptor.TransformFinalBlock(bytes, 0, bytes.Length);

            return Convert.ToBase64String(aes.IV.Concat(cipher).ToArray());
        }
    }
}
