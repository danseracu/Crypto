using System;
using System.Collections.Generic;
using System.Text;

namespace Crypto
{
    public class CaesarCrypt
    {
        public string Decrypt(string text)
        {
            var chars = text.ToCharArray();

            for(var i = 0; i < chars.Length; i++)
            {
                if (!char.IsLetter(chars[i]))
                {
                    continue;

                }
                chars[i] = (char)(chars[i] - 3);
            }

            return new string(chars);
        }

        public string Encrypt(string text)
        {
            var chars = text.ToCharArray();

            for (var i = 0; i < chars.Length; i++)
            {
                if (!char.IsLetter(chars[i]))
                {
                    continue;

                }
                chars[i] = (char)(chars[i] + 3);
            }

            return new string(chars);
        }
    }
}
