using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab05
{
    internal class MultiplePerm
    {
        static char[] characters = new char[] {'a','ą','b','c','ć','d','e','ę','f','g','h','i','j','k',
                                               'l','ł','m','n','ń','o','ó','p','r','s','ś','t','u','w',
                                               'y','z','ź','ż'};

        public string Encrypt(string msg, int[] key1, int[] key2)
        {
            string result = string.Empty;
            string[] msgInArray = new string[(msg.Length / key1.Length) + 1];

            for (int i = 0; i < (msg.Length / key1.Length) + 1; i++)
            {
                if (msg.Length - i * key1.Length <= key1.Length)
                {
                    msgInArray[i] = msg.Substring(i * key1.Length);
                    Console.WriteLine("msgInArray[" + i + "] = " + msgInArray[i]);
                    break;
                }
                else
                {
                    msgInArray[i] = msg.Substring(i * key1.Length, key1.Length);
                    Console.WriteLine("msgInArray[" + i + "] = " + msgInArray[i]);
                }
            }
            char[,] res = new char[key1.Length, key2.Length];

            for (int i = 0; i < key1.Length; i++)
                for (int k = 0; k < key2.Length; k++)
                {
                    //if (msgInArray[k].Length <= i && k==key2.Length-1) continue;
                    res[key1[i], key2[k]] = msgInArray[k][i];
                }

            for (int i = 0; i < key1.Length; i++)
                for (int k = 0; k < key2.Length; k++)
                {
                    result += res[i, k];
                }
            result = result.Replace("\0", "");
            return result;
        }


        public string Decrypt(string msg, int[] key1, int[] key2)
        {

            string result = string.Empty;
            string[] msgInArray = new string[(msg.Length / key1.Length) + 1];


            for (int i = 0; i < (msg.Length / key1.Length) + 1; i++)
            {
                if (msg.Length - i * key1.Length <= key1.Length)
                {
                    msgInArray[i] = msg.Substring(i * key1.Length);
                    break;
                }
                else
                {
                    msgInArray[i] = msg.Substring(i * key1.Length, key1.Length);
                }
            }
            char[,] res = new char[key1.Length, key2.Length];


            for (int i = 0; i < key1.Length; i++)
                for (int k = 0; k < key2.Length; k++)
                {
                    res[i, k] = msgInArray[key2[k]][key1[i]];
                }

            for (int i = 0; i < key1.Length; i++)
                for (int k = 0; k < key2.Length; k++)
                {
                    result += res[i, k];
                }

            result = result.Replace("\0", "");
            return result;
        }
    }
}
