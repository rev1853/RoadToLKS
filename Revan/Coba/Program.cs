using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coba
{
    class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("--- zona kucing ---");
            var kucingJawa = new Kucing();
            kucingJawa.Makan();
            kucingJawa.Bersuara();
            Console.WriteLine("--- zona kucing ---\n");

            Console.WriteLine("--- zona kambing ---");
            var kambingJawa = new Kambing();
            kambingJawa.Makan();
            kambingJawa.Bersuara();
            Console.WriteLine("--- zona kambing ---\n");

            if (kambingJawa is IHewan hewan)
            {
                hewan.Bersuara();
            }

            // supaya bisa kelihatan hasilnya
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            while (keyInfo.Key != ConsoleKey.Enter)
                keyInfo = Console.ReadKey();
        }
    }

    interface IHewan
    {
        void Makan();
        void Bersuara();
    }

    class Kucing : IHewan
    {
        public void Bersuara()
        {
            Console.WriteLine("Meongg");
        }

        public void Makan()
        {
            Console.WriteLine("Meong sedang makan");
        }
    }

    class Kambing : IHewan
    {
        public void Makan()
        {
            Console.WriteLine("Mbekk, Saya sedang makan");
        }

        public void Bersuara()
        {
            Console.WriteLine("Mbekk mbekk");
        }
    }
}
