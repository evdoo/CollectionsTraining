using System;
using System.Collections.Generic;
using System.Globalization;

namespace Ex3
{
    class Program
    {
        static void Main(string[] args)
        {
            HashSet<double> set = new HashSet<double>();

            while (true)
            {
                ShowSystemMessage("Введи число");

                string input = Console.ReadLine();
                double number;
                IFormatProvider formatter1 = new NumberFormatInfo { NumberDecimalSeparator = "." };
                IFormatProvider formatter2 = new NumberFormatInfo { NumberDecimalSeparator = "," };
                bool success = double.TryParse(input, NumberStyles.AllowDecimalPoint, formatter1, out number)
                    || double.TryParse(input, NumberStyles.AllowDecimalPoint, formatter2, out number);

                if (success)
                {
                    bool added = set.Add(number);
                    if (added)
                    {
                        ShowSystemMessage("Число сохранено в множество\n");
                    } else
                    {
                        ShowSystemMessage("Число уже есть во множестве\n");
                    }
                } else
                {
                    ShowSystemMessage("Это было не число. Попробуй еще\n");
                    continue;
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
