using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_work_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите последовательность для шифрования:");
            string sequence = Console.ReadLine();
            Console.WriteLine("Введите ключ-слово:");
            string key = Console.ReadLine();
            //Шифрование
            EncryptionMessage message = new EncryptionMessage(sequence, key);
            string sequenceDecrypt = message.Encrypt();
            DecryptionMessage messageDecr = new DecryptionMessage(sequenceDecrypt, key);
            string messageNormal = messageDecr.Decrypt();

            Console.ReadKey();
        }
    }

    //Шифратор
    class EncryptionMessage
    {
        string sequence { get; set; }
        string key { get; set; }

        public EncryptionMessage(string sequence, string key)
        {
            //Вырезание пробелов из последовательности
            this.sequence = sequence.Replace(" ", ""); ;
            this.key = key;
        }
        public string Encrypt()
        {
            string alphabet = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
            string keyReady = null;
            string message = null;
            int indexSymbol = 0;
            int indexAlphabet = 0;
            int indexSequence = 0;
            int indexKey = 0;
            int indexNewSequence = 0;
            int indexEncrypt = 0;
            for (int i = 0; i < sequence.Length; i++)
            {
                if (indexSymbol >= key.Length) indexSymbol = 0;
                keyReady += Convert.ToString(key[indexSymbol]);
                indexSymbol++;
            }
            for (int i = 0; i < sequence.Length; i++)
            {
                if (indexAlphabet >= alphabet.Length) indexAlphabet = 0;
                indexSequence = alphabet.IndexOf(sequence[i]);
                indexKey = alphabet.IndexOf(key[i]);
                indexEncrypt = (indexSequence + indexKey + 2) % alphabet.Length;
                for (int j = 0; j < alphabet.Length; j++)
                {
                    if (indexSymbol >= key.Length) indexSymbol = 0;
                    keyReady += Convert.ToString(key[indexSymbol]);
                    indexSymbol++;
                }
                indexNewSequence = alphabet[indexKey + indexSequence];
                indexAlphabet++;
            }


            Console.WriteLine(keyReady);
            Console.WriteLine(sequence);
            Console.WriteLine("Зашифрованное сообщение");
            Console.WriteLine(message);
            return message;
        }
    }


    //Дешифратор
    class DecryptionMessage
    {
        string sequence { get; set; }
        string key { get; set; }

        public DecryptionMessage(string sequence, string key)
        {
            this.sequence = sequence;
            this.key = key;
        }
        public string Decrypt()
        {
            char[] alphabet = new char[33] {'А', 'Б', 'В', 'Г', 'Д', 'Е', 'Ё','Ж', 'З', 'И', 'Й', 'К', 'Л', 'М', 'Н', 'О',
                                            'П', 'Р', 'С', 'Т', 'У', 'Ф', 'Х', 'Ц', 'Ч', 'Ш', 'Щ', 'Ъ', 'Ы', 'Ь', 'Э', 'Ю', 'Я'};
            string message = null;
            Console.WriteLine("Зашифрованное сообщение");
            Console.WriteLine(message);
            return message;
        }
    }
}
