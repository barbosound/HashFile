using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace HashFile
{
    class Program
    {
        static void Main(string[] args)
        {
            String contingut = File.ReadAllText(@"C:\Users\pau\Documents\text.txt");

            byte[] bytesIn = UTF8Encoding.UTF8.GetBytes(contingut);

            SHA512Managed SHA512 = new SHA512Managed();

            byte[] hashResult = SHA512.ComputeHash(bytesIn);

            String textOut = BitConverter.ToString(hashResult, 0);

            File.WriteAllText(@"C:\Users\pau\Documents\texthash.txt", textOut);
        }
    }
}
