using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab05
{
    class Program
    {
        static void Main(string[] args)
        {

            RoutePerm route = new RoutePerm();
            Console.OutputEncoding = Encoding.Unicode;

            //encrypt
            int key = 6;
            String msg = "";

            long OldTicks = DateTime.Now.Ticks;

            using (StreamReader sr = new StreamReader("in.txt"))
            {
                msg = (sr.ReadToEnd());
                msg = msg.Replace(" ", "");
            }


            string result_route = route.Encrypt(msg, key);

            Console.WriteLine("\nИсходный текст:  " + msg);
            Console.WriteLine("Маршрутный шифр: " + result_route);
            Console.WriteLine("Расшифров текст: " + route.Decrypt(result_route, key));

            long time_cipher = (DateTime.Now.Ticks - OldTicks) / 1000;
            Console.WriteLine("Затрачено " + time_cipher + " мс\n\n\n\n");
            route.BuildExcel();


            MultiplePerm multiple = new MultiplePerm();
            int[] key1 = { 0, 3, 2, 1 };
            int[] key2 = { 8, 3, 7, 5, 1, 2, 0, 4, 6 };
            OldTicks = DateTime.Now.Ticks;

            string result_multiple = multiple.Encrypt(msg, key1, key2);

            Console.WriteLine("Исходный текст:  " + msg);
            Console.WriteLine("Множеств шифр:   " + result_multiple);
            Console.WriteLine("Расшифров текст: " + multiple.Decrypt(result_multiple, key2, key1));

            time_cipher = (DateTime.Now.Ticks - OldTicks) / 1000;
            Console.WriteLine("Затрачено " + time_cipher + " мс");          


            Console.ReadKey();
        }
    }
}
