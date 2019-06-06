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
            //Exercise6();
            //Exercise4and5(args[0] == "e", args[1]);
            Exercise3();
        }

        private static void Exercise6()
        {
            var alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZÆØÅ";
            var code = CreateCode(alphabet);
            Console.WriteLine(code);
        }

        private static string CreateCode(string alphabet)
        {
            var code = alphabet.ToCharArray();
            var random = new Random();
            for (int index1 = 0; index1 < alphabet.Length; index1++)
            {
                int randomIndex2;
                int avoidIndex2;
                do
                {
                    var randomChar1 = code[index1];
                    var avoidIndex1 = alphabet.IndexOf(randomChar1);
                    randomIndex2 = random.Next(0, alphabet.Length - 1);
                    if (randomIndex2 >= avoidIndex1) randomIndex2++;
                    var randomChar2 = code[randomIndex2];
                    avoidIndex2 = alphabet.IndexOf(randomChar2);
                } while (avoidIndex2 == index1);
                var tmp = code[index1];
                code[index1] = code[randomIndex2];
                code[randomIndex2] = tmp;
            }

            return new string(code);
        }

        private static void Exercise4and5(bool encrypt, string plaintext)
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
            for (int i = 1; i < numbers.Length; i++)
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
