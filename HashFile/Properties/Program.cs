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

            int opcio;
            String ruta;
            String arxiu;

            Console.WriteLine("     MENÚ");
            Console.WriteLine("[1]GENERAR HASH");
            Console.WriteLine("[2]COMPARAR HASH");

            opcio = Console.Read();

            if(opcio == '1')
            {
                String contingut = File.ReadAllText(@"C:\Users\pau\Documents\text.txt");

                byte[] bytesIn = UTF8Encoding.UTF8.GetBytes(contingut);

                SHA512Managed SHA512 = new SHA512Managed();

                byte[] hashResult = SHA512.ComputeHash(bytesIn);

                String textOut = BitConverter.ToString(hashResult, 0);

                File.WriteAllText(@"C:\Users\pau\Documents\texthash.txt", textOut);

            }
            if(opcio == '2')
            {

                Console.WriteLine("Quin arxiu vols encriptar? Posa la ruta.");

                ruta = Console.ReadLine();

                arxiu = File.ReadAllText(@ruta);

                byte[] bytesArxiu = UTF8Encoding.UTF8.GetBytes(arxiu);

                SHA512Managed SHA512 = new SHA512Managed();

                byte[] hashResultat = SHA512.ComputeHash(bytesArxiu);

                String resultat = BitConverter.ToString(hashResultat, 0);

                arxiu = resultat;

                Console.WriteLine("Selecciona el arxiu hash a comparar, posa la ruta:");

                String hash = Console.ReadLine();

                hash = File.ReadAllText(hash);

                if (arxiu == hash)
                {
                    Console.WriteLine("Els arxius coincideixen!!");
                    Console.ReadKey();

                }
                else
                {
                    Console.WriteLine("No coincideixen!!");
                    Console.ReadKey();
                }

            }         
        }
    }
}
