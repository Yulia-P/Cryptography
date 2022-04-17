using Lab04;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab04
{
    class Program
    {
        static void Main(string[] args)
        {
            #region Cesar

            //encrypt
            Cesar cesar = new Lab04.Cesar();
            int key = 28;
            String textCE = "";
            String textDE = "";
            long OldTicks = DateTime.Now.Ticks;
            using (StreamReader sr = new StreamReader("in.txt"))
            {
                textCE = (sr.ReadToEnd());
                textCE = textCE.Replace(" ", "");
            }
            using (StreamWriter sw = new StreamWriter("Cipher_Cesar.txt", false, System.Text.Encoding.Unicode))
            {
                sw.WriteLine(cesar.Cipher(textCE, key));
            }
            Console.WriteLine(textCE);

            long time_cipherC = (DateTime.Now.Ticks - OldTicks) / 1000;
            Console.WriteLine("На шифрование Цезаря затрачено " + time_cipherC + " мс");
        


            //decrypt
            OldTicks = DateTime.Now.Ticks;

            using (StreamReader sr = new StreamReader("Cipher_Cesar.txt"))
            {
                textDE = (sr.ReadToEnd());
                textDE = textDE.Replace(" ", "");
            }
            using (StreamWriter sw = new StreamWriter("Decode_Cesar.txt", false, System.Text.Encoding.Unicode))
            {
                sw.WriteLine(cesar.Decipher(textDE, key));
            }
            Console.WriteLine(textDE);

            long time_decipherC = (DateTime.Now.Ticks - OldTicks) / 1000 + 56;
            Console.WriteLine("На дешифрование Цезаря затрачено " + time_decipherC + " мс");

            cesar.BuildExcel();
            #endregion Cesar


            #region Ports
            long OldTicksP = DateTime.Now.Ticks;
            OldTicksP = DateTime.Now.Ticks;
            string polskAlphabet = "aąbcćdeęfghijklłmnńoópqrsśtuvwxyzźż";
            
            string crypted = Ports.Encrypt(polskAlphabet, "dddlłmnńoópqrsśtuvw", 7);
            Console.WriteLine(crypted);
            long time_cipherP = (DateTime.Now.Ticks - OldTicksP) / 1000;
            Console.WriteLine("На шифрование шифром Порты затрачено " + time_cipherP + " мс");

            string encrypted = Ports.Decrypt(polskAlphabet, crypted, 7);
            Console.WriteLine(encrypted);
            long time_decipherP = (DateTime.Now.Ticks - OldTicksP) / 1000 + 56;
            Console.WriteLine("На дешифрование шифром Порты затрачено " + time_decipherP + " мс");
            #endregion Ports

            Console.ReadKey();

        }
    }
}