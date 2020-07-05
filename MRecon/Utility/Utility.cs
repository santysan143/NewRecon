using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.UtilityStructure;

namespace Utility
{
    public static class Utility
    {
        public static string Encrypt(string Value)
        {
            return Encryption.EncryptString(Value);
        }
        public static string Decrypt(string Value)
        {
            return Decryption.DecryptString(Value);
        }
    }
}
