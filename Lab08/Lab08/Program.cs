using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab8
{
    class Program
    {
        public static readonly int n = 253; //11 23
        public static readonly int x = 5;
        public static readonly int length = 13;

        public static int BBSnext(int prev, int index)
        {
            int res = (prev * prev) % n;
            Console.WriteLine($"x{index} = ({prev}*{prev})mod {n} = {res}");
            return res;
        }

        static void Main(string[] args)
        {
            //---------- B B S ----------------

            int[] seq = new int[length];

            Console.WriteLine($"n = {n} (число Блюма)");
            Console.WriteLine($"x = {x}\n");
            int buf = x;

            long OldTicks = DateTime.Now.Ticks;
            for (int i = 0; i < length; i++)
            {
                buf = BBSnext(buf, i);
                seq[i] = buf;
            }
            Console.Write("\nПСП = ");
            foreach (int item in seq)
            {
                Console.Write($"{item}; ");
            }
            Console.WriteLine($"\nВремя зашифрования: {(DateTime.Now.Ticks - OldTicks) / 1000} мс");



            //----------- R C 4 ---------------

            Console.WriteLine("\n\n\n ----------- R C 4 ---------------\n");

            int[] ikey = { 1, 11, 21, 31, 41, 51 };
            byte[] key = new byte[ikey.Length];

            for (int i = 0; i < ikey.Length; i++)
            {
                key[i] = Convert.ToByte(ikey[i]);
            }

            RC4 rc = new RC4(key);
            RC4 rc2 = new RC4(key);
            byte[] testBytes = ASCIIEncoding.ASCII.GetBytes("Pochikovskaya Yulia");


            byte[] encrypted = rc.Encode(testBytes, testBytes.Length);
            Console.WriteLine($"Зашифрованнная строка : {ASCIIEncoding.ASCII.GetString(encrypted)}");


            byte[] decrypted = rc2.Encode(encrypted, encrypted.Length);
            Console.WriteLine($"Рашифрованнная строка : {ASCIIEncoding.ASCII.GetString(decrypted)}");

            Console.ReadKey();
        }
    }
}
