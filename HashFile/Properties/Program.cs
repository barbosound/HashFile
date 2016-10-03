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

            Console.WriteLine("Quin arxiu vols encriptar? Posa la ruta.");

            String arxiu = Console.ReadLine();

            arxiu = File.ReadAllText(arxiu);

            byte[] bytesArxiu = UTF8Encoding.UTF8.GetBytes(arxiu);

            byte[] hashResultat = SHA512.ComputeHash(bytesArxiu);

            Console.WriteLine("Selecciona el arxiu hash a comparar, posa la ruta:");

            String hash = Console.ReadLine();

            hash = File.ReadAllText(hash);

            if(arxiu == hash)
            {
                Console.WriteLine("Els arxius coincideixen!!");

            }
            else
            {
                Console.WriteLine("No coincideixen!!");
            }

        }
    }
}
