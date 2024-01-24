using System;
using System.Collections.Generic;
using System.Text;

namespace Ex1
{
    class Program
    {
        private const int UNDEFINED = -1;

        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            FillingListByRandomInt(list, 100, 0, 100);

            PrintList(list);

            DeleteElements(list, 25, 50);
            PrintList(list);
        }

        private static void FillingListByRandomInt(List<int> list, int number, int min, int max)
        {
            Random random = new Random();
            for (int i = 0; i < number; i++)
            {
                list.Add(random.Next(min, max));
            }
        }

        //как правильнее: возвращать новый лист, или модифицировать старый?
        private static void DeleteElements(List<int> list, int minValue, int maxValue)
        {
            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] <= minValue || list[i] >= maxValue)
                {
                    list[i] = UNDEFINED;
                }
            }

            list.RemoveAll(it => it == UNDEFINED);
        }

        private static void PrintList(List<int> list)
        {
            StringBuilder builder = new StringBuilder();
            builder.Append("Элементы List: \n");
            foreach (int i in list)
            {
                if (list.IndexOf(i) < list.Count - 1)
                {
                    builder.Append(i + ", ");
                } else
                {
                    builder.Append(i);
                }
            }

            Console.WriteLine(builder.ToString());
            Console.WriteLine();
        }
    }
}
