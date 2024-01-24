using System;
using System.Collections.Generic;

namespace Ex2
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> notebook = new Dictionary<string, string>();
            FillNotebook(notebook);

            ShowSystemMessage("Введи номер телефона, и я найду имя владельца. Или нажми Esc для выхода из программы");

            while (true)
            {
                string input;
                Console.Write("Телефон: " + (input = GetInputOrExit()));
                string result = Find(notebook, input);
                Console.Write("\tВладелец: ");
                Console.WriteLine(result);
            }
        }

        private static void FillNotebook(Dictionary<string, string> notebook)
        {
            ShowSystemMessage("Вводи последовательно номера телефонов и имена их владельцев. Когда закончишь заполнять, нажми Enter");
            while (true)
            {
                string phoneNumber;
                string name;
                ShowSystemMessage("Введи телефон:");
                phoneNumber = Console.ReadLine();
                if (string.IsNullOrEmpty(phoneNumber))
                {
                    break;
                } else
                {
                    if (notebook.ContainsKey(phoneNumber))
                    {
                        ShowSystemMessage("Такой номер телефона уже есть");
                        continue;
                    } else
                    {
                        ShowSystemMessage("Введи имя:");
                        name = Console.ReadLine();

                        if (string.IsNullOrEmpty(name))
                        {
                            break;
                        }
                    }
                }

                notebook.Add(phoneNumber, name);
            }
        }

        private static string Find(Dictionary<string, string> notebook, string phoneNumber)
        {
            string name;
            bool success = notebook.TryGetValue(phoneNumber, out name);

            if (success)
            {
                return name;
            } else
            {
                return "В записной книжке нет такого номера";
            }
        }

        private static string GetInputOrExit()
        {
            string input = "";
            while (true)
            {
                ConsoleKeyInfo keyInfo = Console.ReadKey();
                switch (keyInfo.Key)
                {
                    case ConsoleKey.Escape:
                        Environment.Exit(0);
                        break;
                    case ConsoleKey.Enter:
                        return input;
                    case ConsoleKey.Backspace:
                        input = input.Remove(input.Length - 1);
                        Console.SetCursorPosition(Console.CursorLeft, Console.CursorTop);
                        Console.Write(" ");
                        Console.SetCursorPosition(Console.CursorLeft - 1, Console.CursorTop);
                        break;
                    default:
                        input += keyInfo.KeyChar;
                        break;
                }
            }
        }

        private static void ShowSystemMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
