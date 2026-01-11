using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pon.SecureNotes.Application.Interfaces.Services
{
    public interface ICryptoService
    {
        public string Encrypt(string plainText);
        public string Decrypt(string cipherText);
    }
}
