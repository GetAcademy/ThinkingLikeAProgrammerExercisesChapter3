using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThinkingLikeAProgrammerExercisesChapter3
{
    class Program
    {
        static void Main(string[] args)
        {
            bool encrypt = args[0] == "e";
            Exercise4(encrypt, args[1]);
            //Exercise3();
        }

        private static void Exercise4(bool encrypt, string plaintext)
        {
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
            var code = "QWERTYUIOPÅÆØLKJHGFDSAZXCVBNM";
            var ciphertext = Encrypt(plaintext, 
                encrypt ? alphabet : code, 
                encrypt ? code : alphabet);
            Console.WriteLine(ciphertext);
            //plaintext = Decrypt(ciphertext);
        }

        private static string Encrypt(string plaintext, string alphabet, string code)
        {
            var ciphertext = "";
            for (int i = 0; i < plaintext.Length; i++)
            {
                ciphertext += EncryptChar(plaintext[i], alphabet, code);
            }

            return ciphertext;
        }

        private static char EncryptChar(char c, string alphabet, string code)
        {
            for (int i = 0; i < alphabet.Length; i++)
            {
                if (alphabet[i] == char.ToUpper(c))
                {
                    return code[i];
                }
            }
            return c;
        }

        private static void Exercise3()
        {
            int[] numbers = { 1, 2, 3, 2, 5, 7, 8 };
            foreach (var number in numbers) Console.Write(number + " ");
            Console.WriteLine($"sortert = {IsSorted(numbers)}");
            numbers = new[] { 1, 2, 3, 5, 7, 8 };
            foreach (var number in numbers) Console.Write(number + " ");
            Console.WriteLine($"sortert = {IsSorted(numbers)}");
        }

        private static bool IsSorted(int[] numbers)
        {
            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < numbers[i - 1]) return false;
            }
            return true;
        }

        private static bool IsSorted2(int[] numbers)
        {
            return !numbers.Where((t, i) => t < numbers[i - 1]).Any();
        }
    }
}
