using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_work_1
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
            int countKey = key.Length;
            int countLines = Convert.ToInt32(Math.Ceiling((double)sequence.Length / countKey));
            int countMessage = 0;
            char[,] charSimbols = new char[countLines, countKey];
            string keyOrder = String.Concat(key.OrderBy(ch => ch));
            string message = null;
            int[] indexes = new int[countKey];
            for (int i = 0; i < countKey; i++)
            {
                indexes[i] = keyOrder.IndexOf(key[i]);
                keyOrder = keyOrder.Remove(indexes[i], 1).Insert(indexes[i], ' '.ToString());
            }

            for (int i = 0; i < countLines; i++)
            {
                for (int j = 0; j < countKey; j++)
                {
                    if (countMessage < sequence.Length)
                    {
                        charSimbols[i, indexes[j]] = sequence[countMessage];
                        countMessage++;
                    }
                }
            }
            //Создание блока сообщения
            Console.WriteLine("Блок сообщения");
            for (int i = 0; i < countLines; i++)
            {
                for (int j = 0; j < countKey; j++)
                {

                    Console.Write(charSimbols[i, j]);
                }
                Console.WriteLine();
            }
            //создание зашифрованного сообщения
            for (int i = 0; i < countKey; i++)
            {
                for (int j = 0; j < countLines; j++)
                {
                    message += Convert.ToString(charSimbols[j, i]);
                    countMessage++;

                }
            }
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
            int countKey = key.Length;
            int countLines = Convert.ToInt32(Math.Ceiling((double)sequence.Length / countKey));
            int countMessage = 0;
            char[,] charSimbols = new char[countLines, countKey];
            string keyOrder = String.Concat(key.OrderBy(ch => ch));
            string message = null;
            int[] indexes = new int[countKey];
            for (int i = 0; i < countKey; i++)
            {
                indexes[i] = key.IndexOf(keyOrder[i]);
                key = key.Remove(indexes[i], 1).Insert(indexes[i], ' '.ToString());
            }
            for (int j = 0; j < countKey; j++)
            {
                for (int i = 0; i < countLines; i++)
                {

                    if (countMessage < sequence.Length)
                    {
                        charSimbols[i, indexes[j]] = sequence[countMessage];
                        countMessage++;
                    }
                }
            }

            //Создание блока сообщения
            Console.WriteLine("Блок сообщения");
            for (int i = 0; i < countLines; i++)
            {
                for (int j = 0; j < countKey; j++)
                {

                    Console.Write(charSimbols[i, j]);
                }
                Console.WriteLine();
            }

            //создание расшифрованного сообщения
            for (int i = 0; i < countLines; i++)
            {
                for (int j = 0; j < countKey; j++)
                {
                    message += Convert.ToString(charSimbols[i, j]);
                    countMessage++;

                }
            }
            Console.WriteLine("Зашифрованное сообщение");
            Console.WriteLine(message);

            return message;

        }
    }
}
