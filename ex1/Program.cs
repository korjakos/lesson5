using System;
using System.Text.RegularExpressions;

namespace ex1
{
    class Program
    {
        //попытки
        static string RightTry(int x)
        {
            string s = "";
            if (x % 10 == 1 && x != 11) s += " попытка";
            else
                if ((x >= 2 && x <= 4) || (x >= 22 && x <= 24) || (x >= 32 && x <= 34) || (x > 41 && x < 45)) s += " попытки";
            else                   
                    if ((x == 11) || (x >= 5 && x <= 20) || (x >= 25 && x <= 30) || (x >= 35 && x < 41) || (x > 44 && x < 51)) s += " попыток";
            return s;
        }

        //Проверка правильности ввода
        static bool CheckLogin(string login)
        {
            int length = login.Length;
            if (length >= 2 && length <= 10)
            {
                bool check = true;
                char letter = login[0];
                if (Char.IsDigit(letter))
                    return false;
                for (int i = 1; i < length; i++)
                {
                    letter = login[i];
                    if (!(Char.IsDigit(letter) || IsLatinLetter(letter)))
                    {
                        check = false;
                        break;
                    }
                }
                if (check)
                    return true;
            }
            return false;
        }

        //Проверка правильности ввода через регулярные выражения
        static bool CheckLoginReg(string login)
        {
            char letter = login[0];
            if (Char.IsDigit(letter))
                return false;
            if (!Regex.IsMatch(login, @"^[a-zA-Z0-9]+${2,10}"))
                return false;
            return true;
        }

        //проверка латиницы
        private static bool IsLatinLetter(char letter)
        {
            int num = letter;
            if ((num >= 65 && num <= 90) || (num >= 97 && num <= 122))
                return true;
            else
                return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Вас приветствует программа проверки корректности логина.");
            int AmountOfTries = 3;

            do
            {
                Console.Write("Введите логин: ");
                string login = Console.ReadLine();

                if (CheckLogin(login) && CheckLoginReg(login))
                {
                    Console.WriteLine();
                    break;
                }
                else
                {
                    AmountOfTries--;
                    Console.WriteLine("Неверный ввод логина. \nДолжны быть соблюдены следующие условия:"
                        + "\nдлина строки 2 до 10 символов;"
                        + "\nбуквы только латинского алфавита или цифры;"
                        + "\nцифра не может быть первой."
                        + Environment.NewLine + "У Вас осталось " + AmountOfTries + RightTry(AmountOfTries));
                }

            } while (AmountOfTries > 0);

            Console.WriteLine("Логин корректен!");

            Console.ReadKey();
        }
    }
}