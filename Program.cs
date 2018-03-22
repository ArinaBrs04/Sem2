using System;
using System.IO;

namespace Structure
{
    class Program
    {
        static void Main(string[] args)
        {
            DoublyLinkedList linkedList = new DoublyLinkedList(Count());
            uint globalcount = Count();
            Console.WriteLine("Список отрезков из файла:");
            FileReader(linkedList);
            Console.WriteLine("\nВведите новый элемент списка");
            string elem = Console.ReadLine();
            Console.WriteLine("\nВведите индекс позиции списка, куда хотите вставить элемент");
            uint index2 = UInt32.Parse(Console.ReadLine());
            linkedList.InsertIndex(elem, index2);
            Console.WriteLine("\nНовый список отрезков из файла:");
            linkedList.Show();
            Console.WriteLine("\nСписок отрезоков, которые наклонены к оси абсцисс под углами 30 и 45 градусов: ");
            linkedList.AngleList();
            Console.WriteLine("\nВведите начало интервала: ");
            double start = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите конец интервала: ");
            double end = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("\nСписок отрезков из заданого интервала: ");
            linkedList.LengthList(start, end);
            Console.WriteLine("\nСписок отрезков, отсортированный по возрастанию длин: ");
            linkedList.Sort();
            Console.ReadKey();
        }
        //количество строк
        public static uint Count()
        {
            uint count = 0;
            using (StreamReader fs = new StreamReader("C:\\Prog\\1.txt"))
            {
                while (true)
                {
                    string temp = fs.ReadLine();
                    if (temp == null) break;
                    count += 1;
                }
                fs.Close();
                return count;
            }
        }
        public static void FileReader(DoublyLinkedList linkedList)
        {
            using (StreamReader fs = new StreamReader("C:\\Prog\\1.txt"))
            {
                while (true)
                {
                    string temp = fs.ReadLine();
                    if (temp == null) break;
                    linkedList.Push_Back(temp);
                }
                fs.Close();
            }
            linkedList.Show();
        }
    }
}