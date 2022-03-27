using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {     

        static void Main(string[] args)
        {
            // Датский алфавит
            string pathDat = "C:\\Users\\37529\\Desktop\\Lab02\\Lab02\\TextFile1.txt";
            string regularDat = "[^a-zA-Zæøå]";
            string alphabetDat = "abcdefghijklmnopqrstuvwxyzæøå";

            Console.WriteLine("Danish");
            using (StreamReader sr = new StreamReader(pathDat))
            {
                Console.WriteLine("Entropia Shannon " + Shannon(GetText(pathDat, regularDat), alphabetDat));
                Console.WriteLine("Kolichestvo informatsii  " + KolvoInfoShannon(sr.ReadToEnd(), Shannon(GetText(pathDat, regularDat), alphabetDat)));
                Console.WriteLine("Entropia Hartley  " + Hartley(alphabetDat));
                Console.WriteLine("Kolichestvo informatsii  " + KolvoInfoHartley(sr.ReadToEnd(), Hartley(alphabetDat)));
            }

            // Казахский алфавит
            string pathKaz = "C:\\Users\\37529\\Desktop\\Lab02\\Lab02\\TextFile2.txt";
            string regularKaz = "[^а-яА-Яәғқңөұүһі]";
            string alphabetKaz = "аәбвгғдеёжзийкқлмнңоөпрстуұүфхһцчшщъыіьэюя";

            Console.WriteLine("Kazakh");
            using (StreamReader sr = new StreamReader(pathKaz))
            {
                Console.WriteLine("Entropia Shannon  " + Shannon(GetText(pathKaz, regularKaz), alphabetKaz));
                Console.WriteLine("Kolichestvo informatsii  " + KolvoInfoShannon(sr.ReadToEnd(), Shannon(GetText(pathKaz, regularKaz), alphabetKaz)));
                Console.WriteLine("Entropia Hartley  " + Hartley(alphabetKaz));
                Console.WriteLine("Kolichestvo informatsii  " + KolvoInfoHartley(sr.ReadToEnd(), Hartley(alphabetKaz)));
            }

            // Бинарный алфавит
            string regularByn = "[^10]";
            string pathByn = "C:\\Users\\37529\\Desktop\\Lab02\\Lab02\\TextFile3.txt";
            string alphabet10 = "10";

            using (StreamReader sr = new StreamReader(pathByn))
            {
                Console.WriteLine("Entropia Shannon  " + Shannon(GetText(pathByn, regularByn), alphabet10));
                Console.WriteLine("Kolichestvo informatsii  " + KolvoInfoShannon(sr.ReadToEnd(), Shannon(GetText(pathByn, regularByn), alphabet10)));
                Console.WriteLine("Entropia Hartley  " + Hartley(alphabet10));
                Console.WriteLine("Kolichestvo informatsii  " + KolvoInfoHartley(sr.ReadToEnd(), Hartley(alphabet10)));
            }

            // ФИО на английском
            string pathEng = "C:\\Users\\37529\\Desktop\\Lab02\\Lab02\\TextFile4.txt";
            string regularEng = "[^a-zA-Z]";
            string alphabetEng = "abcdefghijklmnopqrstuvwxyz";

            using (StreamReader sr = new StreamReader(pathEng))
            {
                Console.WriteLine("Entropia Shannon  " + Shannon(GetText(pathEng, regularEng), alphabetEng));
                Console.WriteLine("Kolichestvo informatsii  " + KolvoInfoShannon(sr.ReadToEnd(), Shannon(GetText(pathEng, regularEng), alphabetEng)));
                Console.WriteLine("Entropia Hartley  " + Hartley(alphabetEng));
                Console.WriteLine("Kolichestvo informatsii  " + KolvoInfoHartley(sr.ReadToEnd(), Hartley(alphabetEng)));
            }

            // ФИО в 
            Console.WriteLine(ToBinAscii("PochikockayaYuliaSergeevna"));
            Console.WriteLine("Entropia Shannon  " + Shannon(ToBinAscii("PochikockayaYuliaSergeevna"), alphabet10));
            Console.WriteLine("Kolichestvo informatsii  " + KolvoInfoShannon(ToBinAscii("PochikockayaYuliaSergeevna"), Shannon(ToBinAscii("PochikockayaYuliaSergeevna"), alphabet10)));

            Console.WriteLine(" 0.1 " + EfectiveEntropy(0.1));
            Console.WriteLine(" 0.5 " + EfectiveEntropy(0.5));
            Console.WriteLine(" 1 " + EfectiveEntropy(1));
        }

        static string GetText(string path, string RegExpr)
        {
            try
            {
                using (StreamReader sr = new StreamReader(path))
                {
                    string str;
                    str = Regex.Replace(sr.ReadToEnd(), RegExpr, "");
                    return str;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        static double Shannon(string text, string alphabet)
        {
            double shn = 0;
            for (int i = 0; i < alphabet.Length; i++)
            {
                int count = Regex.Matches(text, alphabet[i].ToString(), RegexOptions.IgnoreCase).Count;
                double p = (count == 0) ? 0 : (double)count / text.Length;
                if (p != 0)
                    shn += p * Math.Log(p);
                Console.WriteLine(alphabet[i].ToString() + "     " + p);
            }
            return -shn;
        }

        static double KolvoInfoShannon(string text, double shn)
        {
            return text.Length * shn;
        }

        static double Hartley(string alphabet)
        {
            return Math.Log(alphabet.Length);
        }

        static double KolvoInfoHartley(string text, double hrtl)
        {
            return text.Length * hrtl;
        }

        static string ToBinAscii(string text)
        {
            string str = "";
            byte[] arr = Encoding.ASCII.GetBytes(text);
            int[] b = arr.Select(i => (int)i).ToArray();
            foreach (int i in b)
                str += Convert.ToString(i, 2);
            return str;
        }

        static double EfectiveEntropy(double error)
        {
            double x=  1 - (-error * Math.Log(error) - (1 - error) * Math.Log((1 - error)));
            return x;
        }
    }
}
