using System;
using System.Collections.Generic;
using System.Text;

namespace Crypto
{
    public class VigenereCrypt
    {
        public string Encrypt(string text, string password)
        {
            var chars = text.ToCharArray();
            var permutations = GetPermutations();

            for (int i = 0; i < chars.Length; i++)
            {
                if (!char.IsLetter(chars[i]))
                {
                    continue;
                }

                var linie = password[i % password.Length];
                var original = ShiftLetter(chars[i], -(linie - 'a'));

                if (char.IsUpper(chars[i]))
                {
                    chars[i] = char.ToUpper(original);
                }
                else
                {
                    chars[i] = original;
                }
            }

            return new string(chars);
        }

        public string Decrypt(string text, string password)
        {
            var chars = text.ToCharArray();
            var permutations = GetPermutations();

            for (int i = 0; i < chars.Length; i++)
            {
                if (!char.IsLetter(chars[i]))
                {
                    continue;
                }

                var linie = password[i % password.Length];
                var coloana = char.ToLower(chars[i]);

                if (char.IsUpper(chars[i]))
                {
                    chars[i] = char.ToUpper(permutations[linie - 'a', coloana - 'a']);
                }
                else
                {
                    chars[i] = permutations[linie - 'a', coloana - 'a'];
                }
            }

            return new string(chars);
        }

        private char[,] GetPermutations()
        {
            char[,] perm = new char[26, 26];
            for (int i = 0; i < perm.GetLength(1); i++)
                perm[0, i] = (char)('a' + i);
            for (int i = 1; i < perm.GetLength(0); i++)
                for (int j = 0; j < perm.GetLength(1); j++)
                {
                    perm[i, j] = ShiftLetter(perm[i - 1, j], 1);

                }
            return perm;
        }

        private char ShiftLetter(char c, int s)
        {
            s = s % 26;
            if (s < 0)
                s = 26 + s;
            char a;
            if (char.IsUpper(c))
                a = 'A';
            else
                a = 'a';

            return (char)(a + (c - a + s) % 26);
        }


    }
}
