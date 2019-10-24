using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Crypto
{
    class Program
    {
        static void Main(string[] args)
        {
            int n; string vigenereKey;
            List<string> texts;

            using (var rdr = new StreamReader("input.txt"))
            {
                n = int.Parse(rdr.ReadLine());
                vigenereKey = rdr.ReadLine();
                texts = rdr.ReadToEnd().Split(Environment.NewLine).ToList();
            }

            var caesar = new CaesarCrypt();
            var nCypher = new NCrypt();
            var vigenere = new VigenereCrypt();

            var caesarOut = new StreamWriter("CaesarOut.txt");
            var nOut = new StreamWriter("NOut.txt");
            var vigenereOut = new StreamWriter("VigenereOut.txt");

            foreach (var element in texts)
            {
                caesarOut.WriteLine($"{element}->{caesar.Encrypt(element)}->{caesar.Decrypt(caesar.Encrypt(element))}");
                nOut.WriteLine($"{element}->{nCypher.Encrypt(element, n)}->{nCypher.Decrypt(nCypher.Encrypt(element, n), n)}");
                vigenereOut.WriteLine($"{element}->{vigenere.Encrypt(element, vigenereKey)}->{vigenere.Decrypt(vigenere.Encrypt(element, vigenereKey), vigenereKey)}");
            }

            caesarOut.Flush();
            caesarOut.Close();
            nOut.Flush();
            nOut.Close();
            vigenereOut.Flush();
            vigenereOut.Close();
        }
    }
}
