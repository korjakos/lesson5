using System;
using System.Text;

namespace ex2
{
    static class Message
    {
        static public string text;

        static Message()
        {
            text = "Разнообразный и богатый опыт консультация с широким активом обеспечивает широкому кругу.  ";
        }

        //а) Вывести только те слова сообщения, которые содержат не более n букв.
        static public void GetWordsByLength(int len)
        {
            string[] words = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            Console.WriteLine("Вывод слов, длинной не более " + len + ": " );
            foreach (string word in words)
            {
                if (word == "")
                    continue;
                if (word.Length <= len)
                    Console.Write(word + " ");
            }
        }

        //в) Найти самое длинное слово сообщения.
        static public string FindMaxLengthWord()
        {
            string[] words = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            string maxWord = words[0];
            int max = words[0].Length;

            foreach (string word in words)
            {
                if (word.Length > max)
                {
                    max = word.Length;
                    maxWord = word;
                }
            }
            return maxWord;
        }

        //г) Сформировать строку с помощью StringBuilder из самых длинных слов сообщения.
        static public StringBuilder GetLongWordsString()
        {
            string[] words = text.Split(new Char[] { ' ', ',', '.', '-', '\n', '\t' });
            StringBuilder result = new StringBuilder();
            int max = Message.FindMaxLengthWord().Length;
            foreach (string word in words)
            {
                if (word.Length == max)
                {
                    result.Append(word.ToLower() + " ");
                }
            }
            return result;
        }
        static void Main(string[] args)
        {

            Console.WriteLine("\nИмеется следующий текст: \n" + Message.text);

            Console.WriteLine("\nВыведем слова текста, которые содержат не более 5 букв:");
            Message.GetWordsByLength(5);

            Console.WriteLine();
            Console.WriteLine("\nСамое длинное слово в тексте: " + Message.FindMaxLengthWord());

            Console.WriteLine("\nСформированная строка StringBuilder из самых длинных слов сообщения: \n" + Message.GetLongWordsString());

            Console.ReadKey();
        }
    }
}
