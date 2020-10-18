using System;
namespace EpamStartTask
{
    public class ProgramManager
    {
        public static int Menu()
        {
            Console.Clear();
            Console.WriteLine("1 - Вывести все фигуры");
            Console.WriteLine("2 - Считать данные из файла");
            Console.WriteLine("3 - Найти фигуру с наибольшей площадью");
            Console.WriteLine("4 - Средняя площадь всех фигур");
            Console.WriteLine("5 - Средний периметр всех фигур");
            Console.WriteLine("6 - Найти тип фигуры с максимальным значением пириметра");
            Console.WriteLine("0 - выход из программы");
            int choize;
            if (int.TryParse(Console.ReadLine(), out choize))
                return choize;
            else return -1;

        }

        public static void Pause()
        {
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}
