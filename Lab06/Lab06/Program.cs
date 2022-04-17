using System;

namespace Lab06
{
    class Program
    {
        static void Main()
        {
            Enigma enigma = new Enigma();
            string encoded = enigma.Crypt("POCHIKOVSKAYAYULIASERGEEVNA", 2, 0, 2);
            Console.WriteLine(encoded);
            Console.WriteLine(enigma.Crypt(encoded, 2, 0, 2)); 
        }
    }
}
