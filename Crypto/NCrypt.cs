using System;
using System.Collections.Generic;
using System.Text;

namespace Crypto
{
    public class NCrypt
    {
        public string Encrypt(string text, int n)
        {
            var chars = text.ToCharArray();

            for (var i = 0; i < chars.Length; i++)
            {

                chars[i] = (char)(chars[i] + n);
            }

            return new string(chars);
        }

        public string Decrypt(string text, int n)
        {
            var chars = text.ToCharArray();

            for (var i = 0; i < chars.Length; i++)
            {
                chars[i] = (char)(chars[i] - n);
            }

            return new string(chars);
        }
    }
}
