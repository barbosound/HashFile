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


            string ruta;
            string arxiu;

            Console.WriteLine("     MENÚ");
            Console.WriteLine("[1]GENERAR HASH");
            Console.WriteLine("[2]COMPARAR HASH");

            string opcio = Console.ReadLine();

            if(opcio == "1")
            {

                Console.WriteLine("De quin arxiu vols fer el HASH");

                ruta = Console.ReadLine();

                String contingut = File.ReadAllText(ruta);

                byte[] bytesIn = UTF8Encoding.UTF8.GetBytes(contingut);

                SHA512Managed SHA512 = new SHA512Managed();

                byte[] hashResult = SHA512.ComputeHash(bytesIn);

                String textOut = BitConverter.ToString(hashResult, 0);

                File.WriteAllText(@ruta+".hash", textOut);

                Console.WriteLine("Hash creat");

                Console.ReadKey();

            }
            if(opcio == "2")
            {

                Console.WriteLine("Quin arxiu vols encriptar?");

                ruta = Console.ReadLine();
               
                arxiu = File.ReadAllText(ruta); 
                               
                byte[] bytesArxiu = UTF8Encoding.UTF8.GetBytes(arxiu);

                SHA512Managed SHA512 = new SHA512Managed();

                byte[] hashResultat = SHA512.ComputeHash(bytesArxiu);

                String resultat = BitConverter.ToString(hashResultat, 0);

                arxiu = resultat;

                Console.WriteLine("Selecciona el arxiu hash a comparar.");

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
